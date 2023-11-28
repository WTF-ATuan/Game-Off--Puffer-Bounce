using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public string Named; 
    void Start()
    {
        
    }
      public void ChangeScene()
    {
        SceneManager.LoadScene(Named);
    }
    
}

