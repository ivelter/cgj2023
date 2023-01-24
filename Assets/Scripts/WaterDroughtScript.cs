using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDroughtScript : MonoBehaviour
{
    private SeasonChange weather;

    private TilemapCollider2D collider;

    private TilemapRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        weather = GameObject.Find("Player").GetComponent<SeasonChange>();
        collider = GetComponent<TilemapCollider2D>();
        renderer = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!weather.isHeatWave)
        {
            // L'eau reste
            renderer.enabled = true;
            collider.enabled = true;
        }
        else
        {
            // Sinon on la fait disparaitre
            renderer.enabled = false;
            collider.enabled = false;
        }
    }
}
