using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DayManager daym;
    public InventoryManager inven;
    public float multiplier = 1;
    float money;
    
    void Start()
    {
        money = 0;
    }

    void Update()
    {
        if(!daym.active)
        {
            //Debug.Log("Hello, new day!");
            
            // Run pre-run stuff and disable script
            daym.BeginDay(inven);
            this.gameObject.SetActive(false);
        }
    }

    public void AddMoney(float f) {
        money += f;
    }

    public void GoToSleep() {
        // Display money earned
        Debug.Log("We can look at the store, buy some cool stuffs, and then the next day will start");
        Debug.Log("You have $" + money + "!!!");
        // Reactivate script and wait for the next day to start
        this.gameObject.SetActive(true);
    }
}
