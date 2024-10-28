using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Entity))]
public class Enemy : MonoBehaviour {
    private Transform defensePoint;
    private Entity entity;
    private Rigidbody rb;
    private Entity target;

    private bool isAttacking = false;

    void Awake() {
        entity = GetComponent<Entity>();
        rb = GetComponent<Rigidbody>();

        GameObject defensePointObject = GameObject.FindGameObjectWithTag("DefensePoint");
        if (defensePointObject != null) {
            defensePoint = defensePointObject.transform;
        } else {
            Debug.LogError("DefensePoint not found! Ensure there is a GameObject tagged 'DefensePoint' in the scene.");
        }
    }

    void FixedUpdate() {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget() {
        if (defensePoint == null || entity == null) return;

        if (isAttacking) {
            if (IsAtDefensePoint()) {
                AttackDefensePoint();
            } else {
                MoveTowards(defensePoint);
            }
        } else {
            CheckForEntitiesInRange();

            if (target != null) {
                MoveTowards(target.transform);
            } else {
                MoveTowards(defensePoint);
            }
        }
    }

    private void MoveTowards(Transform targetTransform) {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        float speed = entity.GetEntitySO().speed;

        if (!Physics.Raycast(transform.position, direction, speed * Time.fixedDeltaTime)) {
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        } else if (IsAtDefensePoint()) {
            OnReachDefensePoint();
        }
    }

    private void CheckForEntitiesInRange() {
        target = null;

        Collider[] hits = Physics.OverlapSphere(transform.position, entity.GetEntitySO().attackRange, LayerMask.GetMask("Entities"));

        foreach (Collider hit in hits) {
            if (hit.TryGetComponent<Entity>(out Entity otherEntity)) {
                if (otherEntity == this) continue;
                if (!(entity.IsEnemy() ^ otherEntity.IsEnemy())) continue; // Ensure it's an enemy
                target = otherEntity;
                break;
            }
        }
    }

    private bool IsAtDefensePoint() {
        return Physics.Raycast(transform.position, (defensePoint.position - transform.position).normalized, out RaycastHit hit, 0.1f) && hit.transform.CompareTag("DefensePoint");
    }

    private void AttackDefensePoint() {
        // Implement the logic for attacking the DefensePoint here
    }

    private void OnReachDefensePoint() {
        isAttacking = true;
    }
}
