using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//se encarga de gestionar los checkpoits del juego, guardando una instancia con los atos que queremos y de mostrar los controles si se ejecuta en android
public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpoint;
    public GameObject controles;

    private void Awake()
    {
        //Se se executa en android activa os botóns de control
        if (Application.platform == RuntimePlatform.Android)
        {
            controles.SetActive(true);
        }
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
