using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovimientoJugador : MonoBehaviour
{
    [Range(1, 10)] public float velocidad;
    Rigidbody2D rigidbody2;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    //JOYSTICK
    public Joystick joystick;
    float movimientoH;
    float movimientoV;

    public bool vulnerable = true;


    Animator animator;

    bool isJumping = false;
    [Range(1, 500)] public float potenciaSalto;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager=FindObjectOfType<GameManager>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //movimiento sin joystick
        //float movimientoH = Input.GetAxisRaw("Horizontal");

        if ((joystick.Horizontal >= .2f) | (joystick.Horizontal <= .2f))
        {
            movimientoH = joystick.Horizontal;
        }
        else
        {
            movimientoH = 0;
        }
        movimientoV = joystick.Vertical;

        rigidbody2.velocity = new Vector2(movimientoH * velocidad, rigidbody2.velocity.y);
        if (movimientoH < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
            if (movimientoH > 0)
            spriteRenderer.flipX = false;
        if (movimientoH != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
            animator.SetBool("isWalking", false);
        //Sin joystick
        //if(Input.GetButton("Jump") && !isJumping)
        if (movimientoV >= .5f && !isJumping)
        {
            rigidbody2.AddForce(Vector2.up * potenciaSalto);
            isJumping = true;
        }
        if (isJumping)
            animator.SetBool("isJumping", true);
        else
            animator.SetBool("isJumping", false);
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;

            rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, 0);
        }
    }
    public void QuitarVida()
    {
        if (vulnerable)
        {
            gameManager.decrementarVidas();
            vulnerable = false;
            spriteRenderer.color = Color.red;
            Invoke("hacerVulnerable", 1f);
        }
    }
    public void PowerUp()
    {
        gameManager.incrementarVidas();
        vulnerable = false;
        Invoke("hacerVulnerable", 5f);
    }
    public void hacerVulnerable()
    {
        spriteRenderer.color = Color.white;
        vulnerable = true;
    }
}
