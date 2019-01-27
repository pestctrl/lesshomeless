using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public bool haveSqueegee;
    public bool haveSwordfish;
    public int Dogfood;
    public float foodVal = 100;
    public float waterVal = 100;
    public float money;
    public List<GameObject> Dogs;
    int numDogs;

    public TMP_Text statusText;

    void Start()
    {
        StartCoroutine(Consume());
        StartCoroutine(DogProduction());
    }

    void Update()
    {
        UpdateText();
        numDogs = Dogfood % 25;
        print("number of dogs " + numDogs);
        
        if (foodVal <= 0 || waterVal <= 0)
        {
            //death
        }
    }

    void UpdateText()
    {
        statusText.SetText("Money- " + money + "\n" +
                           "Food- " + foodVal + "\n" +
                           "Water- " + waterVal + "\n" +
                           "Dog Food- " + Dogfood);
    }

    IEnumerator DogProduction()
    {
        while (true)
        {

            foreach (GameObject dog in Dogs)
            {
                yield return new WaitForSecondsRealtime(5);
                money = money + 10;
            }
        }
    }
   

    IEnumerator Consume()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(3);
            foodVal--;
            waterVal--;
            foreach (GameObject dog in Dogs)
            {
                Dogfood--;
            }
        }
       
    }

}
