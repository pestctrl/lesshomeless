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
    public HomelessGameObjects games;
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
        games.SqueegeeGame.gameObject.SetActive(inven.haveSqueegee);
        games.SwordFishGame.gameObject.SetActive(inven.haveSwordfish);

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
            case "Cup": activeGame = games.CanShakingGame; break;
            case "Squeege": activeGame = games.SqueegeeGame; break;
            case "Swordfish": activeGame = games.SwordFishGame; break;
        }

        activeGame.StartGame(games);
        sun.StartDayTimer();
    }

    void Update()
    {
        if(active) {
            if(!sun.active) {
                //Debug.Log("Earned $" + activeGame.GetMoney());
                // Grab money generated
                float money = activeGame.GetMoneyAndEndGame();
                gmparent.AddMoney(money);
                
                // Finish Day
                active = false;
                Debug.Log("Day finished");
            }
        }
    }

    public void EndDay() {
        if(!sun.active) {
            environment.SetActive(false);
            gmparent.GoToBox();
            foreach (GameObject Car in GameObject.FindGameObjectsWithTag("Car"))
            {
                Destroy(Car);
            }
        }
    }
}
