using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spell
{
    private void Update(){
        TryCast();
    }

    public override void Cast()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, spellSO.attackRange, LayerMask.GetMask("Entities"));

        foreach (Collider hit in hits) {
            Debug.Log("Fire hit " + hit.name);
            if (hit.TryGetComponent<Entity>(out Entity otherEntity)) {
                if (otherEntity == this || otherEntity == null) continue;

                Debug.Log("Fire hit " + otherEntity.GetEntitySO().entityName + " for " + spellSO.damage + " damage");
                otherEntity.TakeDamage(spellSO.damage);
            }
        }
    }

}
