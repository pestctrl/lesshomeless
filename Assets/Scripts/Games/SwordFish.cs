using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour, HomelessGame
{
    int t1Count;//mid
    int t2Count;//high
    HomelessGameObjects gameobjects;

    public float GetMoneyAndEndGame()
    {
        float MoneyGenerated = (t1Count * 10) + (t2Count * 20);
        gameobjects.TrashHigh.Stop();
        gameobjects.TrashMid.Stop();
        this.enabled = false;
        gameobjects.Basket.SetActive(false);
        return MoneyGenerated;
    }

    public void StartGame(HomelessGameObjects games)
    {
        print("start sword fish game");
        GameObject basket = gameobjects.Basket;
        basket.SetActive(true);
        this.enabled = true;
        gameobjects.TrashHigh.Play();
        gameobjects.TrashMid.Play();
    }

    void OnParticleCollision(GameObject obj)
    {
        if(!gameobjects.SpearedTrash.activeSelf)
        {   
            if (obj.tag == "TrashHigh")
            {
                t2Count++;
            }
            if (obj.tag == "TrashMid")
            {
                t1Count++;
            }
            gameobjects.SpearedTrash.SetActive(true);
        }
        print("collided with a " + obj.tag);
    }

    public void TrashHasBeenPutIntoBasket()
    {
        gameobjects.SpearedTrash.SetActive(false);
    }
}
