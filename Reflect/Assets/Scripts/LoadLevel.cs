using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelLoader;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Next Level!");
            var levelLoader = this.LevelLoader.GetComponent<LevelLoader>();
            levelLoader.LoadNextLevel();
        }
    }
}
