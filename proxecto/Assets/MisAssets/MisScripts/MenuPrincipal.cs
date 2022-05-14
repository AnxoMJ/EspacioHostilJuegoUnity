using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Esta clase se encarga de gestionar el menú principal y el de pausa. Al usar los mismos métodos, la única diferencia es que el menú de pausa se muestra y se oculta
public class MenuPrincipal : MonoBehaviour
{
    public static bool juegoPausado = false;
    public GameObject menu;
    public GameObject menOpc;
    public bool menOpActivo = false;
    private GameObject personaje;

    private void Update()
    {
        //Si es el menu pausa, se activa y desactiva con la tecla escape.
        if (menu.tag == "MenuPausa" && !menOpActivo)
        {
            if (SimpleInput.GetButtonDown("Pausa"))
            {
                //Si el jugador está muerto no se muestra el menú
                personaje = GameObject.Find("Astronauta");
                if (personaje.GetComponent<Corazones>().salud <= 0)
                    return;
                if (juegoPausado)
                {
                    continuar();
                }
                else
                {
                    pausar();
                }
            }
        }
    }
    //continua el juego
    public void continuar()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
        if (menu.tag == "MenuPausa")
        {
            personaje = GameObject.Find("Astronauta");
            personaje.GetComponent<JugadorAndroid_PC>().pausado = false;
        }
    }
    //pausa el juego
    public void pausar()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
        if (menu.tag == "MenuPausa")
        {
            personaje = GameObject.Find("Astronauta");
            personaje.GetComponent<JugadorAndroid_PC>().pausado = true;
        }
    }
    //inicia el primer nivel
    public void reintentar()
    {
        //carga por índice
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    //inicia el primer nivel
    public void comenzar()
    {
        //carga por índice
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene("PrimerNivel");
    }
    //carga la scene que contiene al menu principal
    public void cargarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
        menu.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }
    //carga al menu de opciones
    public void cargarMenuOpciones()
    {
        menOpActivo = true;
        menu.SetActive(false);
        menOpc.SetActive(true);
    }
    //sale del juego
    public void cerrarJuego()
    {
        Application.Quit();
    }
}
