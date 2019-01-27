using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnPickup : MonoBehaviour
{
    public DayManager dm;
    
    private void OnTriggerExit(Collider other)
    {
        if(dm.activeGame == null && other.tag == "Street") {
            print(this.gameObject.tag + " Game Start");
            dm.GameSelected(this.gameObject.tag);
        }
    }
}
