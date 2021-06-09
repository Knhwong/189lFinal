using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    
    private float Velocity = 10.0f;
    private float Damage = 20.0f;
    private AudioClip FireSound;

    private AudioSource ProjectileAudio;

    private Vector2 PlayerDirection;
    private bool Reflected;

    // Start is called before the first frame update
    void Start()
    {
        this.Reflected = false;
        this.ProjectileAudio = this.GetComponent<AudioSource>();
        var player = GameObject.FindWithTag("Player");

        // Taking the normalized vector that points from projectile to player, and scaling it by the Projectile Velocity
        this.PlayerDirection = (player.transform.position - this.gameObject.transform.position).normalized * this.Velocity;
        this.GetComponent<ProjectileMotion>().Fire(this.PlayerDirection);
        this.ProjectileAudio.PlayOneShot(this.FireSound, 0.75f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.GetComponent<PlayerController>().GetDeadStatus())
            {
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Shield" && !this.Reflected)
        {
            var parryTimeLimit = other.GetComponent<ShieldController>().GetParryTimeLimit();
            var parryTimeTrack = other.GetComponent<ShieldController>().GetParryTimeTrack();

            if (parryTimeTrack <= parryTimeLimit)
            {
                this.Reflected = true;
                this.GetComponent<ProjectileMotion>().Reflect(this.PlayerDirection);
            }
            else
            {
                this.Reflected = false;
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Enemy")
        {
            if (this.Reflected)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public float GetDamage()
    {
        return Damage;
    }

    public bool GetReflectedStatus()
    {
        return this.Reflected;
    }

    public void SetDamage(float damage)
    {
        this.Damage = damage;
    }

    public void SetVelocity(float velocity)
    {
        this.Velocity = velocity;
    }

    public void SetFireSound(AudioClip fireSound)
    {
        this.FireSound = fireSound;
    }
}
