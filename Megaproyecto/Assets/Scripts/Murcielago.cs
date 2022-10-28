using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Murcielago : MonoBehaviour
{
    public int speed = 5;
    public Transform startPosition;
    public Transform endPosition;
    public GameObject murcielago;
    public bool lookingLeft;
    public Nivel3 manager;
    public GameObject player;
    public NavMeshAgent agent;

    public PlayerNivel3 playerManager;
    private bool changedPosition;
    private float changedTime = 5f;
    public bool chasing = false;
    private bool firstChase = false;
    private bool previousLookLeft = false;
    private Vector3 previousTarget;
    public Vector3 target;
    private Vector3 rotateV = new Vector3(0f, 180f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        if (lookingLeft)
        {
            target = new Vector3(startPosition.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            target = new Vector3(endPosition.position.x, transform.position.y, transform.position.z);

        }
        newPosition();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.safe && chasing)
        {
            if (previousLookLeft && !lookingLeft)
            {
                murcielago.transform.Rotate(rotateV);
                lookingLeft = true;
            }
            else if (!previousLookLeft && lookingLeft)
            {
                murcielago.transform.Rotate(rotateV);
                lookingLeft = false;
            }
            chasing = false;
            target = previousTarget;
            newPosition();
        }
        else if (!playerManager.safe && !chasing)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist < 15)
            {
                chasing = true;
                firstChase = true;
            }
        }
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
                    agent.SetDestination(target);
                else
                {
                    lookingLeft = false;
                    target = new Vector3(endPosition.position.x, target.y, target.z);
                    murcielago.transform.Rotate(rotateV);
                }
            }

            else
            {

                if (transform.position.x < endPosition.position.x)
                    agent.SetDestination(target);

                else
                {
                    lookingLeft = true;
                    target = new Vector3(startPosition.position.x, target.y, target.z);
                    murcielago.transform.Rotate(rotateV);
                }
            }
        }

        else
        {
            if (firstChase)
            {
                previousLookLeft = lookingLeft;
                previousTarget = target;
                firstChase = false;

            }
            agent.SetDestination(player.transform.position);
            murcielago.transform.LookAt(new Vector3(player.transform.position.x, murcielago.transform.position.y, murcielago.transform.position.z));
            if (player.transform.position.x < transform.position.x)
                lookingLeft = true;
            else
                lookingLeft = false;


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerManager.safe)
            {
                chasing = false;
                return;
            }
            StartCoroutine(manager.LostGame());
        }
    }

    private void newPosition()
    {
        target = new Vector3(target.x, Random.Range(0.0f, 25.0f), transform.position.z);
        changedPosition = true;
        changedTime = 3;
    }


}
