using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntity : Entity
{
    public override void Attack() {
        if (target == null) return;
        
        Debug.Log(entitySO.entityName + " attacked " + target.GetEntitySO().entityName + " for " + entitySO.damage + " damage");
        target.TakeDamage(entitySO.damage);
    }
}
