using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flor : MonoBehaviour
{
    public Nivel2 manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            manager.CollectItem();
            Destroy(other.gameObject);
            return;
        }
    }
}
