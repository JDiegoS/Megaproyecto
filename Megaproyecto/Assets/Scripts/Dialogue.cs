using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    // Tutorial:  https://www.youtube.com/watch?v=_nRzoTzeyxU&ab_channel=Brackeys 
    public string name;
    // 3 o mas dialogos por ahora
    [TextArea(3,10)]
    public string[] sentences;
}
