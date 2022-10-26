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
    private bool jump1;
    private bool jump2;
    private bool grounded;
    [SerializeField] List<Espiritu> espiritus = new List<Espiritu>();
/*     public bool Player1_in;
    public bool Player2_in;
    public bool Player3_in;
    public bool Player4_in; */

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.Raycast(transform.position,Vector2.down,0.16f)){
            grounded=true;
        }else{
            grounded=false;
        }
    }


    public void Jump1(InputAction.CallbackContext context){
        if (grounded){
            jump1 = false;
            jump2 = false;
        }
        if (context.performed & espiritus[0].in_body){
            if (grounded){
                Rigidbody.AddForce(Vector2.up*jump*1.5f);
                jump1= true;
            }
            else if (!jump1)
            {
                Rigidbody.AddForce(Vector2.up*jump);
                jump1= true;
            }
        }
    }

    public void Jump2(InputAction.CallbackContext context){
        if (grounded){
            jump1 = false;
            jump2 = false;
        }
        if (context.performed & espiritus[1].in_body){
            if (grounded){
                Rigidbody.AddForce(Vector2.up*jump*1.5f);
                jump2= true;
            }
            else if (!jump2)
            {
                Rigidbody.AddForce(Vector2.up*jump);
                jump2= true;
            }
        }
    }

    public void Move1(InputAction.CallbackContext context){
        if (context.performed & espiritus[0].in_body){
            input_move = context.ReadValue<Vector2>();
            Debug.Log(input_move);
        }
    }

    public void Move2(InputAction.CallbackContext context){
        if (context.performed & espiritus[1].in_body){
            input_move = context.ReadValue<Vector2>();
            Debug.Log(input_move);
        }
    }

    void FixedUpdate()
    {
        Rigidbody.velocity = new Vector2(input_move.x*speed,Rigidbody.velocity.y);
    }
    
}