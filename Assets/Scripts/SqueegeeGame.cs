using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueegeeGame : MonoBehaviour, HomelessGame
{
    float dirtyValue;
    int carsCleaned;
    public float MoneyGenerated;
    public GameManager GM;
    public GameObject Car;
    public GameObject SpawnPos;
    GameObject OldCar = null;
    
    public void StartGame()
    {
        MoneyGenerated = 0;
        NewCar();
    }

    public void NewCar() //bring new car into the field
    {
        GameObject newCar = Instantiate(Car, SpawnPos.transform.position, Quaternion.identity);
        Destroy(OldCar);
        OldCar = newCar;
        dirtyValue = 100;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Window") {
            if (dirtyValue >= 0)
            {
                StartCoroutine(Depreciate());
                Debug.Log(dirtyValue);
            }
            if(dirtyValue <= 0)
            {
                Debug.Log("New Car bitches");
                MoneyGenerated = MoneyGenerated + 2;
                NewCar();
            }
        }
    }

    public float GetMoney()
    {
        return MoneyGenerated;
    }

    IEnumerator Depreciate()
    {
        yield return new WaitForSeconds(.5f);
        dirtyValue = (dirtyValue - 10);
    }
}
