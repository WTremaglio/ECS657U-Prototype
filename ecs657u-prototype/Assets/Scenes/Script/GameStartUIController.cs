using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartUIController : MonoBehaviour
{
    public GameObject instructionPanel; 
    public Button startButton; 

    void Start()
    {
        
        instructionPanel.SetActive(true);

        // listener for start button
        startButton.onClick.AddListener(StartGame);
    }

    
    void StartGame()
    {
        instructionPanel.SetActive(false); // Hide instructions
        
    }
}