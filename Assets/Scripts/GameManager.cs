using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /**
     * Game manager
     * -Tiempo
     * -Cambio de escena
     * -Control de vida
     * -Puntos
     * Canvas
     * -Tiempo(reset)
     * -vidas
     * -Puntuacion
     * Control para movil(Joystick)
     * Generar apk
     */
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        //No destruir al cambiar de escena
        DontDestroyOnLoad(gameManager);

        cambiarEscena("SampleScene1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiarEscena(string siguienteEscena)
    {
        SceneManager.LoadScene(siguienteEscena);
    }
}
