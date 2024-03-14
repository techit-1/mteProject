using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knuckleController : MonoBehaviour
{
    public static knuckleController instance;
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
