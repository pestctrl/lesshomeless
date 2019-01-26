using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public Light sun;

    public GameObject environment;

    public GameManager gmparent;

    public CanShakingGame can;
    public SqueegeeGame squeegee;

    public HomelessGame activeGame;
    
    public float secondsInFullDay = 20f;
    [HideInInspector]
    public float timeMultiplier = 1f;
    float sunInitialIntensity;
    public float time;
    public bool gameSelected;
    public bool active;
    
    void Start()
    {
        active = false;
        sunInitialIntensity = sun.intensity;
    }

    public void BeginDay(InventoryManager inven)
    {
        // Reset timer, and show the environment
        time = 0.15f;
        environment.SetActive(true);

        // Let the gamemanager know that the day is on it's way
        active = true;

        gameSelected = false;

        // Only show these items if purchased
        squeegee.gameObject.SetActive(inven.haveSqueegee);

        // Wait for a game to be selected
        this.gameObject.SetActive(false);
    }

    public void GameSelected(string tag)
    {
        gameSelected = true;
        Debug.Log("The Game has been selected " + tag);

        // Update the day counter and sun cycle
        this.gameObject.SetActive(true);

        // Enable the correct game
        switch(tag) {
            case "Cup": print("Got the can");activeGame = can; break;
            case "Squeege": activeGame = squeegee; break;
        }

        activeGame.StartGame();
    }

    void Update()
    {
        if(active) {
            // Move time forward 
            time += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
            UpdateSun();
            
            if(time > 1) {
                Debug.Log("Day is done");

                Debug.Log("Earned $" + activeGame.GetMoney());
                // Grab money generated
                gmparent.AddMoney(activeGame.GetMoney());

                // Disable all games
                can.enabled = false;
                
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
