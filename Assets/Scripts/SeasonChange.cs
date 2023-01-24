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

    void SeasonChangeInput()
    {
        if (Input.GetButton("BaseWeather") && unlockedNormal && !isNormalWeather)
        {
            Debug.Log("Change to : Normal");
            isNormalWeather = true;
            isSnowing = false;
            isRaining = false;
            isHeatWave = false;
        }
        else if (Input.GetButton("Snow") && unlockedSnow && !isSnowing)
        {
            Debug.Log("Change to : Snow");
            isNormalWeather = false;
            isSnowing = true;
            isRaining = false;
            isHeatWave = false;
        }
        else if (Input.GetButton("Rain") && unlockedRain && !isRaining)
        {
            Debug.Log("Change to : Rain");
            isNormalWeather = false;
            isSnowing = false;
            isRaining = true;
            isHeatWave = false;
        }
        else if (Input.GetButton("HeatWave") && unlockedHeatWave && !isHeatWave)
        {
            Debug.Log("Change to : Heat Wave");
            isNormalWeather = false;
            isSnowing = false;
            isRaining = false;
            isHeatWave = true;
        }
    }
    
}
