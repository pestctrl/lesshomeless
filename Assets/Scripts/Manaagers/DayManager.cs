using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    // Interacts with
    public GameObject environment;
    public GameManager gmparent;
    public SunTimer sun;

    // Triggers
    public CanShakingGame can;
    public SqueegeeGame squeegee;
    public HomelessGame activeGame;

    // State
    public bool active;
    
    void Start()
    {
        active = false;
    }

    public void BeginDay(InventoryManager inven)
    {
        // Show the environment
        environment.SetActive(true);

        // Let the gamemanager know that the day is on it's way
        active = true;
        activeGame = null;

        // Only show these items if purchased
        squeegee.gameObject.SetActive(inven.haveSqueegee);


        // Wait for a game to be selected
        this.gameObject.SetActive(false);
    }

    public void GameSelected(string tag)
    {
        Debug.Log("The Game has been selected " + tag);

        // Update the day counter and sun cycle
        this.gameObject.SetActive(true);

        // Enable the correct game
        switch(tag) {
            case "Cup": /*print("Got the can")*/;
                activeGame = can;
                break;
            case "Squeege": activeGame = squeegee; break;
        }

        activeGame.StartGame();
        sun.StartDayTimer();
    }

    void Update()
    {
        if(active) {
            if(!sun.active) {
                Debug.Log("Earned $" + activeGame.GetMoney());
                // Grab money generated
                gmparent.AddMoney(activeGame.GetMoney());

                // Disable all games
                can.enabled = false;
                squeegee.enabled = false;
                
                // Finish Day
                active = false;
            }
        }
    }

    public void EndDay() {
        environment.SetActive(false);
        gmparent.GoToBox();
        foreach (GameObject Car in GameObject.FindGameObjectsWithTag("Car"))
        {
            Destroy(Car);
        }
    }
}
