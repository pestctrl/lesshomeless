using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public bool haveSqueegee;
    public bool haveSwordfish;
    public int numDogfoods;
    public float foodVal = 100;
    public float waterVal = 100;
    public float money;

    void Start()
    {
        StartCoroutine(Consume());
    }

    void Update()
    {
        
    }

    IEnumerator Consume()
    {
        yield return new WaitForSecondsRealtime(5);
        foodVal--;
        waterVal--;
    }

}
