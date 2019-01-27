using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public SwordFish SF;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trash")
        {
            SF.TrashHasBeenPutIntoBasket();
        }
    }

}
