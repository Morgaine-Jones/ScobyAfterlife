using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoby : MonoBehaviour
{
    float duration = 1;
    Color color0 = Color.red;
    Color color1 = Color.blue;

    private void OnMouseOver()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        //light.color = Color.Lerp(color0, color1, t);
    }
}
