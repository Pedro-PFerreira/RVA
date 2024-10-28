using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Entity))]
public class Enemy : MonoBehaviour {
    private Transform defensePoint;
    private Entity entity;
    private Rigidbody rb;

    void Awake() {
        // Cache components
        entity = GetComponent<Entity>();
        rb = GetComponent<Rigidbody>();

        // Initialize the defense point
        GameObject defensePointObject = GameObject.FindGameObjectWithTag("DefensePoint");
        if (defensePointObject != null) {
            defensePoint = defensePointObject.transform;
        } else {
            Debug.LogError("DefensePoint not found! Ensure there is a GameObject tagged 'DefensePoint' in the scene.");
        }
    }

    void FixedUpdate() {
        MoveTowardsDefensePoint();
    }

    private void MoveTowardsDefensePoint() {
        if (defensePoint == null || entity == null) return;

        Vector3 direction = (defensePoint.position - transform.position).normalized;
        float speed = entity.GetEntitySO().speed; // Get speed from the EntitySO

        if (CanMoveTowardsDefensePoint(direction, speed)) {
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        } else if (IsAtDefensePoint(direction, speed)) {
            OnReachDefensePoint();
        }
    }

    private bool CanMoveTowardsDefensePoint(Vector3 direction, float speed) {
        // Check if the enemy can move towards the defense point
        return !Physics.Raycast(transform.position, direction, speed * Time.fixedDeltaTime);
    }

    private bool IsAtDefensePoint(Vector3 direction, float speed) {
        // Check if the enemy is at the DefensePoint
        return Physics.Raycast(transform.position, direction, out RaycastHit hit, speed * Time.fixedDeltaTime) && hit.transform.CompareTag("DefensePoint");
    }

    private void OnReachDefensePoint() {
        // Optional: Implement behavior when reaching the DefensePoint (e.g., attacking)
        Debug.Log("Enemy has reached the DefensePoint!");
    }

    public Entity GetEntity() {
        return entity;
    }
}
