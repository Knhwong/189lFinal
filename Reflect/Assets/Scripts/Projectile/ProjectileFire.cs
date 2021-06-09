using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bullets;

public class ProjectileFire : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float projectileDamage = 20.0f;
    [SerializeField] private float projectileFireFrequency = 5.0f;
    [SerializeField] private float projectileVelocity = 10.0f;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private ProjectileFactory projectileFactory;

    private PlayerController playerScript;
    private EnemyController enemyScript;

    private float timeSinceFire;
    private bool playerDetected;

    private void Start()
    {
        //Intializing Variables, need to get parent methods from this.enemy.
        this.timeSinceFire = 0.0f;
        this.playerDetected = false;
        this.playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        this.enemyScript = this.enemy.GetComponent<EnemyController>();
    }

    private void Update()
    {
        this.timeSinceFire += Time.deltaTime;
        if (this.timeSinceFire >= this.projectileFireFrequency && this.playerDetected && !this.playerScript.GetDeadStatus() && !this.enemyScript.GetDefeatStatus())
        {
            //Build Specs
            var spec = new ProjectileSpec();
            spec.SetVelocity(this.projectileVelocity);
            spec.SetDamage(this.projectileDamage);
            spec.SetFireSound(this.fireSound);
            //Actual creation of projectile done here.
            this.projectileFactory.Build(this.transform.position, spec);
            this.timeSinceFire = 0.0f;
        }
    }

    //Player Tracking for Projectile
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player")
        {
            if (!this.playerDetected)
            {
                this.playerDetected = true;
            }
        }
    }
}
