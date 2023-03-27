using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;

    private Vector3 posicionInicio;
    private bool moviendoAFin;

    private Vector3 posicionDestino;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;


    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void MoverEnemigo()
    {
        posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;

        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        if (transform.position == posicionFin){
            moviendoAFin = false;
            spriteRenderer.flipX = true;
            }

        if (transform.position == posicionInicio)
        {
            moviendoAFin = true;
            spriteRenderer.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            Debug.Log("colision");
            //collision.gameObject.GetComponent<MovimientoJugador>().QuitarVida();
        }
    }
}