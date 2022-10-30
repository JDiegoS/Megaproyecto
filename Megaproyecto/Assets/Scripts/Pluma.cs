using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluma : MonoBehaviour
{
    public Nivel1 manager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            manager.AddTime();
            Destroy(other.gameObject);
            return;
        }
    }
}
