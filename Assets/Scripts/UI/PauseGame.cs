using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : Dialog
{
    public Text BestScoreText;
    public override void Show()
    {
        base.Show();
        Time.timeScale = 0f;
        if (Prefs.HasNewBestScore)
        {
            if(BestScoreText) BestScoreText.text = "NEW BEST: " + Prefs.BestScore.ToString("n0");
        }
        else
        {
            if(BestScoreText) BestScoreText.text = "Best Score: " + Prefs.BestScore.ToString("n0");
        }
    }
    public override void Close()
    {
        base.Close();
        Time.timeScale = 1f;
    }
    public void BackHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameConst.MAIN_SCENE);
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameConst.GAME_PLAY_SCENE);
    }
}
