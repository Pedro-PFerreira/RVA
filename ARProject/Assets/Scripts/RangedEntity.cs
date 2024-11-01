using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEntity : Entity
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed = 1f;

    public override void Attack() {
        ThrowProjectile(transform.forward);
    }

    public void ThrowProjectile(Vector3 dir) {
        GetAnimator().SetBool("isEnemyInRange", true);
        GetAnimator().SetBool("isMoving", false);
        GameObject projectileInstance = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        projectileInstance.SetActive(true);
    }

    public float GetProjectileSpeed() {
        return projectileSpeed;
    }
}
