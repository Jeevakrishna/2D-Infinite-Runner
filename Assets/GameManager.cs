using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    int score;
    public TMP_Text scoreText;

    public GameObject GameOverPanel;
    public TMP_Text currentText;
    public TMP_Text highScoreText;
    public Button restartButton;
    public Camera mainCam;
    public Image backgroundImage;
    private int randomIndex;
    public Color[] colorToChange;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        randomIndex = Random.Range(0, colorToChange.Length);
        ChangeColor();
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        GameOverPanel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
    }


    public void Update()
    {
        ApplyColor();
    }
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        randomIndex = Random.Range(0, colorToChange.Length);
        ApplyColor();
    }

    public void GameOver()
    {
         FindObjectOfType<AudioManager>().Play("GameOver");
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",score);
        }

        PlayerPrefs.SetInt("Score" ,score);
        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        GameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    void ApplyColor()
    {
        if(score >= 2)
        {
            ChangeColor();

        }
        else if(score == 5)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        mainCam.backgroundColor = colorToChange[randomIndex];
        backgroundImage.color = colorToChange[randomIndex];
    }
}
