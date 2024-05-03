using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public ScoreManager scoreManager;

    [SerializeField] private Enemy[] enemyPrefabs;

    [SerializeField] private Transform[] spawnPoints;
    float timer;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void EndGame()
    {
        StopAllCoroutines();
        scoreManager.RegisterHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {

        }

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];


            Enemy enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], randomSpawnPoint.position, Quaternion.identity);
            enemy.SetUpEnemy(1);
        }
        
    }
}
