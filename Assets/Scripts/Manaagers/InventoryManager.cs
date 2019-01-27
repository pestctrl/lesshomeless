using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public bool haveSqueegee;
    public bool haveSwordfish;
    public float dogFood = 100;
    public float foodVal = 100;
    public float waterVal = 100;
    public float money;

    public bool DogAlive = true;
    public TMP_Text StatusTxt;
    public GameObject Grave;
    public GameObject Dog;

    void Start()
    {
        StartCoroutine(Consume());
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        StatusTxt.text = ("Money- " + money + "\n"
                     + "Food- " + foodVal + "\n"
                     + "Water- " + waterVal + "\n"
                      + "Dog Food- " + dogFood);
    }

    IEnumerator Consume()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            foodVal--;
            waterVal--;
            dogFood--;
            if (dogFood < 30)
            {
                //dog in trouble
                yield return new WaitForSeconds(5);
                GetComponent<SoundMixer>().PlayAudio();
            }
        }
    }

}
