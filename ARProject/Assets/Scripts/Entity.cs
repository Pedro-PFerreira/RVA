using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour {
    [SerializeField] protected EntitySO entitySO;
    private SphereCollider attackRangeCollider;
    private int health;
    
    public void Awake() {
        attackRangeCollider = gameObject.GetComponent<SphereCollider>();
    }

    
    public void Start() {
        health = entitySO.maxHealth;
        attackRangeCollider.radius = entitySO.attackRange;
    }

    public virtual void Attack(Entity entity) {
        Debug.LogError("Attack method not implemented");
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
