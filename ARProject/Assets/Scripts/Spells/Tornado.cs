using System.Collections.Generic;
using UnityEngine;

public class Tornado : Spell {
    [SerializeField] private float pullStrength = 2f; // Strength of the pull
    [SerializeField] private float orbitRadius = 3f; // Radius of the orbit around the tornado
    [SerializeField] private float orbitSpeed = 1f; // Speed of the orbiting effect
    [SerializeField] private float chaosFrequency = 2f; // Frequency of chaos in the orbit path
    [SerializeField] private float chaosAmplitude = 0.5f; // Amplitude of chaos in the orbit path

    private List<Entity> pulledEntities = new List<Entity>(); // List of entities being pulled
    private bool isPulling; // Flag to check if pulling is active

    private void Update() {
        TryCast();

        if (isPulling) {
            foreach (var entity in pulledEntities) {
                // Check if the entity is still within the tornado's proximity
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
            isPulling = true; // Set pulling active
        }
    }

    private void MoveEntity(Entity otherEntity) {
        // Calculate the angle based on time to create an orbiting effect
        float angle = Time.time * orbitSpeed;

        // Determine the chaotic orbit position around the tornado's center using sine and cosine for added chaos
        float chaoticX = Mathf.Cos(angle) * orbitRadius + Mathf.Sin(angle * chaosFrequency) * chaosAmplitude;
        float chaoticZ = Mathf.Sin(angle) * orbitRadius + Mathf.Cos(angle * chaosFrequency) * chaosAmplitude;

        // Calculate the new chaotic orbit position
        Vector3 orbitPosition = transform.position + new Vector3(chaoticX, 0, chaoticZ);

        // Calculate the new position with constant interpolation based on pull strength
        Vector3 newPosition = Vector3.MoveTowards(otherEntity.transform.position, orbitPosition, pullStrength * Time.deltaTime);

        // Keep the y value unchanged
        newPosition.y = otherEntity.transform.position.y;

        otherEntity.transform.position = newPosition;

        // Check if the entity has reached the orbit position
        if (Vector3.Distance(otherEntity.transform.position, orbitPosition) < 0.01f) {
            otherEntity.transform.position = new Vector3(orbitPosition.x, otherEntity.transform.position.y, orbitPosition.z); // Ensure it ends exactly at the orbit position with unchanged y
        }
    }
}
