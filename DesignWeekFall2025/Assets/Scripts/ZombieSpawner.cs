using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public GameObject zombiePrefab;
    public GameObject[] spawns;
    public GameObject[] entrances;
    public GameObject player;

    public float spawnTimer;
    public float spawnOffset;

    public float gameTimer;
    public float zombieSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = 10;
        spawnOffset = 5;
        zombieSpeed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        gameTimer += Time.deltaTime;
        if (spawnTimer <= 0) 
        {
            int spawnpoint = Random.Range(0, 3);
            StartCoroutine(spawnZombie(spawnpoint));
            spawnTimer = 5 + spawnOffset;
        }
        //increases difficulty
        if (gameTimer >= 30)
        {
            spawnOffset = 2;
            zombieSpeed = 0.5f;
        }
        if (gameTimer >= 60)
        {
            spawnOffset = 0;
        }
        if (gameTimer >= 120)
        {
            spawnOffset = -2;
            zombieSpeed = 0.8f;
        }


    }

    IEnumerator spawnZombie(int sPoint)
    {
        GameObject z = Instantiate(zombiePrefab);
        z.transform.position = spawns[sPoint].transform.position;
        z.GetComponent<EnemyAI>().speed = zombieSpeed;
        z.GetComponent<EnemyAI>().entrance = entrances[sPoint];
        z.GetComponent<EnemyAI>().target = player;
        yield return null;
    }
}
