using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeasonChange : MonoBehaviour
{
    // Handles season changes based on player input (wxcv)
    private Scene currentScene;
    private GameObject player;
    public Animator animator;
    
    //Changements débloqués ?
    public bool unlockedNormal = true;
    public bool unlockedSnow = true;
    public bool unlockedRain = true;
    public bool unlockedHeatWave = true;
    
    //Saison actuelle
    public bool isNormalWeather = true;
    public bool isSnowing = false;
    public bool isRaining = false;
    public bool isHeatWave = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        player = GameObject.Find("Player");
        switch (currentScene.name)
        {
            // Initialise la saison au début du niveau, en fonction du nom de la scène
            case("Level1"):
                break;
            default:
                isNormalWeather = true;
                isSnowing = false;
                isRaining = false;
                isHeatWave = false;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SeasonChangeInput();
    }

    void SaveUnlocks()
    {
        if (unlockedNormal)
        {
            PlayerPrefs.SetInt("unlockedNormal",1);
        }
        else
        {
            PlayerPrefs.SetInt("unlockedNormal",0);
        }
        
        if (unlockedSnow)
        {
            PlayerPrefs.SetInt("unlockedSnow",1);
        }
        else
        {
            PlayerPrefs.SetInt("unlockedSnow",0);
        }
        
        if (unlockedRain)
        {
            PlayerPrefs.SetInt("unlockedRain",1);
        }
        else
        {
            PlayerPrefs.SetInt("unlockedRain",0);
        }
        
        if (unlockedHeatWave)
        {
            PlayerPrefs.SetInt("unlockedHeatWave",1);
        }
        else
        {
            PlayerPrefs.SetInt("unlockedHeatWave",0);
        }
    }
    
    void SeasonChangeInput()
    {
        if (Input.GetButton("BaseWeather") && unlockedNormal && !isNormalWeather)
        {
            Debug.Log("Change to : Normal");
            isNormalWeather = true;
            isSnowing = false;
            isRaining = false;
            isHeatWave = false;
            animator.SetInteger("meteo",0);
            
        }
        else if (Input.GetButton("Snow") && unlockedSnow && !isSnowing)
        {
            Debug.Log("Change to : Snow");
            isNormalWeather = false;
            isSnowing = true;
            isRaining = false;
            isHeatWave = false;
            animator.SetInteger("meteo",3);
        }
        else if (Input.GetButton("Rain") && unlockedRain && !isRaining)
        {
            Debug.Log("Change to : Rain");
            isNormalWeather = false;
            isSnowing = false;
            isRaining = true;
            isHeatWave = false;
            animator.SetInteger("meteo",1);
        }
        else if (Input.GetButton("HeatWave") && unlockedHeatWave && !isHeatWave)
        {
            Debug.Log("Change to : Heat Wave");
            isNormalWeather = false;
            isSnowing = false;
            isRaining = false;
            isHeatWave = true;
            animator.SetInteger("meteo",2);
        }
    }
    
}
