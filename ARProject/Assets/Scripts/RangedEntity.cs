using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEntity : Entity
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed = 1f;

    public override void Attack() {
        Debug.Log(entitySO.entityName + " has thrown a projectile");
        ThrowProjectile(transform.forward);
    }

    public void ThrowProjectile(Vector3 dir) {
        GameObject projectileInstance = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        //projectileInstance.transform.LookAt(projectileSpawnPoint.position + dir);
        projectileInstance.GetComponent<Rigidbody>().velocity = dir * projectileSpeed;
        projectileInstance.SetActive(true);
    }
}
