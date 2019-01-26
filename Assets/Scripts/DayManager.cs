using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public Light sun;

    public GameObject environment;

    public GameManager gmparent;

    public CanShakingGame can;

    public HomelessGame activeGame;
    
    public float secondsInFullDay = 20f;
    [Range(0,1)]
    public float currentTimeOfDay = 0;
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

    public void BeginDay()
    {
        // Reset timer, and show the environment
        time = 0.15f;
        environment.SetActive(true);

        // Wait for a game to be selected
        this.gameObject.SetActive(false);
    }

    public void GameSelected(string tag)
    {
        Debug.Log("The Game has been selected " + tag);

        // Update the day counter and sun cycle
        this.gameObject.SetActive(true);
        active = true;

        // Enable the can game
        can.enabled = true;
        activeGame = can;
    }

    void Update()
    {
        if(active) {
            // Move time forward 
            time += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
            UpdateSun();
            
            if(time > 1) {
                Debug.Log("Day is done");

                // Grab money generated
                gmparent.AddMoney(activeGame.getMoney());

                // Finish Day
                active = false;
                EndDay();
            }
        }
    }

    void EndDay() {
        environment.SetActive(false);
        gmparent.GoToSleep();
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
