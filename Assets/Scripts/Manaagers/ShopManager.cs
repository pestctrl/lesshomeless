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
                    print("added Squeegee");
                    IM.haveSqueegee = true;
                }
                break;
            case "SwordFish_ShopItem":
                itemPrice = 0;
                if (GM.money > itemPrice)
                {
                    IM.haveSwordfish = true;
                }
                break;
            case "DogFood_ShopItem":
                itemPrice = 0;
                if (GM.money > itemPrice)
                {
                    IM.numDogfoods++;
                }
                break;
            case "Water_ShopItem":
                itemPrice = 0;
                if (GM.money > itemPrice)
                {
                    IM.waterVal = IM.waterVal+25;
                }
                break;
            case "Food_ShopItem":
                itemPrice = 0;
                if (GM.money > itemPrice)
                {
                    IM.foodVal = IM.foodVal+25;
                }
                break;
            default:
                break;
        }
    }
}
