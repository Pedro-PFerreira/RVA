using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private RangedEntity thrower;

    private void Update() {
        transform.position += transform.forward * thrower.GetProjectileSpeed() * Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, thrower.GetProjectileSpeed() * Time.deltaTime, LayerMask.GetMask("Entities"))) {
            if (hit.collider.gameObject.TryGetComponent<Entity>(out Entity hitEntity)) {
                hitEntity.TakeDamage(thrower.GetEntitySO().damage);
                Destroy(this.gameObject);
            }
        }
    }


    public Entity GetThrower() {
        return thrower;
    }
}
