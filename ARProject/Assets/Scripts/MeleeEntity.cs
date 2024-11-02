using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeEntity : Entity
{
    private Entity target;

    private void Update() {
        CheckForEntitiesInRange();
        LookAtTarget();
        TryAttack();
    }

    public override void Attack() {
        if (target == null) return;

    
        target.TakeDamage(entitySO.damage);
    }

    private void CheckForEntitiesInRange() {
        target = null;
        bool entityInRange = false;

        Collider[] hits = Physics.OverlapSphere(transform.position, entitySO.attackRange, LayerMask.GetMask("Entities"));

        foreach (Collider hit in hits) {
            if (hit.TryGetComponent<Entity>(out Entity otherEntity)) {
                if (otherEntity == this) continue;
                if (!(this.IsEnemy() ^ otherEntity.IsEnemy())) continue;

                GetAnimator().SetBool("isEnemyInRange", true);
                GetAnimator().SetBool("isMoving", false);
                target = otherEntity;
                entityInRange = true;
                break;
            }
        }

        if (!entityInRange) {
            GetAnimator().SetBool("isEnemyInRange", false);
            GetAnimator().SetBool("isMoving", true);
        }
    }

    private void LookAtTarget() {
        if (target == null) return;

        Vector3 direction = (target.transform.position - transform.position).normalized;
        if (direction != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }
}
