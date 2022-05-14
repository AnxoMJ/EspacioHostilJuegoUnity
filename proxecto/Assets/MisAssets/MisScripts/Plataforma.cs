using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simplemente gestiona las plataformas, permitiendo subirlas y bajarlas rotandolas(porque tienen colisión en un único sentido)
public class Plataforma : MonoBehaviour
{
    //usamos el Platform effector 
    private PlatformEffector2D effector;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    //rota la colisión 180º según se salte o se agache
    private void FixedUpdate()
    {
        //para solo pc cambiar SimpleInput por Input
        //se se presiona o boton de agacharse
        if (SimpleInput.GetButton("Agacharse") || SimpleInput.GetAxisRaw("Agacharse") < 0)
        {
            if (effector.rotationalOffset == 0f)
                effector.rotationalOffset = 180f;
        }
        //cando se salta se resetea a rotación da plataforma
        if (SimpleInput.GetButton("Saltar"))
        {
            if (effector.rotationalOffset != 0f)
                effector.rotationalOffset = 0f;
        }
    }
}
