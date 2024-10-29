using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EntitySO : ScriptableObject {
    public string entityName;
    public int maxHealth;
    public int damage;
    public float speed;
    public float attackRange;
    public float attackCooldown;
    public float sightRange;
}
