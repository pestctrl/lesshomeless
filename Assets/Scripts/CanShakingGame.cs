using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShakingGame : MonoBehaviour
{
    public GameObject Can;
    public float coinMultiplier;
    public bool coinGameStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coinGameStart)
        {
            coinMultiplier = GetMultiplier();
        }
    }

    float GetMultiplier()
    {
        float mult;
        Vector3 lastVelocity = Can.GetComponent<Rigidbody>().velocity;

        mult = lastVelocity.magnitude * 10;
        return mult;

    }
}
