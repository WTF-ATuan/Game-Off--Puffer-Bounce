using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (other.CompareTag("Bullet")) 
        {
            // Call a method to handle the collection
            Collect();
        }
    }
    void Collect()
    {

        gameObject.SetActive(false);
    }
}
