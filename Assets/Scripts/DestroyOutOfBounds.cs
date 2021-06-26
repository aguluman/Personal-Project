using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private SpawnManager spawnManager;
    private float topBound = -21;
    private float lowerBound = 23;

    void Start() 
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < topBound)
        {
            //destroy the projectile(apple) one they pass the lowerbound height
            Destroy(gameObject);
        }   
        else if (transform.position.x > lowerBound)
        {
            //to display gameover in the console window
            Debug.Log("Game Over!");
            spawnManager.GameOver();
            //destroy animals once they pass the topbound length
            Destroy(gameObject);
        }
    }
}
