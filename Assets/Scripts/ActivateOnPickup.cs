using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnPickup : MonoBehaviour
{
    public DayManager dm;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(!dm.gameSelected && other.tag == "Street") {
            dm.GameSelected(this.gameObject.tag);
        }
    }
}
