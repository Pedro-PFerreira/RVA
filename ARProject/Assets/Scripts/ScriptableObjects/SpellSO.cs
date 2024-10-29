using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu()]
public class SpellSO : ScriptableObject
{
    public string entityName;
    public int damage;
    public float attackRange;	
    public float attackCooldown;
    
}
