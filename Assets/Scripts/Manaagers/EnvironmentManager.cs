﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
   // public GameObject[] CarSpawns = new GameObject[2];
    public GameObject Car;
    public GameObject Person;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(BackAndFourthCycle(GameObject.FindGameObjectsWithTag("CarSpawn")[0], Car, 120, 10, Random.Range(4, 7)));

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator BackAndFourthCycle(GameObject spawn, GameObject obj, float thrust, float timeDestroy, float timeSpawnDelay)
    {
            bool spawned = false;
            while (!spawned)
            {
                GameObject instance = Instantiate(obj, spawn.transform.position, spawn.transform.rotation);
                spawned = true;
                //randomize color of instance
                //randomize type of car
                instance.GetComponent<Rigidbody>().AddForce(-1 * obj.transform.up * thrust, ForceMode.Force);
                StartCoroutine(DestroyObjDelay(instance, timeDestroy));
                yield return new WaitForSeconds(timeSpawnDelay);
                spawned = false;
            }  
    }
    IEnumerator DestroyObjDelay(GameObject obj, float timeDestroy)
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(obj);

    }

}
