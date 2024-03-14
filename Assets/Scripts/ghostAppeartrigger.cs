using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAppeartrigger : MonoBehaviour
{
    [SerializeField] GameObject ghost;

    private void Awake()
    {
        ghost = GameObject.FindWithTag("Spawner");
        ghost.SetActive(false);
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
        if(other.gameObject.CompareTag("Player"))
        {
            ghost.SetActive(true);
            enemySpawner.Instance.canSpawn = true;
            
        }
    }
}
