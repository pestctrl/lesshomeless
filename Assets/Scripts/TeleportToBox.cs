using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToBox : MonoBehaviour
{
    public GameManager GM;
    public DayManager DM;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            DM.EndDay();
        }
        if (other.tag == "Bed")
        {
            GM.Sleep();
        }
    }
}
