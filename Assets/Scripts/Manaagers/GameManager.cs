using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DayManager daym;
    public InventoryManager inven;
    public GameObject BoxEnvironment;
    public float multiplier = 1;
    public float money;
    float timewait;
    
    void Start()
    {
        money = 0;
        daym.gmparent = this;
    }

    void Update()
    {
        if(!daym.active)
        {
            Debug.Log("Hello, new day!");
            
            // Run pre-run stuff and disable script
            daym.BeginDay(inven);
        }
        if(timewait > 0) {
            timewait -= 0.01f;
        }
    }

    public void AddMoney(float f) {
        money += f;
    }

    public void Sleep()
    {
        this.gameObject.SetActive(true);
        BoxEnvironment.SetActive(false);
        daym.BeginDay(inven);
    }

    public void GoToBox() {
        Debug.Log("We can look at the store, buy some cool stuffs, and then the next day will start");
        Debug.Log("You have $" + money + "!!!");
        this.gameObject.SetActive(false);
        BoxEnvironment.SetActive(true);

    }
}
