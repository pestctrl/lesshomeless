using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DayManager daym;
    int money;
    
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!daym.active) {
            Debug.Log("Hello, new day!");
            daym.BeginDay();
            this.gameObject.SetActive(false);
        }
    }

    public void WrapUpDay() {
        Debug.Log("The day is over!!");
        money++;
        Debug.Log("You have $" + money + "!!!!");
        this.gameObject.SetActive(true);
    }
}
