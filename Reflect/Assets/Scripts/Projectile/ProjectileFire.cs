using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float ProjectileDamage = 20.0f;
    [SerializeField] private float ProjectileFireFrequency = 5.0f;
    [SerializeField] private float ProjectileVelocity = 10.0f;
    [SerializeField] private AudioClip FireSound;

    private PlayerController PlayerScript;
    private EnemyController EnemyScript;

    private float TimeSinceFire;
    private bool PlayerDetected;

    private void Start()
    {
        this.TimeSinceFire = 0.0f;
        this.PlayerDetected = false;
        this.PlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        this.EnemyScript = this.Enemy.GetComponent<EnemyController>();
    }

    private void Update()
    {
        this.TimeSinceFire += Time.deltaTime;
        if (this.TimeSinceFire >= this.ProjectileFireFrequency && this.PlayerDetected && !this.PlayerScript.GetDeadStatus() && !this.EnemyScript.GetDefeatStatus())
        {
            var projectile = Instantiate(this.Projectile, this.transform.position, Quaternion.identity);
            var projectileController = projectile.GetComponent<ProjectileController>();
            projectileController.SetFireSound(this.FireSound);
            projectileController.SetDamage(this.ProjectileDamage);
            projectileController.SetVelocity(this.ProjectileVelocity);
            Destroy(projectile, 30f);

            this.TimeSinceFire = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player")
        {
            if (!this.PlayerDetected)
            {
                Debug.Log("Detect Player");
                this.PlayerDetected = true;
            }
        }
    }
}
