using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuchilloMovement : MonoBehaviour
{

    public Vector3 yMax;
    private Vector3 yPos;
    public float speed = 1.0f;

    private void Start()
    {
        yPos = transform.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(yPos, yMax, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
