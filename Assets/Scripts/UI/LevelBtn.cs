using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelBtn : MonoBehaviour
{
    public int LevelGoto;
    public bool IsUnlocked;
    public GameObject levelState;
    public Image Icon;
    public Text LevelText;
    public Sprite CheckMark;
    public Sprite LockIcon;

    Button btnComp;

    void Start()
    {
        if (LevelText)
        {
            LevelText.text = (LevelGoto + 1).ToString("00");
        }
        btnComp = GetComponent<Button>();
        btnComp.onClick.AddListener(GotoLevel);

        if (!Prefs.IsGameEntered) 
        {
            Prefs.SetLevelUnlocked(LevelGoto, IsUnlocked);
        }
        if (Prefs.IsLevelUnlocked(LevelGoto))
        {
            if(levelState != null) levelState.SetActive(false);

            if (Prefs.IsLevelPassed(LevelGoto))
            {
                if(levelState)
                    levelState.SetActive(true);
                if(Icon && CheckMark) Icon.sprite = CheckMark;
            }
        }
        else
        {
            if(levelState) levelState.SetActive(true);
            if (Icon) Icon.sprite = LockIcon;
        }
    }
    public void GotoLevel()
    {
        if (Prefs.IsLevelUnlocked(LevelGoto))
        {
            LevelManager.Ins.CurrentLevel = LevelGoto;
            SceneManager.LoadScene(GameConst.GAME_PLAY_SCENE);
        }
        
    }
}
