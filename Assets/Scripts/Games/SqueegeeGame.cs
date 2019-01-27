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

    GameObject newCar = null;
    
    public void StartGame(HomelessGameObjects objects)
    {
        MoneyGenerated = 0;
        Car = objects.Car;
        SpawnPos = objects.CarSpawnPoint;
        NewCar();
    }

    public void NewCar() //bring new car into the field
    {
        newCar = Instantiate(Car, SpawnPos.transform.position, SpawnPos.transform.localRotation);
      
        //newCar.GetComponent<Animator>().Play("CarApproachSqueegee");
        newCar.GetComponent<Animator>().SetBool("CarClean", false);
        
        OldCar = newCar;
        dirtyValue = 100;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Window") {
            if (dirtyValue >= 0)
            {
                //newCar.GetComponent<Animator>().Play("CarIdle");
                
                StartCoroutine(Depreciate());
                Debug.Log(dirtyValue);
            }
            if(dirtyValue <= 0)
            {
                //newCar.GetComponent<Animator>().Play(("CarLeave"));
                OldCar.GetComponent<Animator>().SetBool("CarClean", true);
                Destroy(OldCar);
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
