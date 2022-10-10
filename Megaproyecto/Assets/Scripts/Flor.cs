using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flor : MonoBehaviour
{
    public Nivel2 manager;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "item")
        {
            Destroy(hit.gameObject);
            manager.CollectItem();
            return;
        }
    }
}
