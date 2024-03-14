using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject swarmPrefabA;
    [SerializeField] GameObject swarmPrefabB;
    [SerializeField] GameObject bigSwarmPrefab;

    [SerializeField] float swarmIntervalA = 2f;
    [SerializeField] float swarmIntervalB = 1f;
    [SerializeField] float bigSwarmInterval = 3f;

    [SerializeField] float count = 0f;
    public float maxEnemy = 15f;
    [SerializeField] GameObject enemyContainner;
    [SerializeField] public bool canSpawn;

    public static enemySpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(spawnEnemy(swarmIntervalA, swarmPrefabA));
        StartCoroutine(spawnEnemy(swarmIntervalB, swarmPrefabB));
        StartCoroutine(spawnEnemy(bigSwarmInterval, bigSwarmPrefab));

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (count <= maxEnemy && canSpawn == true)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyContainner.transform;
            StartCoroutine(spawnEnemy(interval, enemy));
            count++;
        }

    }


}
