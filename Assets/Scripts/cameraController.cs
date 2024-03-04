using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float distanceFromTarget = 13.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move camera with character
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
