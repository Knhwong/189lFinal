using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float EnemyHealth = 100.0f;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject ProjectileSpawn;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private AudioClip DeathSound;

    private AudioSource EnemyAudio;

    private float CurrentHealth;
    private bool Defeated;

    // Start is called before the first frame update
    void Start()
    {
        this.CurrentHealth = this.EnemyHealth;
        this.Defeated = false;
        this.EnemyAudio = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ("Projectile" == other.tag)
        {
            var Reflected = other.GetComponent<ProjectileController>().GetReflectedStatus();

            if (Reflected)
            {
                var damage = other.GetComponent<ProjectileController>().GetDamage();
                this.TakeDamage(damage);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        this.CurrentHealth -= damage;

        Debug.Log("Enemy Health: " + this.CurrentHealth);

        if (this.CurrentHealth <= 0.0f)
        {
            Debug.Log("Enemy Defeated");
            this.Defeated = true;
            // this.PlayerAnimator.SetBool("Dead", this.GameOver);
            this.EnemyAudio.PlayOneShot(this.DeathSound, 0.75f);
            Destroy(this.gameObject, 1.0f);
        }
        else
        {
            // this.TakeHitTimer = 0.0f;
            // this.PlayerAnimator.SetBool("Damaged", true);
            this.EnemyAudio.PlayOneShot(this.HitSound, 0.75f);
        }
    }

    public bool GetDefeatStatus()
    {
        return this.Defeated;
    }
}
