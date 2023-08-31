using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGUIManager :Singleton<MainGUIManager>
{
    public LevelSelectionDialog SelectionDialog;
    public GameObject GameTitle;
    public GameObject PlayBtn;
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void PlayGame()
    {
        if (SelectionDialog) SelectionDialog.Show();
        if (GameTitle) GameTitle.SetActive(false);
        if(PlayBtn) PlayBtn.SetActive(false);
    }

}
