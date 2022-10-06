using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPelota : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 5;
    public Transform minPosition;
    public Transform maxPosition;
    public GameObject ball;

    private bool lookingLeft = true;
    private Rigidbody rb;
    private Rigidbody ballRb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ballRb = ball.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lookingLeft)
        {
            if (transform.position.x > minPosition.position.x)
                transform.position = Vector3.MoveTowards(transform.position, minPosition.position, speed * Time.deltaTime);
            else
                lookingLeft = false;
        }

        else
        {
            if (transform.position.x < maxPosition.position.x)
                transform.position = Vector3.MoveTowards(transform.position, maxPosition.position, speed * Time.deltaTime);
            else
                lookingLeft = true;
        }

        if (ball.transform.position.y > 1.5f && ball.transform.position.x - transform.position.x <= 1)
        {
            rb.AddForce(transform.up * jumpForce);
        }

    }
}
