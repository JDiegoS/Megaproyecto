using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    public Nivel2 manager;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ant")
            manager.TimeEnd();
    }
}
