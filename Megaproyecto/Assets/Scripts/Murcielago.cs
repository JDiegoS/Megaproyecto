using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour
{
    public int speed = 5;
    public Transform startPosition;
    public Transform endPosition;
    public bool lookingLeft;
    public GameObject player;

    private Rigidbody playerRb;
    private bool changedPosition;
    private float changedTime = 5f;
    private bool chasing = false;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        if (lookingLeft)
        {
            target = new Vector3(startPosition.position.x, 0, 0);
        }
        else
        {
            target = new Vector3(endPosition.position.x, 0, 0);

        }
        newPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (changedPosition)
        {
            if (changedTime > 0)
            {
                changedTime -= Time.deltaTime;

            }
            else
            {
                changedPosition = false;
                newPosition();
            }

        }

        

        if (!chasing)
        {


            if (lookingLeft)
            {
                if (transform.position.x > startPosition.position.x)
                    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                else
                {
                    lookingLeft = false;
                    target = new Vector3(endPosition.position.x, target.y, target.z);
                    Vector3 lookAtPos = new Vector3(0f, 180f, 0f);
                    transform.Rotate(lookAtPos);
                }
            }

            else
            {

                if (transform.position.x < endPosition.position.x)
                    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                else
                {
                    lookingLeft = true;
                    target = new Vector3(startPosition.position.x, target.y, target.z);
                    Vector3 lookAtPos = new Vector3(0f, 180f, 0f);
                    transform.Rotate(lookAtPos);
                }
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.LookAt(player.transform);

        }
    }

    private void newPosition()
    {
        target = new Vector3(target.x, Random.Range(0.0f, 10.0f), 0);
        changedPosition = true;
        changedTime = 3;
    }
}
