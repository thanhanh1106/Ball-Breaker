using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public Text ScoreText;
    public Text TimeCountingDown;

    public WinDialog winDialog;
    public GameOver gameOver;

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString("000");
    }
    public void UpdateTimeCountingDown(int timeCount)
    {
        if (TimeCountingDown != null) TimeCountingDown.text = timeCount.ToString();
        if(timeCount < 0)
        {
            if(TimeCountingDown != null) TimeCountingDown.enabled = false;
        }
    }
    public void BackToHome()
    {
        SceneManager.LoadScene(GameConst.MAIN_SCENE);
    }


}
