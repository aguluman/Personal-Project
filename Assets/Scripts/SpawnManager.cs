using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeZ;
    public float spawnPositionX;
    private float startDelay =2;
    private float spawnInterval =1.50f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public GameObject titleScreen;
    public Button restartButton;

    private int score;
    
    private float currentTime = 2f;
    private float startingTime = 60f;

    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        Time.timeScale = 1f;
        StartCoroutine(SpawnObject());
        spawnInterval /= difficulty;
        score = 0;
        UpdateScore(0);
        currentTime = startingTime;
        titleScreen.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(0);
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

    }
    void SpawnRandomAnimal()
    {
        // Randomize the spawn position of the animals.
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));

        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        PauseGame();
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        
    }

    public void RestartGame(int restart)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseGame()
    {
        //Time.timeScale = (Input.GetKeyDown(KeyCode.Escape)) ? 0 : 1;
        Time.timeScale = 0f;
    }
    public void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = "TIMER: " + currentTime.ToString("0");

        if (currentTime <= 0f)
        {
            currentTime = 0;
            GameOver();
        }
    }
   
}
