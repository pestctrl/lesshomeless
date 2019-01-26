using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunTimer : MonoBehaviour
{
    public Light sun;
    public float secondsInFullDay = 20f;
    [HideInInspector]
    public float timeMultiplier = 1f;
    float sunInitialIntensity;
    public float time;
    public bool active;
    
    void Start()
    {
        active = false;
        sunInitialIntensity = sun.intensity;
    }
    
    public void StartDayTimer()
    {
        time = 0.18f;
        active = true;
    }

    void Update()
    {
        if(active) {
            time += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
            UpdateSun();
            
            if(time > 1) {
                Debug.Log("Day is done");

                active = false;
            }
        }
    }

    void UpdateSun() {
        sun.transform.localRotation = Quaternion.Euler((time * 360f) - 90, 170, 0);
 
        float intensityMultiplier = 1;
        if (time <= 0.23f || time >= 0.75f) {
            intensityMultiplier = 0;
        }
        else if (time <= 0.25f) {
            intensityMultiplier = Mathf.Clamp01((time - 0.23f) * (1 / 0.02f));
        }
        else if (time >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((time - 0.73f) * (1 / 0.02f)));
        }
 
        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
