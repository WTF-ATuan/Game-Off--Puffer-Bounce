using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public string Named;
    void Start()
    {

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(Named);
    }
}
