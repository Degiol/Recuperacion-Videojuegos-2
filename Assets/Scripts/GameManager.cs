using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /**
     * Game manager
     * -Tiempo DONE
     * -Cambio de escena DONE
     * -Control de vida DONE
     * -Puntos DONE
     * Canvas DONE
     * -Tiempo(reset) DONE
     * -vidas DONE
     * -Puntuacion DONE
     * Control para movil(Joystick)
     * Generar apk
     */
    private GameObject gameManager;
    float tiempo;
    int segundos=0;
    int puntuacion;
    int vidas;
    public TextMeshProUGUI UItiempo;
    public TextMeshProUGUI UIpuntuacion;
    public TextMeshProUGUI UIvidas;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        //No destruir al cambiar de escena
        DontDestroyOnLoad(gameManager);
        DontDestroyOnLoad(canvas);
        inicializarPuntuacion();
        inicializarVidas();

        cambiarEscena("Escena 1");
    }
    public void inicializarTiempo()
    {
        segundos = 0;
    }
    private void inicializarPuntuacion()
    {
        puntuacion = 1000;
        UIpuntuacion.text = "PUNTUACION: " + puntuacion;
    }
    public void inicializarVidas()
    {
        vidas = 3;
        UIvidas.text = "VIDAS: " + vidas;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 1f)
        {//Si ha pasado un segundo
            tiempo = 0;
            incrementarTiempo();
        }
    }
    private void FixedUpdate()
    {
    }
    public void cambiarEscena(string siguienteEscena)
    {
        SceneManager.LoadScene(siguienteEscena);
    }
    public void incrementarTiempo()
    {
        segundos++;
        if (segundos >= 60)
        {
            int minutos = segundos / 60;
            UItiempo.text ="TIEMPO: "+ minutos + ":" + ((60*minutos)-segundos);
        }
        else
            UItiempo.text = "TIEMPO: 00:" + segundos;
        decrementarPuntuacion(1);
    }
    public void decrementarPuntuacion(int cantidad)
    {
        if (puntuacion - cantidad > 0)
            puntuacion = puntuacion-cantidad;
        else
            puntuacion = 0;
        UIpuntuacion.text = "PUNTUACION:" + puntuacion;
    }
    public void incrementarPuntuacion(int cantidad)
    {
        puntuacion += cantidad;
    }
    public void incrementarVidas()
    {
        vidas++;
        incrementarPuntuacion(20);
        UIvidas.text = "VIDAS: " + vidas;
    }
    public void decrementarVidas()
    {
        vidas--;
        UIvidas.text = "VIDAS: " + vidas;
        decrementarPuntuacion(10);
    }
}
