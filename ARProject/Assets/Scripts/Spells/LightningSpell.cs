using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LightningSpell : MonoBehaviour
{
    // Periodically spawn lightning bolts

    private VisualEffect lightningBoltVFX;

    public GameObject lightningBoltPrefab;

    public float damageRadius = 5f;

    private float spawnTimer = 0f;

    private float spawnCooldown = 10f;

    private float playTime = 1f;


    private void Start()
    {
        lightningBoltVFX = lightningBoltPrefab.GetComponent<VisualEffect>();
        lightningBoltVFX.SetFloat("Delay", 10f);
    }

    void Update()
    {
        SpawnLightningBolt();
    }


    private IEnumerator SpawnLightningBolt()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnCooldown)
        {

            lightningBoltVFX.Play();
    
            yield return new WaitForSeconds(playTime);

            lightningBoltVFX.Stop();
            spawnTimer = 0f;

        }
    }
}
