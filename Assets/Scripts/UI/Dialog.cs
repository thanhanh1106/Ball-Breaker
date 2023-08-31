using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text titleText;
    public Text contentText;

    
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

    public virtual void UpdateDialog(string title, string content)
    {
        if (titleText)
            titleText.text = title;

        if (contentText)
            contentText.text = content;
    }

    public virtual void UpdateDialog()
    {

    }

    
}
