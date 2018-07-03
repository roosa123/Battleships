using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpaceEnemy : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string playerChoice = "o";
    public string shipOrNot;
    private GameController gameController;

    public void ShotInEnemyShips()
    {
        
        //buttonText.text = playerChoice;
        button.interactable = false;
       
        if (button.GetComponentInChildren<Text>().text == "x")
        {

            Instantiate(gameController.Particle, button.transform.position,
              button.transform.rotation);

            button.image.color = Color.black;
            button.GetComponentInChildren<Text>().color = Color.white;
            button.GetComponentInChildren<Text>().text = "O";

            gameController.Particle.transform.SetAsLastSibling();
            Instantiate(gameController.Particle, button.transform.position,
                button.transform.rotation);
            
            Instantiate(gameController.Particle, button.transform.position,
                button.transform.rotation);
            gameController.Particle.transform.SetAsLastSibling();
            gameController.playerGoal++;
           
        }


        gameController.yourTurn.color = Color.black;
        gameController.ComputerMove();
        gameController.IsGameOver();
    }

    public void SetGameControllerReferenceEnemy(GameController controller)
    {
        gameController = controller;
    }
}

