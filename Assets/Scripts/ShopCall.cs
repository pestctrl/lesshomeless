using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCall : MonoBehaviour
{

    public ShopManager SM;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShopItem")
        {
            SM.Shop(other.name);
        }
    }
}
