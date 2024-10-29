using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(Entity), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {
    private Transform defensePoint;
    private Entity entity;
    private NavMeshAgent navMeshAgent;
    private Entity target;

    private bool isAttacking = false;

    void Awake() {
        entity = GetComponent<Entity>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        GameObject defensePointObject = GameObject.FindGameObjectWithTag("DefensePoint");
        if (defensePointObject != null) {
            defensePoint = defensePointObject.transform;
        } else {
            Debug.LogError("DefensePoint not found! Ensure there is a GameObject tagged 'DefensePoint' in the scene.");
        }
    }

    void Update() {
        if (isAttacking) {
            AttackDefensePoint();
            LookTowards(defensePoint.position - transform.position);
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
        if (targetTransform != null && navMeshAgent.isOnNavMesh) {
            navMeshAgent.SetDestination(targetTransform.position);
            LookTowards(targetTransform.position - transform.position);
        }
    }

    private void LookTowards(Vector3 direction) {
        if (direction != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }

    private void CheckForEntitiesInRange() {
        target = null;
        Collider[] hits = Physics.OverlapSphere(transform.position, entity.GetEntitySO().attackRange, LayerMask.GetMask("Entities"));

        foreach (Collider hit in hits) {
            if (hit.TryGetComponent<Entity>(out Entity otherEntity)) {
                if (otherEntity == this) continue;
                if (!(entity.IsEnemy() ^ otherEntity.IsEnemy())) continue;
                target = otherEntity;
                break;
            }
        }
    }

    private void AttackDefensePoint() {
        Debug.Log("Enemy is attacking the DefensePoint!");
    }
}
