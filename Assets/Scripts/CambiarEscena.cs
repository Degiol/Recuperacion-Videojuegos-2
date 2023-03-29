using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            Debug.Log("Cambio Escena");
            GameManager.cambiarEscena("Escena 2");

        }
    }
}
