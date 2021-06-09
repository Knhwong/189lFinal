using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bullets;

public class ProjectileFactory : MonoBehaviour
{
    //Any projectile can be built from any factory.
    //Enemy -> Projectile Specs + Frequency -> Factory -> Projectile Prefab.
    [SerializeField] private GameObject projectile;
    

    public void Build(Vector3 position, ProjectileSpec spec)
    {
        if (spec.FireSound) {
            var projectile = Instantiate(this.projectile, position, Quaternion.identity);
            var projectileController = projectile.GetComponent<ProjectileController>();
            projectileController.SetFireSound(spec.FireSound);
            projectileController.SetDamage(spec.Damage);
            projectileController.SetVelocity(spec.Velocity);
            Destroy(projectile, 30f);
        }
    }
}
