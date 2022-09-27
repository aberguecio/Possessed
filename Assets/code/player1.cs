using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player1 : MonoBehaviour
{
    private Rigidbody2D  playerbody;
    private Vector2 input_move;
    public float speed;
    public bool Player1_in;


    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Move(InputAction.CallbackContext context){
        input_move = context.ReadValue<Vector2>();
    }

    public void Possess(InputAction.CallbackContext context){
        if (context.performed ){
            Player1_in = !Player1_in;
        }
    }

    private void FixedUpdate()
    {
        if (Player1_in){
            playerbody.MovePosition(playerbody.position + input_move * speed);
        }

    }
    
}
