using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{
    public bool Iswinner;
    public static CheckWinner instance;

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
        if(GameObject.FindWithTag("Spawner") == null && GameObject.FindWithTag("Enemy") == null && GameObject.FindWithTag("Holder") == null)
        {
            Iswinner = true;
        }
    }
}
