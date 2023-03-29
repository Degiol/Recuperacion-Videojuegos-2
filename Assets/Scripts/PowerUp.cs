using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Collider2D Collider2D;
    SpriteRenderer Renderer;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D = GetComponent<Collider2D>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            Debug.Log("powUp");
            collision.gameObject.GetComponent<MovimientoJugador>().PowerUp();
            Destroy(Collider2D);
            Destroy(Renderer);

        }
    }
}
