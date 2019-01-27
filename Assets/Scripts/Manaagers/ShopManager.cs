using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryManager IM;

    public void Shop(string itemName)
    {
        float itemPrice = 0;
        switch (itemName)
        {
            case "Squeegee_ShopItem":
                itemPrice = 50;
                if(IM.money >= itemPrice)
                {
                    print("added Squeegee");
                    IM.haveSqueegee = true;
                    IM.money = IM.money - itemPrice;
                }
                break;
            case "SwordFish_ShopItem":
                itemPrice = 100;
                if (IM.money >= itemPrice)
                {
                    print("added fish");
                    IM.haveSwordfish = true;
                    IM.money = IM.money - itemPrice;
                }
                break;
            case "DogFood_ShopItem":
                itemPrice = 45;
                if (IM.money >= itemPrice)
                {
                    print("added dogfood");
                    IM.dogFood = IM.dogFood + 45;
                    IM.money = IM.money - itemPrice;
                }
                break;
            case "Water_ShopItem":
                itemPrice = 25;
                if (IM.money >= itemPrice)
                {
                    print("added water");
                    IM.waterVal = IM.waterVal+25;
                    IM.money = IM.money - itemPrice;
                }
                break;
            case "Food_ShopItem":
                itemPrice = 25;
                if (IM.money >= itemPrice)
                {
                    print("added food");
                    IM.foodVal = IM.foodVal+25;
                    IM.money = IM.money - itemPrice;
                }
                break;
            default:
                break;
        }
    }
}
