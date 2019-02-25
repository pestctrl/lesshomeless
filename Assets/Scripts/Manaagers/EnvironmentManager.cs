using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public Transform[] CarSpawns = new Transform[2];
    public Transform[] PeopleSpawns = new Transform[2];

    public GameObject[] CarTypes;
    public GameObject[] People;
    public bool spawnCars;
    public bool spawnPeople;
    // Start is called before the first frame update
    void OnEnable()
    {
       
        foreach(var spawnPoint in CarSpawns)
        {
            StartCoroutine(BackAndFourthCycle(spawnPoint, CarTypes, 10, -1 * CarTypes[0].transform.up * 240, 2, 6));
        }
        foreach (var spawnPoint in PeopleSpawns)
        {
            StartCoroutine(BackAndFourthCycle(spawnPoint, People, 10, People[0].transform.forward * 120, 4, 7));
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator BackAndFourthCycle(Transform spawn, GameObject[] candidates, int timeDestroy, Vector3 thrust, int dlb, int dub)
    {
            bool spawned = false;
            while (!spawned)
            {
                GameObject obj = candidates[(int)Random.Range(0,candidates.Length)];
                GameObject instance = Instantiate(obj, spawn.transform.position, spawn.transform.rotation);
                spawned = true;
                //randomize color of instance
                //randomize type of car
                instance.GetComponent<Rigidbody>().AddForce(thrust, ForceMode.Force);
                StartCoroutine(DestroyObjDelay(instance, timeDestroy));
                yield return new WaitForSeconds(Random.Range(dlb,dub));
                spawned = false;
            }  
    }
    IEnumerator DestroyObjDelay(GameObject obj, float timeDestroy)
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(obj);

    }

}
