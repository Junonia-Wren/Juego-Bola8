using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScriptTiempo : MonoBehaviour
{
    private ScriptGameManager gameManager; 
    public Text textoTiempo; 

    // Start is called before the first frame update
    void Start()
    {
        textoTiempo.text=" 0:00";
        gameManager = FindObjectOfType<ScriptGameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isLive){
            textoTiempo.text= " "+formatearTiempo(); 
        }
    }

    public string formatearTiempo(){
        if( gameManager.isLive){
            gameManager.tiempo += Time.deltaTime; 
        }
        string minutos= Mathf.Floor(gameManager.tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(gameManager.tiempo % 60).ToString("00");


        return minutos + " : "+ segundos; 
    }
}
