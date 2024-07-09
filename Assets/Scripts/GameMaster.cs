using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public GameObject restartPanel;
    public GameObject high;
    // public Text score;

    // private bool asLost;

    [Header("Score")]
    public Text scoreText;
    public Text bestText;

    int score = 0;
    int bestScore;
    bool countScore = true;

    // private void Update()
    // {
    //     if (asLost == false) {
    //         score.text = Time.time.ToString("F0");
    //     }
    
    // }
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();
        StartCoroutine(UpdateScore());
    }

    public void GameOver() {
        // asLost = true;
        // score = null;
        countScore = false;
        if(score>bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
            high.SetActive(true);
        }
        Invoke("Delay", 1.5f);
    }

    void Delay() {
        restartPanel.SetActive(true);
    }

    public void GoToGameScene() {
        SceneManager.LoadScene("Title");
    }

    public void GoToTitle() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void L1() {
        SceneManager.LoadScene("Main1");
    }

    public void L2() {
        SceneManager.LoadScene("Main2");
    }

    public void L3() {
        SceneManager.LoadScene("Main3");
    }

    public void L4() {
        SceneManager.LoadScene("Main4");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("Instruction");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if(score>bestScore)
            {
                scoreText.text = score.ToString();
                bestText.text = score.ToString();
            }
            else 
            {
                scoreText.text = score.ToString();
            }
        }
    }
}
