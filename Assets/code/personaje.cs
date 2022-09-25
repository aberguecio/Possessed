using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    private Rigidbody2D  Rigidbody;
    private float Horizontal;
    public float jump; /* al ser public las editamos en unity */
    public float speed;
    private bool Grounded;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); /* +1 con D y -1 con A */

        /* Debug.DrawRay(transform.position, Vector3.down * 0.2f,Color.red); */ 
        if (Physics2D.Raycast(transform.position, Vector3.down ,0.15f)){/* rallo para abajo para saber si hay terreno */
            Grounded=true;
        }else{
            Grounded=false;
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }
    }

    private void Jump(){
        Rigidbody.AddForce(Vector2.up*jump);
    }

    void FixedUpdate()
    {
        Rigidbody.velocity = new Vector2(Horizontal*speed,Rigidbody.velocity.y);
    }
    
}