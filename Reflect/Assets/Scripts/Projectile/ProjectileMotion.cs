using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public void Fire(Vector2 MuzzleVelocity)
    {
        this.GetComponent<Rigidbody2D>().AddForce(MuzzleVelocity);
    }

    public void Reflect(Vector2 MuzzleVelocity)
    {
        var reflectVelocity = -2 * MuzzleVelocity;
        this.GetComponent<Rigidbody2D>().AddForce(reflectVelocity);
    }
}
