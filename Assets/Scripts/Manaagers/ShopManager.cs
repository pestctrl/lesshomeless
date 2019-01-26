using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameManager GM;
    public InventoryManager IM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shop(string itemName)
    {
        float itemPrice = 0;
        switch (itemName)
        {
            case "Squeegee_ShopItem":
                itemPrice = 0;
                if(GM.money > itemPrice)
                {
                    IM.haveSqueegee = true;
                }
                break;
            default:
                break;
        }
    }
}
