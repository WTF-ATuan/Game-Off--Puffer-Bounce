using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    private void Start()
    {
        // Find the button component in the GameObject
        Button backButton = GetComponent<Button>() ;

        // Add a listener to the button
        backButton.onClick.AddListener(GoToMainMenu); 
    }

    private void GoToMainMenu()
    {
        // Replace "MainMenu" with the actual name of your main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
