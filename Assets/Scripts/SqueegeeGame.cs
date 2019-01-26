using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueegeeGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DirtyCar")
        {
            print("dirty");
        }
    }
    
}
