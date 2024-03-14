using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saberController : MonoBehaviour
{
    public static saberController instance;
    public float attackValue = 1.0f;


    private void Awake()
    {
        
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
