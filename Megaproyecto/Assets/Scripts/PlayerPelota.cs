using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPelota : MonoBehaviour
{

    public CharacterController controller;

    public Animator animator;
    public float hitForce = 4;


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
    
    IEnumerator StopHit()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("hit", false);
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       

        if (hit.gameObject.tag == "ball")
        {
            animator.SetBool("hit", true);
            StartCoroutine(StopHit());

            float forceA = 2;
            
            Rigidbody rb = hit.collider.attachedRigidbody;

            if (rb != null)
            {
                Vector3 forceD = hit.gameObject.transform.position - transform.position;
                forceD.z = 0;
                if (fired)
                {
                    Debug.Log("fireeed");

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
