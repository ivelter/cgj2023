using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadScenes : MonoBehaviour
{
    private int title;
    private int placeholderLevel;
    private int level1;
    private Button b;

    public void loadTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void loadPlaceholder()
    {
        SceneManager.LoadScene("Placeholder");
    }
}
