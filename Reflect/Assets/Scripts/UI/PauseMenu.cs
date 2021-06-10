using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    private bool IsPaused = false;
    
    // Update is called once per frame
    void Update()
    {
      // If esc is pressed.
      if(Input.GetKeyDown("escape")) 
      {
      	if(IsPaused)
      	{
      		Resume();
      	}
      	else
      	{
      		Pause();
      	}
      }
    }

    public void Resume()
    {
    	PauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	IsPaused = false;
    }

    public void Pause()
    {
    	PauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	IsPaused = true;
    }

    public void ReturnMain()
    {
      SceneManager.LoadScene("MainMenu");
      Time.timeScale = 1f;
      IsPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Reload the level
        Time.timeScale = 1f;
    }

    public bool GetPauseStatus()
    {
      return this.IsPaused;
    }
}
