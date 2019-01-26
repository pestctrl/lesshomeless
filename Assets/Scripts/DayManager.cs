using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public Light sun;

    public GameObject environment;

    public GameManager gmparent;

    public CanShakingGame can;
    
    public float secondsInFullDay = 20f;
    [Range(0,1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;
    float sunInitialIntensity;
    public float time;
    public bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        sunInitialIntensity = sun.intensity;
    }

    public void BeginDay()
    {
        active = true;
        time = 0.15f;
        environment.SetActive(true);
        this.gameObject.SetActive(false);
        GameSelected("Hello, world");
    }

    public void GameSelected(string tag)
    {
        Debug.Log("The Game has been selected");
        this.gameObject.SetActive(true);
        can.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(active) {
            time += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
            UpdateSun();
            
            if(time > 1) {
                gmparent.AddMoney(can.MoneyGenerated);
                environment.SetActive(false);
                gmparent.WrapUpDay();
                active = false;
            }
        }
    }

    void UpdateSun() {
        sun.transform.localRotation = Quaternion.Euler((time * 360f) - 90, 170, 0);
 
        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f) {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }
 
        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
