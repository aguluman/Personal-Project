using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    private Button button;
    private SpawnManager spawnManager;
    public int restart;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ToRestart);
    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the button 
    */
    void ToRestart()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        spawnManager.RestartGame(restart);
    }
}
