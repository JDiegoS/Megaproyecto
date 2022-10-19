using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 7;
    public float jumpForce = 10;
    public float gravity = -25;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private Vector3 moveTo;
    private bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {

        float movementx = Input.GetAxis("Horizontal");

        moveTo.x = movementx * speed;
        moveTo.y += gravity * Time.deltaTime;

        grounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        if (grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveTo.y = jumpForce;
            }
        }
        controller.Move(moveTo * Time.deltaTime);
        if (movementx != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(moveTo.x * -1, 0, 0));
        }
    }
}
