using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string playerChoice = "X";

    public void setShip()
    {
        buttonText.text = playerChoice;
        button.interactable = false;
        
    }


    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
