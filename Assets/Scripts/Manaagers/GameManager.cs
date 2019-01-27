using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DayManager daym;
    public InventoryManager inven;
    public Transform[] SpawnPoints = new Transform[5];
    public GameObject[] ResetSpawnObjs = new GameObject[5];
    public GameObject BoxEnvironment;
    public float multiplier = 1;
    float timewait;
    
    void Start()
    {
        daym.gmparent = this;
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) //testing resets
        {
            print("space pressed");
            ResetDaySpawns();
        }

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
        inven.money += f;
    }

    public void Sleep()
    {
        print("SLEEP");
        ResetDaySpawns();
        BoxEnvironment.SetActive(false);
        this.gameObject.SetActive(true);
    }

    void ResetDaySpawns()
    {
        for (int i = 0; i < ResetSpawnObjs.Length; i++)
        {
            

            ResetSpawnObjs[i].transform.localPosition = SpawnPoints[i].localPosition;
            ResetSpawnObjs[i].transform.localRotation = SpawnPoints[i].localRotation;

            //if (ResetSpawnObjs[i].transform.tag == "Box")
            //{
            //    ResetSpawnObjs[i].transform.rotation = new Quaternion(-90, 0, -90, 0);
            //}
            
        }
    }

    public void GoToBox() {
        Debug.Log("We can look at the store, buy some cool stuffs, and then the next day will start");
        Debug.Log("You have $" + inven.money + "!!!");
        this.gameObject.SetActive(false);
        BoxEnvironment.SetActive(true);

    }
}
