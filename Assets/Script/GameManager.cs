using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject asteroidSpawner;
    public GameObject gameUiCanvas;
    public GameObject backgroundCanvas;
    public GameObject backgroundMusic;
    public GameObject blackScreen;
    public AudioSource gameOverAudioSource; 

    public void EndGame()
    {    
        
        gameUiCanvas.SetActive(false);
        backgroundMusic.SetActive(false);
        Canvas canvas = backgroundCanvas.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            blackScreen.SetActive(true);
            gameOverAudioSource.Play();
        }
        else
        {
            Debug.LogError("Canvas component not found on backgroundCanvas!");
        }
        asteroidSpawner.GetComponent<Spawner>().StopSpawn();
    }

}