using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public JuegoPelota manager;
    public AudioManager audioManager;
    public BoxCollider invis;
    private SphereCollider scollider;

    private void Start()
    {
        scollider = gameObject.GetComponent<SphereCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "invisible wall")
        {
            Physics.IgnoreCollision(invis, scollider);
        }
        if (collision.gameObject.name == "Ring1")
        {
            manager.scoreTeam2();
        }
        else if (collision.gameObject.name == "Ring2")
        {
            manager.scoreTeam1();
        }
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "wall")
        {
            audioManager.Play("Aterrizar");
        }
    }
}
