using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{

    //Estas son las variables By Tauste
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float jumpForce = 1.0f;
    public float horizontal, vertical, rotationY;
    private Rigidbody physics;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        if (physics == null)
        {
            physics = gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {   
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            physics.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            canJump = false;
        }              
    }

    void OnCollisionEnter(Collision other)
    {
        // Hemos puesto un tag "Ground" sobre el suelo
        if (other.gameObject.CompareTag("Suelo"))
        {
            canJump = true;
        }
    }
}  
