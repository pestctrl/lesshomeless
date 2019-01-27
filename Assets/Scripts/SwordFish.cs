using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour, HomelessGame
{
    public ParticleSystem t1;
    public ParticleSystem t2;

    int t1Count;//mid
    int t2Count;//high

    public float GetMoney()
    {
        float MoneyGenerated = (t1Count * 10) + (t2Count * 20);
        t1.Stop();
        t2.Stop();
        this.enabled = false;
        return MoneyGenerated;
    }

    public void StartGame()
    {
        this.enabled = true;
        t1.Play();
        t2.Play();
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "TrashHigh")
        {
            t2Count++;
        }
        if (obj.tag == "TrashMid")
        {
            t1Count++;
        }
        print("collided with a " + obj.tag);
    }
}
