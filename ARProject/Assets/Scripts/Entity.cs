using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Entity : MonoBehaviour {
    public event EventHandler<OnHPChangedEventArgs> OnHPChanged;
    public class OnHPChangedEventArgs : EventArgs {
        public float hpNormalized;
    }

    [SerializeField] protected EntitySO entitySO;
    private int health;
    private float attackTimer;
    private NavMeshAgent navMeshAgent;
    public bool isEnemy = false;

    public void Awake() {
        attackTimer = 0;
        GetComponent<Rigidbody>().isKinematic = true;

        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null) {
            navMeshAgent.speed = entitySO.speed;
            navMeshAgent.stoppingDistance = entitySO.attackRange;
        }
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
    }

    public void TakeDamage(int damage, Entity attacker) {
        TakeDamage(damage);
    }

    public void TakeDamage(int damage) {

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
        if (entitySO.entityName == "HolyBara"){
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOverMenu");
        }
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
