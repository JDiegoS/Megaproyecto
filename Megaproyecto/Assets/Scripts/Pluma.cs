using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluma : MonoBehaviour
{
    public Nivel1 manager;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "item")
        {
            Destroy(hit.gameObject);
            manager.AddTime();
            return;
        }
    }
}
