using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithPortals : MonoBehaviour
{
    // Start is called before the first frame update
    private LoadScenes scenes;

    private void Start()
    {
        scenes = GetComponent<LoadScenes>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PortalToLevel2"))
        {
            scenes.loadTitle();
        }
    }
}
