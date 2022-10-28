using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuchilloTrigger : MonoBehaviour
{
    public Vector3 yMax;
    private Vector3 yPos;
    public float speed = 1.0f;
    public float waitTime = 4.0f;
    public AudioManager audioManager;

    private bool crush = false;
    private bool ready = true;
    private bool played = false;


    private void Start()
    {
        yPos = transform.position;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (crush && ready)
        {
            if (!played)
            {
                audioManager.Play("Knife");
                played = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, yMax, speed * Time.deltaTime);
            if (transform.position == yMax)
            {

                crush = false;
                ready = false;
                played = false;
                StartCoroutine(CrushWait());
            }
        }
        else if (transform.position != yPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, yPos, (speed/1.5f) * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ant")
        {
            crush = true;
        }
    }


    IEnumerator CrushWait()
    {
        yield return new WaitForSeconds(waitTime);
        ready = true;
    }
}
