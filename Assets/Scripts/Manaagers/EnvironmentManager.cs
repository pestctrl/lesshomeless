using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
   // public GameObject[] CarSpawns = new GameObject[2];
    public GameObject[] CarTypes;
    public GameObject Person;
    int delayLowerBound = 2;
    int delayUpperBound = 6;
    int timeDestroy = 10;
    float thrust = 120f; 
    // Start is called before the first frame update
    void OnEnable()
    {
        delayLowerBound = 2;
        delayUpperBound = 6;
        StartCoroutine(BackAndFourthCycle(GameObject.FindGameObjectsWithTag("CarSpawn")[0]));

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator BackAndFourthCycle(GameObject spawn)
    {
            bool spawned = false;
            while (!spawned)
            {
                GameObject obj = CarTypes[(int)Random.Range(0,3)];
                GameObject instance = Instantiate(obj, spawn.transform.position, spawn.transform.rotation);
                spawned = true;
                //randomize color of instance
                //randomize type of car
                instance.GetComponent<Rigidbody>().AddForce(-1 * obj.transform.up * thrust, ForceMode.Force);
                StartCoroutine(DestroyObjDelay(instance, timeDestroy));
                yield return new WaitForSeconds(Random.Range(2, 6));
                spawned = false;
            }  
    }
    IEnumerator DestroyObjDelay(GameObject obj, float timeDestroy)
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(obj);

    }

}
