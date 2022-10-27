using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPelota : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 5;
    public int hitForce = 5;
    public Animator animator;
    public Transform minPosition;
    public Transform maxPosition;
    public Transform stuckPosition;
    public Vector3 right = new Vector3(20f, 0f, 0f);
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
            if (grounded)
            {
                animator.SetBool("move", true);
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
            }

            if (ball.transform.position.y > 1.5f && ball.transform.position.y < 4 && lookingLeft && Mathf.Abs(ball.transform.position.x - transform.position.x) <= 4 && ballRb.velocity.x > 0 && grounded)
            {
                animator.SetBool("jump", true);
                grounded = false;
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            }

        }

        if (ball.transform.position.y < 6 && ball.transform.position.x >= transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, stuckPosition.position, speed * Time.deltaTime);
            chasing = true;

            if (transform.position == stuckPosition.position)
            {
                animator.SetBool("move", false);
            }

            /*
            if (Mathf.Abs(ball.transform.position.x - transform.position.x) <= 4 && ballRb.velocity.x < 0 && grounded)
            {
                grounded = false;
                Debug.Log("chase jump");
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
            */
            

        }
        else if (chasing)
        {
            chasing = false;

        }
        /*
        if (Mathf.Abs(ball.transform.position.x - transform.position.x) <= 0.1f && ball.transform.position.y < 0)
        {
            Debug.Log("pushed");
            rb.AddForce(transform.right * 20 * multipier * -1, ForceMode.Impulse);
        }
        */



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            ballRb.AddForce(gameObject.transform.right * hitForce * multipier, ForceMode.Impulse);
            ballRb.AddForce(gameObject.transform.up * hitForce, ForceMode.Impulse);
            animator.SetBool("hit", true);
            StartCoroutine(StopHit());
        }
        if (collision.gameObject.tag == "ground" && !grounded)
        {
            grounded = true;
            animator.SetBool("jump", false);
        }
    }

    IEnumerator StopHit()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("hit", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball" && chasing && grounded)
        {

            grounded = false;
            animator.SetBool("jump", true);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(right, ForceMode.Impulse);
            if (Mathf.Abs(ball.transform.position.x - transform.position.x) <= 0.2f && ball.transform.position.y < 0)
            {
                rb.AddForce(right, ForceMode.Impulse);
            }
        }
    }


}
