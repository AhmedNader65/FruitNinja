using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string highScoreKey = "highScore";
    [Header("Score Elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;


    [Header("Game Over Elements")]

    public GameObject gameOverPanel;


    [Header("Sounds")]

    public AudioClip[] sliceSounds;
    public AudioClip bombSound;
    private AudioSource audioSource;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        GetHighScore();
    }
    private void GetHighScore(){
        highScore = PlayerPrefs.GetInt(highScoreKey);
        highScoreText.text = "Best: "+highScore.ToString();
    }
    public void IncreaseScore(int addedPoints){
        score += addedPoints;
        scoreText.text = score.ToString();
        if(score > highScore){
            highScore = score;
            PlayerPrefs.SetInt(highScoreKey,highScore);
            highScoreText.text = "Best: "+ highScore.ToString();
        }
    }

    public void onBombHit(){
        // Stops any movement in game
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayRandomSliceSound(){
        AudioClip randomSound = sliceSounds[Random.Range(0,sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

    public void PlayBombSound(){
        audioSource.PlayOneShot(bombSound);
    }
}
