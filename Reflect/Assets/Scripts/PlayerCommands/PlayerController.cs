using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float PlayerHealth = 100.0f;
    [SerializeField] private float JumpForce = 20.0f;
    [SerializeField] private float Speed = 10.0f;
    [SerializeField] private GameObject Shield;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip MoveSound;
    [SerializeField] private AudioClip HoldShieldSound;
    [SerializeField] private GameObject LevelLoader;
    [SerializeField] private GameObject PauseUI;
    // [SerializeField] private HealthBar HealthBar;

    private IPlayerCommand MoveLeft;
    private IPlayerCommand MoveRight;
    private IPlayerCommand Jump;

    private Animator PlayerAnimator;
    private Rigidbody2D PlayerRigidBody2D;
    private AudioSource PlayerAudio;

    private float CurrentHealth;
    private bool GameOver = false;
    private bool ShieldUp = false;
    private bool FacingRight = true;
    private bool KnockBack = false;
    private bool IsOnGround = true;

    private float TakeHitTimer = 0.0f;

    private void Start()
    {
        this.PlayerAnimator = this.GetComponent<Animator>();
        this.PlayerRigidBody2D = this.GetComponent<Rigidbody2D>();
        this.PlayerAudio = this.GetComponent<AudioSource>();

        this.MoveLeft = ScriptableObject.CreateInstance<MoveLeftCommand>();
        this.MoveRight = ScriptableObject.CreateInstance<MoveRightCommand>();
        this.Jump = ScriptableObject.CreateInstance<JumpCommand>();

        this.CurrentHealth = this.PlayerHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ("Projectile" == other.tag && !this.GameOver)
        {
            var damage = other.GetComponent<ProjectileController>().GetDamage();
            this.TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ("Enemy" == other.gameObject.tag && !this.GameOver)
        {
            this.KnockBack = true;
            if (this.transform.position.x < other.transform.position.x)
            {
                this.PlayerRigidBody2D.AddForce(new Vector2(-10.0f, 10.0f), ForceMode2D.Impulse);
            }
            else
            {
                this.PlayerRigidBody2D.AddForce(new Vector2(10.0f, 10.0f), ForceMode2D.Impulse);
            }
            this.TakeDamage(10.0f);
        }

        if ("Floor" == other.gameObject.tag)
        {
            this.PlayerAnimator.SetBool("Jumping", false);
            this.IsOnGround = true;
            this.KnockBack = false;
        }
    }

    private void TakeDamage(float damage)
    {
        this.CurrentHealth -= damage;


        if (this.CurrentHealth <= 0.0f)
        {
            Debug.Log("Game Over");
            this.GameOver = true;
            this.CurrentHealth = 0.0f;
            this.PlayerAnimator.SetBool("Dead", this.GameOver);
            this.PlayerAudio.PlayOneShot(this.DeathSound, 0.5f);

            var levelLoader = this.LevelLoader.GetComponent<LevelLoader>();
            levelLoader.DeathLoad();
        }
        else
        {
            this.TakeHitTimer = 0.0f;
            this.PlayerAnimator.SetBool("Damaged", true);
            this.PlayerAudio.PlayOneShot(this.HitSound, 0.5f);
        }
    }

    private void Update()
    {
        var isPaused = this.PauseUI.GetComponent<PauseMenu>().GetPauseStatus();
        var isTransitioning = this.LevelLoader.GetComponent<LevelLoader>().GetTransitionStatus();

        if (!isTransitioning && !isPaused)
        {
            this.CheckMovement();
            this.CheckShieldHolding();
            this.SetTakeHitAnimation();

            var movement = Mathf.Abs(Input.GetAxis("Horizontal"));

            this.PlayerAnimator.SetFloat("Velocity", movement);

            if (movement != 0.0f && this.IsOnGround && !this.PlayerAudio.isPlaying)
            {
                this.PlayerAudio.PlayOneShot(this.MoveSound, 0.5f);
            }

            // this.HealthBar.SetHealth(this.CurrentHealth);
        }
    }

    private void Flip()
    {
        this.FacingRight = !this.FacingRight;
        this.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void CheckMovement()
    {
        if (Input.GetButtonDown("Jump") && !this.KnockBack && this.IsOnGround && !this.GameOver)
        {
            this.Jump.Execute(this.gameObject, this.JumpForce);
            this.IsOnGround = false;
            this.PlayerAnimator.SetBool("Jumping", true);
            this.PlayerAudio.PlayOneShot(this.JumpSound, 0.5f);
        }

        if(Input.GetAxis("Horizontal") > 0.01 && !this.KnockBack && !this.GameOver)
        {
            var movement = Input.GetAxis("Horizontal");
            var detail = movement * Time.deltaTime * this.Speed;
            this.MoveRight.Execute(this.gameObject, detail);

            if (!this.FacingRight)
            {
                this.Flip();
            }
        }

        if(Input.GetAxis("Horizontal") < -0.01 && !this.KnockBack && !this.GameOver)
        {
            var movement = Input.GetAxis("Horizontal");
            var detail = movement * Time.deltaTime * this.Speed;
            this.MoveLeft.Execute(this.gameObject, detail);

            if (this.FacingRight)
            {
                this.Flip();
            }
        }
    }

    private void CheckShieldHolding()
    {
        if (!this.ShieldUp || this.GameOver)
        {
            this.Shield.GetComponent<SpriteRenderer>().enabled = false;
            this.Shield.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            this.Shield.GetComponent<SpriteRenderer>().enabled = true;
            this.Shield.GetComponent<CapsuleCollider2D>().enabled = true;
        }

        if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
        {
            if (!this.Shield.GetComponent<ShieldController>().GetBrokenStatus())
            {
                if (!this.ShieldUp)
                {
                    this.PlayerAudio.PlayOneShot(this.HoldShieldSound, 0.5f);
                }
                this.ShieldUp = true;
            }
            else
            {
                this.ShieldUp = false;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            this.ShieldUp = false;
        }
    }

    private void SetTakeHitAnimation()
    {
        if (this.TakeHitTimer >= 0.125f)
        {
            this.PlayerAnimator.SetBool("Damaged", false);
        }
        else
        {
            this.TakeHitTimer += Time.deltaTime;
        }
    }

    public void SetIsOnGround(bool isOnGround)
    {
        this.IsOnGround = isOnGround;
    }

    public bool GetShieldStatus()
    {
        return this.ShieldUp;
    }

    public bool GetDeadStatus()
    {
        return this.GameOver;
    }

    public float GetCurrentHealth()
    {
        return this.CurrentHealth;
    }
}
