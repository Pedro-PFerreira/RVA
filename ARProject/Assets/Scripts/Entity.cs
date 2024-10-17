using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour {
    [SerializeField] protected EntitySO entitySO;
    private int health;
    private float attackTimer;

    public void Awake() {
        attackTimer = 0;
    }


    public void Start() {
        health = entitySO.maxHealth;
    }

    protected virtual void Update() {
        TryAttack();
    }


    public void TryAttack() {
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

    public EntitySO GetEntitySO() {
        return entitySO;
    }
}
