using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSound : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Bark());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Bark()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            GetComponent<SoundMixer>().PlayAudio();
        }
       
    }
}
