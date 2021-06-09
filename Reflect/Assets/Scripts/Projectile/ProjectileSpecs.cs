using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bullets
{
    public class ProjectileSpec
    {
        public float Damage = 20f;
        public float Velocity = 10.0f;
        public AudioClip FireSound; 

        public void SetDamage(float damage)
        {
            Damage = damage;
        }
        public void SetVelocity(float velocity)
        {
            Velocity = velocity;
        }
        public void SetFireSound(AudioClip sound)
        {
            FireSound = sound;
        }
    }
}
