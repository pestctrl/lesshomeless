using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DayManager daym;
    public InventoryManager inven;
    public Transform[] SpawnPoints = new Transform[4];
    public GameObject[] ResetSpawnObjs = new GameObject[4];
    public GameObject BoxEnvironment;
    public float multiplier = 1;
    public GameObject boxPrefab;
    public Transform outEnviron;

    void Start()
    {
        daym.gmparent = this;
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
    }

    public void AddMoney(float f) {
        inven.money += f;
    }

    public void Sleep()
    {
        print("SLEEP");
        ResetDaySpawns();
        BoxEnvironment.SetActive(false);
        this.gameObject.SetActive(true);

        if(inven.dogFood < 0) {
            inven.DogAlive = false;
        }
        print("Sleep finished"+ this.gameObject.active);
    }

    void ResetDaySpawns()
    {
        for (int i = 0; i < ResetSpawnObjs.Length; i++)
        {
            ResetSpawnObjs[i].transform.localPosition = SpawnPoints[i].localPosition;
            ResetSpawnObjs[i].transform.localRotation = SpawnPoints[i].localRotation;
        }
    }

    public void GoToBox() {
        Debug.Log("We can look at the store, buy some cool stuffs, and then the next day will start");
        Debug.Log("You have $" + inven.money + "!!!");
        this.gameObject.SetActive(false);
        BoxEnvironment.SetActive(true);

    }
}
