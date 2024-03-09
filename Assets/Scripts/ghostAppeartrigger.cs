using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAppeartrigger : MonoBehaviour
{
    GameObject ghost;
    
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.FindWithTag("Spawner");
        ghost.SetActive(false);
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
        }
    }
}
