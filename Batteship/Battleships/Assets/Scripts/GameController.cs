using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//TODO FOR NOW:
//TODO trafianie przez komputer w ustawione statki
//TODO plansza komputera - losowanie statkow
//TODO zmienianie ruchow graczy komputer - uzytkownik
//TODO gameover 


public class GameController : MonoBehaviour{

    public Text[] buttonPlayerList;
    private string playerChoice = "x";


    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonPlayerList.Length; i++)
        {
            buttonPlayerList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    private void Awake()
    {
       
        SetGameControllerReferenceOnButtons();
    }

    public void EndSetShips()
    {
        for (int i = 0; i < buttonPlayerList.Length; i++)
        {
            buttonPlayerList[i].GetComponentInParent<Button>().interactable = false;
        }
        Debug.Log("Statki zostaly ustawione");
    }

    public string GetPlayerChoice()
    {
        return playerChoice;
    }

    public void EndTurn()
    {
        int value = 0;

        for (int i =0; i < buttonPlayerList.Length; i++)
        {
            if (buttonPlayerList[i].text == playerChoice)
            {
                value++;
                
            }

            if (value == 10)
            {
                EndSetShips();
            }
        }

        Debug.Log("Jeszcze jeden"); 
    }
}
