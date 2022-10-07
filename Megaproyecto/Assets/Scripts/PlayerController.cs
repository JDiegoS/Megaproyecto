using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 7;
    public float jumpForce = 10;
    public float hitForce = 4;
    public float gravity = -25;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private Vector3 moveTo;
    private bool grounded;
    bool fired = false;
    private float firedTime = 0;


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
        if (transform.position.x <= 10 || movementx < 0)
            controller.Move(moveTo * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") && !fired)
        {
            fired = true;
            
        }
        if (fired)
        {
            firedTime += Time.deltaTime;
        }

        if (firedTime > 1f)
        {
            fired = false;
            firedTime = 0;
        }


    }
    
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       

        if (hit.gameObject.tag == "ball")
        {
            float forceA = 2;
            
            Rigidbody rb = hit.collider.attachedRigidbody;

            if (rb != null)
            {
                Vector3 forceD = hit.gameObject.transform.position - transform.position;
                forceD.z = 0;
                if (fired)
                {
                    forceA = 4;
                    //forceD.y *= 4;
                    //forceD.x *= 2;
                    rb.AddForce(gameObject.transform.up * hitForce, ForceMode.Impulse);
                    fired = false;
                    firedTime = 0;
                    forceD.Normalize();
                    rb.AddForceAtPosition(forceD * forceA, transform.position, ForceMode.Impulse);
                    return;

                }

                forceD.Normalize();
                rb.AddForceAtPosition(forceD * forceA, transform.position, ForceMode.Impulse);
            }
        }

    }

    

    
}
