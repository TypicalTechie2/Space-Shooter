using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public Button startGameButton;
    private int score;
    public bool isGameActive;
    private float spawnPosX = 15f;
    private float spawnPosY = 22f;
    private float spawnPosZ = -1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEnemy()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            int index = Random.Range(0, enemyPrefabs.Count);
            Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, -spawnPosX), spawnPosY, spawnPosZ);
            Instantiate(enemyPrefabs[index], spawnPos, enemyPrefabs[index].transform.rotation);
        }
    }
    public void StartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnEnemy());
        score = 0;
        UpdateScore(score);
        startGameButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
