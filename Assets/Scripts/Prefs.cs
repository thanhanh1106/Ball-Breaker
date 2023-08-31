using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static bool HasNewBestScore;
    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0); 
    }
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key,0) == 1;  
    }
    public static int BestScore
    {
        set
        {
            if(PlayerPrefs.GetInt(GameConst.PREFS_BEST_SCORE,0) < value)
            {
                HasNewBestScore = true;
                PlayerPrefs.SetInt(GameConst.PREFS_BEST_SCORE, value);
            } else HasNewBestScore = false;
        }
        get => PlayerPrefs.GetInt(GameConst.PREFS_BEST_SCORE, 0);
    }
    public static bool IsLevelUnlocked(int level)
    {
        return GetBool(GameConst.PREFS_LEVEL_UNLOCKED +  level);
    }
    public static void SetLevelUnlocked(int level,bool value)
    {
        SetBool(GameConst.PREFS_LEVEL_UNLOCKED + level, value);
    }
    public static bool IsLevelPassed(int level)
    {
        return GetBool(GameConst.PREFS_LEVEL_PASSED + level);
    }
    public static void SetLevelPassed(int level,bool value)
    {
        SetBool(GameConst.PREFS_LEVEL_PASSED + level, value);
    }
    public static bool IsGameEntered
    {
        get => GetBool(GameConst.PREFS_IS_GAME_ENTERD);
        set => SetBool(GameConst.PREFS_IS_GAME_ENTERD, value);
    }
     
}
