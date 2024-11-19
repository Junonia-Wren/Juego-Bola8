using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody cuerpoPlayer;
    public float velocidad = 5; 
    public float salto = 7;
    private ScriptGameManager gameManager; 
    public Text textoVidas;
    Vector3 posicionInicial; 

    public Text textomonedas;
    public Text textomensaje;

    public AudioSource sonidoMoneda;
    public AudioSource sonidoSalto; 
    public AudioSource sonidoGameO;
    public AudioSource sonidoWin;
    public AudioSource sonidoFondo;
    public AudioSource sonidoCaer;

    public GameObject IMGgameO; //Declarar iamgen de game over
    public Button BotonResert; //DECLARACION DEL BOTON 
    public GameObject IMGwin; 

   
    
    


    
    void Start()
    {
        IMGgameO.gameObject.SetActive(false);//Ocultar imagen de GAME OVER
        IMGwin.gameObject.SetActive(false); 
        BotonResert.gameObject.SetActive(false);//OCULTAR BOTON DESDE EL INICIO 


        gameManager= FindObjectOfType<ScriptGameManager>();
        textoVidas.text= " "+ gameManager.vidas; 
        textomonedas.text=" "+gameManager.monedas; 

        cuerpoPlayer = GetComponent<Rigidbody>();
        posicionInicial= transform.position; //almacenar la posicion inicial del jugador 

        textomensaje.text=" ";




        
    }

    // Update is called once per frame 

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (gameManager.vidas>0 && gameManager.monedas>0){
            moverJugador();
            if(transform.position.y < -1){
                quitarVidas();
            } 
        }
        else if(gameManager.vidas==0){
            gameManager.isLive=false;
            //textomensaje.text="Game Over";
            IMGgameO.SetActive(true);//aparecer imagen 
            BotonResert.gameObject.SetActive(true);//APARECER BOTON
        }
        else if(gameManager.monedas==0){
            gameManager.isLive=false;
            //textomensaje.text="Ganaste el Juego :D";
            IMGwin.SetActive(true); 
            BotonResert.gameObject.SetActive(true); 
        }
    }
    
void moverJugador(){
 //capturar movimiento de las teclas horizontal o vertical
    float movimientoH = Input.GetAxis("Horizontal");
    float movimientoV = Input.GetAxis("Vertical");

//capturamos la posicion en la variable movimiento
    Vector3 movimiento = new Vector3(movimientoH*velocidad,0.0f, movimientoV*velocidad);
    //asignamos el movimiento aljugador
    cuerpoPlayer.AddForce(movimiento);
    if(Input.GetButton("Jump")&& isSuelo ()){
        cuerpoPlayer.velocity += Vector3.up*salto;
        sonidoSalto.Play();
    }}

//estando en el suelo brinca
private bool isSuelo()
{
Collider[] colisiones = Physics.OverlapSphere(transform.position, 0.5f);
foreach (Collider colision in colisiones) 
{
 if (colision.tag=="Suelo"){
    return true;
 }

}
return false; 

}

 void quitarVidas(){
    gameManager.vidas--;//quitar las vidas 
    
    sonidoCaer.Play();//PENDIENTE
    textoVidas.text=" "+gameManager.vidas; //Actualizar el texto de las vidas 
    transform.position= posicionInicial;
    cuerpoPlayer.velocity= Vector3.zero; //regresar el cuerpo a la posicion inicial 
    if(gameManager.vidas == 0){
        sonidoFondo.Pause();
        sonidoGameO.Play();
    }
}
void OnTriggerEnter(Collider monedas){
    if (monedas.CompareTag("Moneda"))
    {
        monedas.gameObject.SetActive(false);

        gameManager.monedas--; 
        sonidoMoneda.Play();
        textomonedas.text= "" + gameManager.monedas; 
        if(gameManager.monedas==0){
            cuerpoPlayer.velocity= Vector3.zero; //regresar el cuerpo a la posicion inicial 
            sonidoFondo.Pause();
            sonidoWin.Play();
        }


    }
    
}

}
