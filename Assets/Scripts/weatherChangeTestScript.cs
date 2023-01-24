using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class weatherChangeTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SeasonChange season;
    private Text textC;
    void Start()
    {
        textC = GetComponent<Text>();
        season = GameObject.Find("Player").GetComponent<SeasonChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (season.isNormalWeather)
        {
            textC.text = "It's regular weather";
        }
        else if (season.isSnowing)
        {
            textC.text = "It's snowing";
        }
        else if (season.isRaining)
        {
            textC.text = "It's raining";
        }
        else if (season.isHeatWave)
        {
            textC.text = "It's quite hot";
        }
    }
}
