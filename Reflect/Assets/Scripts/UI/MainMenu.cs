using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
    	// Load the next scene (Level 1).
    	SceneManager.LoadScene("LevelOne");
    }
    public void QuitGame()
    {
    	Debug.Log("Quit Successfully.");
    	Application.Quit();
    }
}
