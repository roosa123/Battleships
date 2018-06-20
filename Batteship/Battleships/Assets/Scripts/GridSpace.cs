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
    //Color newColor = Color.HSVToRGB(0.1f, 0.8f, 0.6f);
    System.Random rand = new System.Random(System.DateTime.Now.Millisecond);

   

    public void SetSpace()
    { 
            buttonText.text = gameController.GetPlayerChoice();
            button.interactable = false;
        //ColorBlock colorBlock = button.colors;
        //colorBlock.pressedColor = newColor;
        //button.colors = colorBlock;
        //button.image.color = Color.black;  //dziala
        //button.image.color = Color.HSVToRGB(0.1f, 0.8f, 0.6f);  ///nie dziala

        float r = rand.Next(1, 100) / 100.0f;
        float g = rand.Next(1, 100) / 100.0f;
        float b = rand.Next(1, 100) / 100.0f;

        button.image.color = new Color(r, g, b);  //dziala

        button.GetComponent<RectTransform>().sizeDelta = new Vector2(40f, 40f);
        button.transform.SetAsLastSibling();


        Vector3 posit = button.transform.position;

        gameController.blockOtherCell(posit);
        

        

        //button.image.rectTransform.sizeDelta = new Vector2(22.2f, 22.2f);
        //button.image.rectTransform.Rotate(new Vector3(0.5f, 0.5f));





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
