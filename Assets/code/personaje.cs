using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class personaje : MonoBehaviour
{
    private Rigidbody2D  Rigidbody;
    private Vector2 input_move;
    public float jump; /* al ser public las editamos en unity */
    public float speed;
    private bool grounded;
    public bool Player1_in;
    public bool Player2_in;
    public bool Player3_in;
    public bool Player4_in;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.Raycast(transform.position,Vector2.down,0.2f)){
            grounded=true;
        }else{
            grounded=false;
            Debug.Log("Jump");
        }
    }

    public void Jump(InputAction.CallbackContext context){
        if (context.performed & grounded & Player1_in){
            Rigidbody.AddForce(Vector2.up*jump);
        }
    }

    public void Move(InputAction.CallbackContext context){
        input_move = context.ReadValue<Vector2>();
        Debug.Log(input_move);
    }

    public void Possess(InputAction.CallbackContext context){
        if (context.performed ){
            Player1_in = !Player1_in;
        }
    }


    void FixedUpdate()
    {
        if (Player1_in){
            Rigidbody.velocity = new Vector2(input_move.x*speed,Rigidbody.velocity.y);
        }
    }
    
}