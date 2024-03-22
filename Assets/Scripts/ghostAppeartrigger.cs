using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAppeartrigger : MonoBehaviour
{
    //[SerializeField] GameObject ghost;
    GameObject wave1;
    GameObject wave2;
    GameObject finalWave;
    GameObject holder;

    bool wave1Triggger = false;

    public static ghostAppeartrigger instance;

    private void Awake()
    {
        instance = this;
        wave1 = GameObject.Find("ghostSpawnerController1");
        wave1.SetActive(false);
        wave2 = GameObject.Find("ghostSpawnerController2");
        wave2.SetActive(false);
        finalWave = GameObject.Find("ghostBossController");
        finalWave.SetActive(false);
        holder = GameObject.Find("EnemyHolder");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && wave1Triggger == false)
        {
            //ghost.SetActive(true);
            wave1.SetActive(true);
            enemySpawner.Instance.waveEnemy = 1;
            enemySpawner.Instance.canSpawn = true;
            wave1Triggger = true;
            Destroy(holder);
            Debug.Log("Enemy appear!!");
        }
    }

    public void wave2Appear()
    {
        wave2.SetActive(true);
        Destroy(wave2.GetComponent<enemySpawner>());
        wave2.AddComponent<enemySpawner>();
        enemySpawner.Instance.waveEnemy = 2;
        enemySpawner.Instance.maxEnemy = 30f;
        enemySpawner.Instance.canSpawn = true;
        Debug.Log("Mini boss appear!!");
    }

    public void finalWaveAppear()
    {
        finalWave.SetActive(true);
        Destroy(finalWave.GetComponent<enemySpawner>());
        finalWave.AddComponent<enemySpawner>();
        enemySpawner.Instance.waveEnemy = 3;
        enemySpawner.Instance.maxEnemy = 50f;
        enemySpawner.Instance.swarmIntervalA = 1;
        enemySpawner.Instance.swarmIntervalB = 1;
        enemySpawner.Instance.bigSwarmInterval = 2;
        enemySpawner.Instance.canSpawn = true;
        Debug.Log("Boss enemy appear!!");
    }
}
