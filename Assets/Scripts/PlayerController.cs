using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables privadas
    private Rigidbody rb;
    private Vector2 inputMov; //Movimiento del player
    private Vector2 inputRot; //Rotacion de la camara
    private Transform cam;
    private Transform gun;
    private float rotX; //Rotacion en Y de la camara
    private bool playerOnGround = true; //El jugador esta en el suelo? Y/N
    private bool jump = false;

    //Variables publicas
    public float velMov = 10f; //Velocidad de movimiento del player
    public float mouseSens = 0.5f; //Sensivilidad del mouse
    public float jumpForce = 5f; //Fuerza de salto del player
    public Joystick joystickMove;
    public Joystick joystickRotate;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0); //Dar la posicion del primer hijo del GO
        gun = transform.GetChild(1);
        rotX = cam.eulerAngles.x;


    }

    private void Update()
    {
        //Leemos el input de movimiento (joysticks y teclado)
        inputMov.x = joystickMove.Horizontal /*+ Input.GetAxis("Horizontal")*/;
        inputMov.y = joystickMove.Vertical /*+ Input.GetAxis("Vertical")*/;

        //Leemos el input de rotacion
        inputRot.x = joystickRotate.Horizontal /*+ Input.GetAxis("Mouse X") */ * mouseSens;
        inputRot.y = joystickRotate.Vertical /*+ Input.GetAxis("Mouse Y") */ * mouseSens;

        //Saltar
        if (/*Input.GetButtonDown("Jump") && playerOnGround == true ||*/ jump == true && playerOnGround == true)
        {
            rb.AddForce(0, jumpForce, 0);
            playerOnGround = false;
            jump = false;

            //Instanciar el sonido de salto
            AudioManager.Instance.PlaySFX("Jump");
        }
    }

    private void FixedUpdate()
    {
        //Usar los inputs para moverse
        float vel = velMov;

        rb.velocity = transform.forward * vel * inputMov.y  //Movimiento hacia adelante y hacia atras
                      + transform.right * vel * inputMov.x  //Movimiento hacia la derecha e izquierda
                      + new Vector3(0, rb.velocity.y, 0);   //Velocidad en Y (gravedad) 

        //Usar los inputs para girar
        transform.rotation *= Quaternion.Euler(0, inputRot.x, 0); //Rotar horizontalmente
        
        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -50, 50); //Delimitar la rotacion de la camara
        cam.localRotation = Quaternion.Euler(rotX, 0, 0);
        gun.localRotation = Quaternion.Euler(rotX, 0, 0);
    }

    //Funcion para verificar si el jugador esta en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerOnGround = true;
        }
    }

    //Funcion que interactua con el boton de salto
    public void Jump()
    {
        jump = true;
    }
}
