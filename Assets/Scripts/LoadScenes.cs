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
    private void Start()
    {
        title = SceneManager.GetSceneByName("TitleScreen").buildIndex;
        placeholderLevel = SceneManager.GetSceneByName("TestLevel").buildIndex;
        level1 = SceneManager.GetSceneByName("level1").buildIndex;
    }

    public void loadTitle()
    {
        SceneManager.LoadScene(title);
    }
    
    public void loadLevel1()
    {
        SceneManager.LoadScene(level1);
    }

    public void loadPlaceholder()
    {
        SceneManager.LoadScene(placeholderLevel);
    }
}
