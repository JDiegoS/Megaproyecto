using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }

    public void ChangeTarget(int player)
    {
        if (player == 2) {
            target = GameObject.FindGameObjectWithTag("ant").transform;
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
            offset = transform.position - target.position;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
            offset = transform.position - target.position;
        }
    }
}
