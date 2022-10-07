using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPelota : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 5;
    public int hitForce = 5;
    public Transform minPosition;
    public Transform maxPosition;
    public Transform stuckPosition;
    public GameObject ball;

    private bool lookingLeft = true;
    private Rigidbody rb;
    private Rigidbody ballRb;
    private int multipier = 1;
    private bool grounded = true;
    private bool chasing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ballRb = ball.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (!chasing)
        {

            if (lookingLeft)
            {
                if (transform.position.x > minPosition.position.x)
                    transform.position = Vector3.MoveTowards(transform.position, minPosition.position, speed * Time.deltaTime);
                else
                {
                    lookingLeft = false;
                    multipier = 1;
                    Vector3 lookAtPos = new Vector3(0f, 180f, 0f);
                    transform.Rotate(lookAtPos);
                }
            }

            else
            {

                if (transform.position.x < maxPosition.position.x)
                    transform.position = Vector3.MoveTowards(transform.position, maxPosition.position, speed * Time.deltaTime);
                else
                {
                    lookingLeft = true;
                    multipier = -1;
                    Vector3 lookAtPos = new Vector3(0f, 180f, 0f);
                    transform.Rotate(lookAtPos);
                }
            }

            if (ball.transform.position.y > 1.5f && Mathf.Abs(ball.transform.position.x - transform.position.x) <= 2 && grounded)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                grounded = false;
            }
        }

        if (ball.transform.position.y < 4 && ball.transform.position.x >= transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, stuckPosition.position, speed * Time.deltaTime);
            chasing = true;
            if (Mathf.Abs(ball.transform.position.x - transform.position.x) <= 1.5f && grounded)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                grounded = false;
            }
            

        }
        else if (chasing)
        {
            chasing = false;

        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            
            ballRb.AddForce(gameObject.transform.right * hitForce * multipier, ForceMode.Impulse);
            ballRb.AddForce(gameObject.transform.up * hitForce, ForceMode.Impulse);

        }
        if (collision.gameObject.tag == "ground" && !grounded)
        {
            grounded = true;
        }
    }


}
