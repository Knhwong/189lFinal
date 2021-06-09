using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator Transition;
    [SerializeField] private float TransitionTime = 1f;

    public void LoadNextLevel()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().buildIndex <= 1)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            StartCoroutine(LoadLevel(0));
        }
    }

    public void DeathLoad()
    {
        StartCoroutine(DeathLoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        this.Transition.SetTrigger("Start");

        yield return new WaitForSeconds(this.TransitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator DeathLoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(10.0f);

        this.Transition.SetTrigger("Start");

        yield return new WaitForSeconds(this.TransitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    
}
