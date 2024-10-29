using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spell
{
    
    private void Update(){
        TryCast();
    }

    public override void Cast()
    {
        GetComponent<Collider>().enabled = true;

        // Check positions of Lightning and transform;
        Debug.Log("Lightning casted at " + transform.position);


        Collider[] hits = Physics.OverlapSphere(transform.position, spellSO.attackRange, LayerMask.GetMask("Entities"));

        foreach (Collider hit in hits) {
            if (hit.TryGetComponent<Entity>(out Entity otherEntity)) {
                if (otherEntity == this || otherEntity == null) continue;

                Debug.Log("Lightning hit " + otherEntity.GetEntitySO().entityName + " for " + spellSO.damage + " damage");
                otherEntity.TakeDamage(spellSO.damage);
                break;
            }
        }

        GetComponent<Collider>().enabled = false;
    }

}
