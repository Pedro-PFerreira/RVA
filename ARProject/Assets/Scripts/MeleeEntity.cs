using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntity : Entity
{
    private Entity target;

    private void Update() {
        CheckForEntitiesInRange();
        TryAttack();
    }

    public override void Attack() {
        if (target == null) return;
        
        Debug.Log(entitySO.entityName + " attacked " + target.GetEntitySO().entityName + " for " + entitySO.damage + " damage");
        target.TakeDamage(entitySO.damage);
    }

    private void CheckForEntitiesInRange() {
        target = null;

        Collider[] hits = Physics.OverlapSphere(transform.position, entitySO.attackRange, LayerMask.GetMask("Entities"));

        foreach (Collider hit in hits) {
            if (hit.TryGetComponent<Entity>(out Entity otherEntity)) {
                if (otherEntity == this) continue;
                target = otherEntity;
                break;
            }
        }
    }
}
