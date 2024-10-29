using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{

    [SerializeField] protected SpellSO spellSO;
    private float cooldownTimer;

    public void Awake() {
        cooldownTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TryCast();
    }

    public void TryCast() {
        if (cooldownTimer <= 0) {
            Cast();
            cooldownTimer = spellSO.attackCooldown;
        } else {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public virtual void Cast() {
        Debug.Log("Cast in base class Spell");
    }

}
