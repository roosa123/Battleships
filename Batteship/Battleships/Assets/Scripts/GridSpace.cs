using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    //public string playerChoice;
    private GameController gameController;
    //private int valueOfChosenShips=0;

   

    public void SetSpace()
    { 
            buttonText.text = gameController.GetPlayerChoice();
            button.interactable = false;
            //valueOfChosenShips++;
            gameController.EndTurn();
    }

    public void theGame()
    {
        // gameController.GetPlayerSide();
       // gameController.EndTurn();
    }

    public void SetGameControllerReference (GameController controller)
    {
        gameController = controller;
    }
}
