using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private AudioClip BackgroundMusic;
    [SerializeField] private AudioClip GameOverSound;

    private AudioSource BGMAudio;
    private PlayerController PlayerScript;

    private bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        this.BGMAudio = this.GetComponent<AudioSource>();
        this.BGMAudio.clip = this.BackgroundMusic;
        this.BGMAudio.loop = true;
        this.BGMAudio.volume = 0.3f;
        this.BGMAudio.Play();

        this.PlayerScript = this.Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.PlayerScript.GetDeadStatus() && !this.GameOver)
        {
            this.GameOver = true;

            this.BGMAudio.Stop();
            this.BGMAudio.clip = this.GameOverSound;
            this.BGMAudio.loop = false;
            this.BGMAudio.volume = 0.3f;
            this.BGMAudio.PlayDelayed(1.75f);
        }
    }
}
