using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToBox : MonoBehaviour
{
    public GameManager GM;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            GM.GoToBox();
        }
    }
}
