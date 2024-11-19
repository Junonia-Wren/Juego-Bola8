using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonScript : MonoBehaviour
{
    public ScriptOculta scriptOculta; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider pelota){
        if(pelota.CompareTag("player")){

            scriptOculta.plataforma.SetActive(true);
        }
    }
}
