using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FireScript : MonoBehaviour
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
        if (weather.isSnowing || weather.isRaining)
        {
            // Faire disparaitre le feu
            renderer.enabled = false;
            collider.enabled = false;
        }
        else
        {
            // Faire apparaître le feu
            renderer.enabled = true;
            collider.enabled = true;
        }
    }
}
