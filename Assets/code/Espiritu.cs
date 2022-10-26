using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Espiritu : MonoBehaviour
{
    private Rigidbody2D  playerbody;
    private Vector2 input_move;
    public float speed;
    public bool in_body;


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
            in_body = !in_body;
        }
    }

    private void FixedUpdate()
    {
        if (!in_body){
            playerbody.MovePosition(playerbody.position + input_move * speed);
        }

    }
    
}
