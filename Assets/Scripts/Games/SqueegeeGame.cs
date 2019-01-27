using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueegeeGame : MonoBehaviour, HomelessGame
{
    float dirtyValue;
    int carsCleaned;
    public float MoneyGenerated;
    HomelessGameObjects objects;
    GameObject Car;
    GameObject SpawnPos;
    GameObject OldCar = null;
    
    public void StartGame(HomelessGameObjects objects)
    {
        MoneyGenerated = 0;
        Car = objects.Car;
        SpawnPos = objects.CarSpawnPoint;
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

    public float GetMoneyAndEndGame()
    {
        return MoneyGenerated;
    }

    IEnumerator Depreciate()
    {
        yield return new WaitForSeconds(.5f);
        dirtyValue = (dirtyValue - 10);
    }
}
