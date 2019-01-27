using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public SwordFish SF;

    void OnTriggerEnter(Collider other)
    {
        print("sword collide " + other.tag);
        if (other.tag == "Basket")
        {
            SF.spearedObj.SetActive(false);
        }
    }

}
