using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public Wave[] waves;
    public Enemy[] enemy;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    public Text waveText;
    public float waveNumber;
    //public GameObject player;

    Wave currentWave;
    public int currentWaveNumber;

    int enemiesRemainingToSpawn;
    public  int enemiesRemainingAlive;
    float nextSpawnTime;

    public float money;
    public Text moneyText;


    public float cost;
    public bool canBuy;
    public bool canUpgrade;



    public float timeLeft = 5.0f;


    public Text EnemiesRemaining;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        moneyText.text = (" " + money);
       // EnemiesRemaining.text = ("" +enemiesRemainingAlive);

        if (enemiesRemainingAlive == 0 )
        {
            countdown();
        }

        if (timeLeft <= 0)
        {
            NextWave();
        }

        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Find a random index between zero and one less than the number of spawn points.
            int EnemyIndex = Random.Range(0, enemy.Length);
            int twoIndex = Random.Range(0, 2);
            int threeIndex = Random.Range(0, 3);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            // Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            if (currentWaveNumber==1)
            {
                Enemy spawnedEnemy = Instantiate(enemy[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 2)
            {
                Enemy spawnedEnemy = Instantiate(enemy[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 3)
            {
                Enemy spawnedEnemy = Instantiate(enemy[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 4)
            {
                Enemy spawnedEnemy = Instantiate(enemy[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 5)
            {
                Enemy spawnedEnemy = Instantiate(enemy[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 6)
            {
                Enemy spawnedEnemy = Instantiate(enemy[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 7)
            {
                Enemy spawnedEnemy = Instantiate(enemy[twoIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 8)
            {
                Enemy spawnedEnemy = Instantiate(enemy[twoIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 9)
            {
                Enemy spawnedEnemy = Instantiate(enemy[twoIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 10)
            {
                Enemy spawnedEnemy = Instantiate(enemy[2], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 11)
            {
                Enemy spawnedEnemy = Instantiate(enemy[2], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }


            if (currentWaveNumber == 12)
            {
                Enemy spawnedEnemy = Instantiate(enemy[2], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 13)
            {
                Enemy spawnedEnemy = Instantiate(enemy[3], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 14)
            {
                Enemy spawnedEnemy = Instantiate(enemy[3], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 15)
            {
                Enemy spawnedEnemy = Instantiate(enemy[3], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 16)
            {
                Enemy spawnedEnemy = Instantiate(enemy[threeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 17)
            {
                Enemy spawnedEnemy = Instantiate(enemy[threeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

            if (currentWaveNumber == 18)
            {
                Enemy spawnedEnemy = Instantiate(enemy[threeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as Enemy;
                spawnedEnemy.OnDeath += OnEnemyDeath;
            }

        }
    }

    public void OnEnemyDeath()
    {
        enemiesRemainingAlive--;
        
    }

    public void countdown()
    {
        timeLeft -= Time.deltaTime;
    }

    public void turnOffTimer()
    {
        timeLeft = 5;
    }

    public void NextWave()
    {
        currentWaveNumber++;
        turnOffTimer();
        waveText.text = ("Wave: " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
        money ++;
        //money += currentWave.enemyCount;

        //if (GameObject.FindGameObjectWithTag("Player") == null)
        //{
        //    Instantiate(player, new Vector3(3,6,-305) , transform.rotation);
        //    Debug.Log("yahhhhhh");
        //}
    }


    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
        //Enemy[] enemy;
        

    }

    public void buyCrossbow()
    {
        if(money>=3)
        {
            money -= 3;
            canBuy = true;
        }
    }

    public void buyCannon()
    {
        if (money >= 5)
        {
            money -= 5;
            canBuy = true;
        }
    }

    public void buyLauncher()
    {
        if (money >= 7)
        {
            money -= 7;
            canBuy = true;
        }
    }

    public void sellCannon()
    {
        money += 1;
    }


    public void upgradeCannon2()
    {
        if (money>=6)
        {
            money -= 6;
            canUpgrade = true;
        }
        else
        {
            canUpgrade = false;
        }
    }

    public void upgradeCannon3()
    {
        if (money >= 7)
        {
            money -= 7;
            canUpgrade = true;
        }
        else
        {
            canUpgrade = false;
        }
    }

    public void upgradeCrossbow2()
    {
        if (money >= 4)
        {
            money -= 4;
            canUpgrade = true;
        }
        else
        {
            canUpgrade = false;
        }
    }

    public void upgradeCrossbow3()
    {
        if (money >= 5)
        {
            money -= 5;
            canUpgrade = true;
        }
        else
        {
            canUpgrade = false;
        }
    }

    public void upgradeLauncher2()
    {
        if (money >= 8)
        {
            money -= 8;
            canUpgrade = true;
        }
        else
        {
            canUpgrade = false;
        }
    }

    public void upgradeLauncher3()
    {
        if (money >= 9)
        {
            money -= 9;
            canUpgrade = true;
        }
        else
        {
            canUpgrade = false;
        }
    }
}