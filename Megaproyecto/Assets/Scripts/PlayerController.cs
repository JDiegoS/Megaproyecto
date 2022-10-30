using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    public float speed = 7;
    public float jumpForce = 10;
    public float gravity = 25;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public AudioManager audioManager;
    public bool isAnt = false;

    private Vector3 moveTo;
    public bool grounded;
    private bool playedGrounded;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float movementx = Input.GetAxis("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(movementx));

        moveTo.x = movementx * speed;

        grounded = Physics.CheckSphere(groundCheck.position, 0.01f, groundLayer);

        if (grounded)
        {
            moveTo.y = 0;
            if (!playedGrounded)
            {
                animator.SetBool("jump", false);
                audioManager.Play("Aterrizar");
                playedGrounded = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (!isAnt)
                    audioManager.Play("Saltar");
                animator.SetBool("jump", true);
                playedGrounded = false;
                moveTo.y = jumpForce;
            }
        }
        else
        {
            moveTo.y -= gravity * Time.deltaTime;


        }
        animator.SetFloat("velocity", moveTo.y);

        controller.Move(moveTo * Time.deltaTime);
        if (movementx != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(moveTo.x * -1, 0, 0));
        }
    }
}
