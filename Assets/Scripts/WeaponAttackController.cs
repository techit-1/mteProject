using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackController : MonoBehaviour
{
    public static WeaponAttackController instance;
    float SaberAttackValue = 1f;
    float KnuckleAttackValue = 1.5f;
    public float atkValue;


    private void Awake()
    {
        instance = this;
        if(GameObject.Find("saberController"))
        {
            atkValue = SaberAttackValue;
        }
        else if(GameObject.Find("knuckleController"))
            atkValue = KnuckleAttackValue;
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
