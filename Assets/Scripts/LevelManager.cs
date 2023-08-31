using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager :  Singleton<LevelManager>
{
    public BrickManager[] LevelPreflabs;
    int currentLevel;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; } 
    public override void Awake()
    {
        MakeSingleton(true);
    }
    
}
