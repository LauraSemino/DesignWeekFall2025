using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public GameObject zombiePrefab;
    public GameObject[] spawns;
    public GameObject[] entrances;
    public GameObject player;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int spawnpoint = Random.Range(0, 3);
            StartCoroutine(spawnZombie(spawnpoint));
        }
    }

    IEnumerator spawnZombie(int sPoint)
    {
        GameObject z = Instantiate(zombiePrefab);
        z.transform.position = spawns[sPoint].transform.position;
        z.GetComponent<EnemyAI>().entrance = entrances[sPoint];
        z.GetComponent<EnemyAI>().target = player;
        yield return null;
    }
}
