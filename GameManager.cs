using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public GameObject tittleScreen;

    private float spawnRangeX1 = -3.5f; //
    private float spawnRangeX2 = 3.5f; //
    private float spawnRangeZ1 = 4.5f; //8-12
    private float spawnRangeZ2 = 6.5f; //8-12
    private float spawnHigh = 2;

    private int score;
    private float time = 20;

    public Button restartButton;
    public GameObject enemyPrefab;
    public bool isGameActive;
    public int enemyCount;
    public int waveNumber = 1;

    
    // Start is called before the first frame update
    void Start()
    {

     
    }
    
    // Update is called once per frame
    void Update()
    {

        if (isGameActive)
        {
            UpdateTime();
        }
        
        
    }
    IEnumerator SpawnE()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(0.5f);
            Spawner();
        }
    }
    void SpawnEnemies(int waveNumber)
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX1, spawnRangeX2), spawnHigh, Random.Range(spawnRangeZ1, spawnRangeZ2));
            
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score + "!";
        

    }
    public void UpdateTime()
    {   
        time -=1*Time.deltaTime;


        timerText.text = "Time left: " + Mathf.RoundToInt(time);
        if (time <= 0) GameOver();
    }
    public void Spawner()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            time += 2;
            SpawnEnemies(waveNumber);
            waveNumber++;
            
        }

    }


    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);  

    }

   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        tittleScreen.SetActive(false);
        StartCoroutine(SpawnE());

    }
}
