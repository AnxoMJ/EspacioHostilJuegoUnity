using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

//Esta clase se encarga de gestionar el menú de las opciones
public class MenuOpciones : MonoBehaviour
{
    public TextMeshProUGUI TxPantalla;
    public AudioMixer audiomixer;
    public GameObject menu;
    public GameObject menprinPausa;
    private float valor;

    private void Start() {
    //Le establece al principio el valor del volumen al slider
        audiomixer.GetFloat("volumen",out valor);
        //hace que el valor del spinner corresponda con el del mezclador de audio
        GameObject.Find ("Slider").GetComponent<Slider>().value = valor;
        menprinPausa = GameObject.Find("CanvasMenuPausa");
        //en función de en que modo esté la pantalla, cambia el texto del bontón
        if (Screen.fullScreen)
         TxPantalla.text="Modo Ventana";
        //si se ejecuta en android, no se muestra la opción de cambiar tipo de pantalla
        if (Application.platform == RuntimePlatform.Android)
        {
           GameObject.Find("BtPantallaCompleta").SetActive(false);
        }
    }

    //Carga la scene que contiene al menu principal
    public void cargarMenuPrincipal(){
        transform.gameObject.SetActive(false);
        //Accedo a los datos del script "MenuPrincipal" del menú de pausa
        if (menu.tag=="MenuPausa")
            menprinPausa.GetComponent<MenuPrincipal>().menOpActivo = false;
        menu.SetActive(true);

    }

    //Cambia entre pantalla completa y ventana
    public void cambiarPantalla(){
        if (TxPantalla.text=="Pantalla Completa"){
            TxPantalla.text="Modo Ventana";
            Screen.fullScreen = true;
        }else{
            TxPantalla.text="Pantalla Completa";
            Screen.fullScreen = false;
        }
    }
    
    //Cambia el volumen, asignando el valor del slider al mezclador de audio
    public void cambiarVolumen(float volumen){
        audiomixer.SetFloat("volumen",volumen);
    }
}
