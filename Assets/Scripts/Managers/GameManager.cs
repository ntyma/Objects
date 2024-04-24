using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public ScoreManager scoreManager;

    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private ExplodingEnemy explodingEnemyPrefab;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform testPoint;
    float timer;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemy());
        SpawnExplodingEnemy();
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

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    StartCoroutine(SpawnEnemy());
        //}
    }

    private void SpawnExplodingEnemy()
    {
        ExplodingEnemy exEnemy = Instantiate(explodingEnemyPrefab, testPoint.position, testPoint.rotation);
        exEnemy.SetUpEnemy(1);
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Enemy enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            enemy.SetUpEnemy(1);
        }
        
    }
}
