using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject swarmPrefabA;
    [SerializeField] GameObject swarmPrefabB;
    [SerializeField] GameObject bigSwarmPrefab;

    [SerializeField] float swarmIntervalA = 0.2f;
    [SerializeField] float swarmIntervalB = 0.1f;
    [SerializeField] float bigSwarmInterval = 0.3f;

    [SerializeField] float count = 0f;
    public int waveEnemy; //edit in ghostAppeartrigger
    public float maxEnemy = 15f; //can only edit from ghostAppeartrigger
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
        swarmPrefabA = GameObject.Find("ghostAController" + waveEnemy);
        swarmPrefabB = GameObject.Find("ghostBController" + waveEnemy);
        bigSwarmPrefab = GameObject.Find("ghostCController" + waveEnemy);
        enemyContainner = GameObject.Find("Containner");
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
