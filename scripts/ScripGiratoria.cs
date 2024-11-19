using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripGiratoria : MonoBehaviour
{
    public float velocidad= 30;

    private Vector3 direccion= Vector3.up;

    private int limtepSu= 270;

    private int limitepInf= 90; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.eulerAngles.y >= limtepSu){
            direccion= Vector3.down; 
        }
        if(transform.rotation.eulerAngles.y <= limitepInf){
            direccion=Vector3.up;
        }
        transform.Rotate(direccion*Time.deltaTime* velocidad); 
        
    }
}
