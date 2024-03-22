using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHolder : MonoBehaviour
{
    public GameObject holder;
    
    // Start is called before the first frame update
    void Start()
    {
        holder = GameObject.Find("EnemyHolder");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(holder);
        }
    }
}
