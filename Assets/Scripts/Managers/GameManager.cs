using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public ScoreManager scoreManager;
    public UIManager uiManager;

    //==== PREFABS ====
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private Nuke nukePrefab;
    [SerializeField] private MedicineBox medBoxPrefab;
    [SerializeField] private GunPowerUp gunPowerUpPrefab;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private List<Enemy> enemiesSpawned = new List<Enemy>();
    //[SerializeField] private int GeneratePickUpProbability;

    [SerializeField] private Transform testPoint;


    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void StartGame()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void EndGame()
    {
        StopAllCoroutines();
        DestroyAllEnemies();
        scoreManager.RegisterHighscore();
        uiManager.SetGameOverScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("nuke");
            GeneratePickUp(testPoint.position);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];


            Enemy enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], randomSpawnPoint.position, Quaternion.identity);
            enemiesSpawned.Add(enemy);
            enemy.OnEnemyDeath.AddListener(EnemyDied);

            enemy.SetUpEnemy(1);

            if(enemiesSpawned.Count > 15)
            {
                CleanList();
            }


        }
        
    }

    public void DestroyAllEnemies()
    {
        CleanList();
        foreach (Enemy enemy in enemiesSpawned)
        {
            if (enemy != null)
            {
                enemy.Die();
            }
            
        }
        //empty the list
        enemiesSpawned.RemoveRange(0, enemiesSpawned.Count);
    }

    private void CleanList()
    {
        for (int i = 0; i < enemiesSpawned.Count; i++)
        {
            if (enemiesSpawned[i] == null)
            {
                enemiesSpawned.RemoveAt(i);
            }
        }
    }

    public void EnemyDied(Vector3 enemyPosition)
    {
        scoreManager.IncreaseScore();
        
        GeneratePickUp(enemyPosition);
    }

    private void GeneratePickUp(Vector3 position)
    {
        int n = Random.Range(0, 10);
        if (n < 2)
        {
            Instantiate(nukePrefab, position, Quaternion.identity);
        }
        if(n > 2 && n < 5)
        {
            Instantiate(gunPowerUpPrefab, position, Quaternion.identity);
        }
        if (n > 8)
        {
            Instantiate(medBoxPrefab, position, Quaternion.identity);
        }
        
    }

}
