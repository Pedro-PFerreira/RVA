using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {
    [System.Serializable]
    public class EnemyType {
        public GameObject prefab;
        public int spawnWeight;
    }

    public List<EnemyType> enemyTypes;     // List of different enemy types with weights
    public Transform[] spawnPoints;        // Assign spawn points here in the Inspector
    public DifficultyLevel difficulty;     // Select difficulty level from the Inspector

    public GameObject enemyList;

    private int monsterCount;

    private float spawnDelay;

    private bool allMonstersSpawned;

    private Transform[] enemies;

    public enum DifficultyLevel {
        Easy,
        Medium,
        Hard
    }

    void Start() {
        UpdateDifficulty();
        SetDifficultyParameters();
        StartCoroutine(SpawnMonsters());
        allMonstersSpawned = false;
    }

    void Update(){
        if (AllEnemiesDead()){
            SceneManager.LoadScene("VictoryMenu");
        }
    }

    void UpdateDifficulty(){
        string diff_str = PlayerPrefs.GetString("Difficulty");
        Debug.Log("Setting Difficulty to " + diff_str + "...");
        if (diff_str == "Easy"){
            difficulty = DifficultyLevel.Easy;
        } 
        else if (diff_str == "Medium"){
            difficulty = DifficultyLevel.Medium;
        }
        else{
            difficulty = DifficultyLevel.Hard;
        }
    }

    void SetDifficultyParameters() {
        switch (difficulty) {
            case DifficultyLevel.Easy:
                monsterCount = 5;
                spawnDelay = 4f;
                break;
            case DifficultyLevel.Medium:
                monsterCount = 7;
                spawnDelay = 3f;
                break;
            case DifficultyLevel.Hard:
                monsterCount = 9;
                spawnDelay = 2f;
                break;
        }
    }

    IEnumerator SpawnMonsters() {
        for (int i = 0; i < monsterCount; i++) {
            GameObject selectedEnemy = GetRandomEnemy(); // Get a random enemy based on weight
            int spawnIndex = i % spawnPoints.Length; // Cycle through spawn points
            GameObject instance = Instantiate(selectedEnemy, spawnPoints[spawnIndex].position, Quaternion.identity, enemyList.transform);
            instance.AddComponent<Enemy>();
            instance.GetComponent<Entity>().SetEnemy(true);

            yield return new WaitForSeconds(spawnDelay); // Wait before spawning the next monster
        }
        allMonstersSpawned = true;
        if (allMonstersSpawned){Debug.Log("All monsters have spawned!");}
    }

    bool AllEnemiesDead(){
        enemies = enemyList.GetComponentsInChildren<Transform>();
        return enemies.Length - 1 == 0 && allMonstersSpawned;
    }

    GameObject GetRandomEnemy() {
        int totalWeight = 0;

        // Calculate total weight
        foreach (var enemy in enemyTypes) {
            totalWeight += enemy.spawnWeight;
        }

        // Pick a random value between 0 and totalWeight
        int randomValue = Random.Range(0, totalWeight);
        int cumulativeWeight = 0;

        // Select the enemy based on random weight
        foreach (var enemy in enemyTypes) {
            cumulativeWeight += enemy.spawnWeight;
            if (randomValue < cumulativeWeight) {
                return enemy.prefab;
            }
        }

        // Fallback in case of an error
        return enemyTypes[0].prefab;
    }
}
