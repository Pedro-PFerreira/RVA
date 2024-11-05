using System.Collections.Generic;
using UnityEngine;
public class Tornado : Spell {
    [SerializeField] private float pullStrength = 2f; 
    [SerializeField] private float orbitRadius = 3f;
    [SerializeField] private float orbitSpeed = 1f;
    [SerializeField] private float chaosFrequency = 2f;
    [SerializeField] private float chaosAmplitude = 0.5f;
    private List<Entity> pulledEntities = new List<Entity>();
    private bool isPulling;

    private void Start() {
        pullStrength *= transform.localScale.x;
        orbitRadius *= transform.localScale.x;
        orbitSpeed *= transform.localScale.x;
        chaosFrequency *= transform.localScale.x;
        chaosAmplitude *= transform.localScale.x;

        Destroy(gameObject, spellSO.duration);
    }

    private void Update() {
        TryCast();
        if (isPulling) {
            foreach (var entity in pulledEntities) {
                if (entity != null && Vector3.Distance(entity.transform.position, transform.position) <= spellSO.attackRange) {
                    MoveEntity(entity);
                }
            }
        }
    }
    public override void Cast() {
        Collider[] hits = Physics.OverlapSphere(transform.position, spellSO.attackRange, LayerMask.GetMask("Entities"));
        foreach (Collider hit in hits) {
            if (hit.TryGetComponent<Entity>(out Entity otherEntity)) {
                if (otherEntity == this || otherEntity == null) continue;
                if (!otherEntity.IsEnemy()) continue;
                Debug.Log("Tornado hit " + otherEntity.GetEntitySO().entityName + " for " + spellSO.damage + " damage");
                otherEntity.TakeDamage(spellSO.damage);
                StartPull(otherEntity);
            }
        }
    }
    private void StartPull(Entity otherEntity) {
        if (!pulledEntities.Contains(otherEntity)) {
            pulledEntities.Add(otherEntity);
            isPulling = true;
        }
    }
    private void MoveEntity(Entity otherEntity) {
        float angle = Time.time * orbitSpeed;
    
        float chaoticX = Mathf.Cos(angle) * orbitRadius + Mathf.Sin(angle * chaosFrequency) * chaosAmplitude;
        float chaoticZ = Mathf.Sin(angle) * orbitRadius + Mathf.Cos(angle * chaosFrequency) * chaosAmplitude;

        Vector3 orbitPosition = transform.position + new Vector3(chaoticX, 0, chaoticZ);
        
        Vector3 newPosition = Vector3.MoveTowards(otherEntity.transform.position, orbitPosition, pullStrength * Time.deltaTime);

        newPosition.y = otherEntity.transform.position.y;
        otherEntity.transform.position = newPosition;
        
        if (Vector3.Distance(otherEntity.transform.position, orbitPosition) < 0.01f) {
            otherEntity.transform.position = new Vector3(orbitPosition.x, otherEntity.transform.position.y, orbitPosition.z); // Ensure it ends exactly at the orbit position with unchanged y
        }
    }
}