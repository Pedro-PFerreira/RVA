using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePoint : MonoBehaviour {
    [SerializeField] private int maxHealth;
    private int currentHealth;

    public int Health => currentHealth;

    void Awake() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Die() {
        Debug.Log("Defense Point has been destroyed!");
        gameObject.SetActive(false);
    }
}
