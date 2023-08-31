using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int TimeDelay;
    int currentTimeDelay;

    public Ball Ball;

    int level;
    int score;
    public BrickManager levelObject;

    public int Level { get => level;}
    public BrickManager LevelObject { get => levelObject;}

    public override void Awake()
    {
        MakeSingleton(false);
    }
    void Start()
    {
        currentTimeDelay = TimeDelay;
        LoadLevel();
        StartCoroutine(CountingDown());
        Prefs.HasNewBestScore = false;
        Prefs.IsGameEntered = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    IEnumerator CountingDown()
    {
        while (currentTimeDelay >= 0) 
        {
            yield return new WaitForSeconds(1f);
            currentTimeDelay--;
            GameGUIManager.Ins.UpdateTimeCountingDown(currentTimeDelay);
        }
        
        if (Ball)
        {
            Ball.Trigger();
        }
    }
    void LoadLevel()
    {
        BrickManager[] levelPrefabs = LevelManager.Ins.LevelPreflabs;
        if (levelPrefabs != null && levelPrefabs.Length > 0)
        {
            if (LevelManager.Ins.CurrentLevel >= 0 && LevelManager.Ins.CurrentLevel < levelPrefabs.Length)
            {
                BrickManager levelPrefab = levelPrefabs[LevelManager.Ins.CurrentLevel];
                if (levelPrefab != null)
                {
                    level = LevelManager.Ins.CurrentLevel + 1;
                    levelObject = Instantiate(levelPrefab, new Vector3(0, 7, -0.0804343f), Quaternion.identity);
                }
            }
        }
    }
    public void AddScore(int score)
    {
        this.score += score;
        Prefs.BestScore = this.score;
        GameGUIManager.Ins.UpdateScore(this.score);
    }
}
