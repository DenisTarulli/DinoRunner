using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton (clase accesible globalmente que existe en la escena, pero sólamente una)
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed {  get; private set; }

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Button restartButton;

    private Player player;
    private Spawner spawner;

    private float score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();        

        NewGame();
    }

    public void NewGame()
    {
        Cactus[] cactuses = FindObjectsOfType<Cactus>();

        foreach (var cactus in cactuses)
            Destroy(cactus.gameObject);        

        UpdateHighScore();

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);        
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false); 
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");        
    }

    private void UpdateHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("highScore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
        }

        highScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
    }

}
