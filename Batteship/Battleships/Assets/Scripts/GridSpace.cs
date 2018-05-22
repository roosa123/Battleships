using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string playerChoice;
    public void SetSpace()
    {
        buttonText.text = playerChoice;
        button.interactable = false;
    }
}
