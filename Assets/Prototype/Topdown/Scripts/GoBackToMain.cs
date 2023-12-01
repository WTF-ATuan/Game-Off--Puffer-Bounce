using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMain : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";

    void Update()
    {
        // Check for the back key (Escape key in this case)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the main menu scene
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
