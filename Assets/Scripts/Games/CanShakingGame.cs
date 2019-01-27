using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShakingGame : MonoBehaviour, HomelessGame
{
    public float coinMultiplier;
    public float MoneyGenerated;

    public float GetMoneyAndEndGame()
    {
        this.enabled = false;
        return MoneyGenerated;
    }

    public void StartGame(HomelessGameObjects objects) {
        this.enabled = true;
        MoneyGenerated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MeasureWait());
    }


    IEnumerator MeasureWait()
    {
        float mult;
        float lastPos = Mathf.Abs(transform.position.magnitude);
        yield return new WaitForSeconds(.4f);
        float Pos = Mathf.Abs(transform.position.magnitude);

        float power = Mathf.Abs(Pos - lastPos);
        if (power > .10)
        {
            //GetComponent<SoundMixer>().PlayAudio();
        }

        mult = power * 50;
        
        MoneyGenerated = MoneyGenerated + (mult * 1 * Time.deltaTime);
        //print(MoneyGenerated);

    }
}
