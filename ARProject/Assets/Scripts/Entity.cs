using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour {

    public event EventHandler<OnHPChangedEventArgs> OnHPChanged;
    public class OnHPChangedEventArgs : EventArgs {
        public float hpNormalized;
    }

    [SerializeField] protected EntitySO entitySO;
    private int health;
    private float attackTimer;
    public bool isEnemy = false;

    public void Awake() {
        attackTimer = 0;
    }


    public void Start() {
        health = entitySO.maxHealth;
        attackTimer = entitySO.attackCooldown;
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

    public void TakeDamage(int damage, Entity attacker) {
        TakeDamage(damage);
    }

    public void TakeDamage(int damage) {
        Debug.Log(entitySO.entityName + " took " + damage + " damage");
        health -= damage;
        if (health <= 0) {
            Die();
        }

        OnHPChanged?.Invoke(this, new OnHPChangedEventArgs {
            hpNormalized = (float)health / entitySO.maxHealth
        });
    }

    public void Die() {
        Debug.Log(entitySO.entityName + " died");
        gameObject.SetActive(false);
    }

    public EntitySO GetEntitySO() {
        return entitySO;
    }

    public void SetEnemy(bool isEnemy) {
        this.isEnemy = isEnemy;
    }

    public bool IsEnemy() {
        return isEnemy;
    }
}
