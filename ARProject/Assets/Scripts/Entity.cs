using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour {
    [SerializeField] protected EntitySO entitySO;
    private SphereCollider attackRangeCollider;
    private int health;
    protected Entity target;
    private float attackTimer;

    public void Awake() {
        attackRangeCollider = gameObject.GetComponent<SphereCollider>();
        attackTimer = 0;
    }


    public void Start() {
        health = entitySO.maxHealth;
        attackRangeCollider.radius = entitySO.attackRange;
    }

    public void Update() {
        // There is a target in range
        if (attackTimer <= 0) {
            Attack();
            attackTimer = entitySO.attackCooldown;
        } else {
            attackTimer -= Time.deltaTime;
        }

    }

    public virtual void Attack() {
        Debug.Log("Attack in base class Entity");
    }

    public void TakeDamage(int damage) {
        Debug.Log(entitySO.entityName + " took " + damage + " damage");
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Debug.Log(entitySO.entityName + " died");
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent<Entity>(out Entity otherEntity)) {
            target = otherEntity;
        } else if (other.gameObject.TryGetComponent<Projectile>(out Projectile projectile)) {
            if (projectile.GetThrower() != this) {
                TakeDamage(projectile.GetThrower().GetEntitySO().damage);
                Destroy(projectile.gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.TryGetComponent<Entity>(out Entity otherEntity)) {
            target = null;
        }
    }

    public EntitySO GetEntitySO() {
        return entitySO;
    }
}
