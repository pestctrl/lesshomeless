﻿using System.Collections;
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
                itemPrice = 0;
                if(IM.money >= itemPrice)
                {
                    print("added Squeegee");
                    IM.haveSqueegee = true;
                }
                break;
            case "SwordFish_ShopItem":
                itemPrice = 0;
                if (IM.money >= itemPrice)
                {
                    print("added fish");
                    IM.haveSwordfish = true;
                }
                break;
            case "DogFood_ShopItem":
                itemPrice = 0;
                if (IM.money >= itemPrice)
                {
                    print("added dogfood");
                    IM.numDogfoods++;
                }
                break;
            case "Water_ShopItem":
                itemPrice = 0;
                if (IM.money >= itemPrice)
                {
                    print("added water");
                    IM.waterVal = IM.waterVal+25;
                }
                break;
            case "Food_ShopItem":
                itemPrice = 0;
                if (IM.money >= itemPrice)
                {
                    print("added food");
                    IM.foodVal = IM.foodVal+25;
                }
                break;
            default:
                break;
        }
    }
}
