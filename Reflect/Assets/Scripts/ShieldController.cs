using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float Capacity = 100.0f;
    [SerializeField] private float RechargeDelay = 1.0f;
    [SerializeField] private float ParryTimeLimit = 1.0f;
    [SerializeField] private AudioClip BlockSound;
    [SerializeField] private AudioClip PerfectBlockSound;
    [SerializeField] private AudioClip BreakSound;
    [SerializeField] private AudioClip RepairedSound;

    private AudioSource ShieldAudio;

    private float CurrentCapacity = 0.0f;
    private float ParryTimeTrack;
    private float RechargeTimer;
    private bool Broken;

    void Start()
    {
        this.ParryTimeTrack = 0.0f;
        this.CurrentCapacity = this.Capacity;
        this.Broken = false;
        this.ShieldAudio = this.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            if (this.ParryTimeTrack > this.ParryTimeLimit)
            {
                Debug.Log("Blocked!");
                var damage = other.GetComponent<ProjectileController>().GetDamage();
                this.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Perfect Parry!");
                this.ShieldAudio.PlayOneShot(this.PerfectBlockSound, 0.75f);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        this.CurrentCapacity -= damage;

        Debug.Log("Shield Capacity: " + this.CurrentCapacity);

        if (this.CurrentCapacity <= 0.0f)
        {
            Debug.Log("Shield Broken");
            this.Broken = true;
            this.CurrentCapacity = 0.0f;
            this.RechargeTimer = 0.0f;
            this.ShieldAudio.PlayOneShot(this.BreakSound, 0.75f);
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.ShieldAudio.PlayOneShot(this.BlockSound, 0.75f);
        }
    }

    private void Update() 
    {
        if (this.Broken)
        {
            if (this.RechargeTimer < this.RechargeDelay)
            {
                this.RechargeTimer += Time.deltaTime;
            }
            else
            {
                this.Broken = false;
                this.CurrentCapacity = this.Capacity;
                this.ShieldAudio.PlayOneShot(this.RepairedSound, 0.75f);
            }
        }

        if (this.Player.GetComponent<PlayerController>().GetShieldStatus())
        {
            this.ParryTimeTrack += Time.deltaTime;
        }
        else
        {
            this.ParryTimeTrack = 0.0f;
        }
    }

    public void SetCapacity(float capacity)
    {
        this.Capacity = capacity;
        this.CurrentCapacity = capacity;
    }

    public void SetRechargeDelay(float rechargeDelay)
    {
        this.RechargeDelay = rechargeDelay;
    }

    public bool GetBrokenStatus()
    {
        return this.Broken;
    }

    public float GetParryTimeLimit()
    {
        return this.ParryTimeLimit;
    }

    public float GetParryTimeTrack()
    {
        return this.ParryTimeTrack;
    }
}
