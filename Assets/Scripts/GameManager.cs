using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DayManager daym;
    public InventoryManager inven;
    public float multiplier = 1;
    float money;
    float timewait;
    
    void Start()
    {
        money = 0;
        daym.gmparent = this;
        boxenv.SetActive(false);
    }

    void Update()
    {
        if(!daym.active)
        {
            Debug.Log("Hello, new day!");
            
            // Run pre-run stuff and disable script
            daym.BeginDay(inven);
            this.gameObject.SetActive(false);
        }
        if(timewait > 0) {
            timewait -= 0.01f;
        }
    }

    public void AddMoney(float f) {
        money += f;
    }

    public void GoToBox() {
        Debug.Log("We can look at the store, buy some cool stuffs, and then the next day will start");
        Debug.Log("You have $" + money + "!!!");
        
    }

    public void StartNewDay() {
        this.gameObject.SetActive(true);
        boxenv.SetActive(false);
    }
}
