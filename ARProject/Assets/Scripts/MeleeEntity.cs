using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntity : Entity
{
    public override void Attack(Entity entity) {
        Debug.Log(entitySO.entityName + " attacked " + entity.GetEntitySO().entityName + " for " + entitySO.damage + " damage");
        entity.TakeDamage(entitySO.damage);
    }
}
