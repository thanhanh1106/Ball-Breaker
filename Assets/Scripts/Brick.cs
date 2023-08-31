using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int Heath;
    public int MinScore;
    public int MaxScore;
    public GameObject BallHittedVfx;

    public int ScoreBonus
    {
        get { return Random.Range(MinScore, MaxScore + 1) * GameManager.Ins.Level; }
    }
    public void Hit()
    {
        Heath--;
        if(Heath <= 0)
        {
            if(BallHittedVfx) Destroy(Instantiate(BallHittedVfx, transform.position, Quaternion.identity), 2);
            GameManager.Ins.AddScore(ScoreBonus);
            if(GameManager.Ins.levelObject != null && GameManager.Ins.levelObject.bricks != null)
            {
                GameManager.Ins.levelObject.bricks.Remove(this);
                if(GameManager.Ins.levelObject.bricks.Count <= 0)
                {
                    Prefs.SetLevelPassed(LevelManager.Ins.CurrentLevel, true);
                    Prefs.SetLevelUnlocked(LevelManager.Ins.CurrentLevel + 1, true);
                    GameGUIManager.Ins.winDialog.Show();
                }
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConst.BALL_TAG))
        {
            Hit();
        }
    }
}
