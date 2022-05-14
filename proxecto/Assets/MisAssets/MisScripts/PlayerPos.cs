using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Le asigna al jugador la posicion del checkpoint, la primera vez que se carga
public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        transform.position = gm.lastCheckpoint;
    }
}
