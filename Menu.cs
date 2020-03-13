using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text HighScore;
    public int HS;
    void Start()
    {
        HS = PlayerPrefs.GetInt("HS", 0);
        HighScore.text = $"HIGH SCORE: {HS}";
        Time.timeScale = 1;
        
    }

    public void StartGame()
    {      
        SceneManager.LoadScene("Game");
    }
}
