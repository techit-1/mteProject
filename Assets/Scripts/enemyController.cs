using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    private Transform enemyMovement;
    private NavMeshAgent nav;
    private float saberDamaged;
    private float knuckleDamaged;
    [SerializeField] public float atk = 1.0f;

    public enum Enemy
    {
        Spawner,
        mob,
        miniBoss,
        Boss,
        none,
    }
    public Enemy enemyType;

    

    public float MaxHp;
    [SerializeField] float currentHp;
    public bool Isdead = false;

    public static enemyController instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        saberDamaged = 1f;
        knuckleDamaged = 0.5f;
        currentHp = MaxHp;

    }

    // Update is called once per frame
    void Update()
    {

        //if alive can walk   if hp = 0 destroy object 
        if (currentHp > 0)
        {
            Movment();
        }
        else
        {
            Isdead = true;
            switch (enemyType)
            {
                case Enemy.mob:
                    Destroy(gameObject);
                    Debug.Log("You destroy enemy!!");
                    break;

                case Enemy.Spawner:
                    Destroy(gameObject);
                    triggerWave2();
                    Debug.Log("You destroyed enemy spawner!!");
                    break;
            }
        }

    }

    //damage taken
    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "saberController":
                currentHp -= saberDamaged;
                break;
            case "knuckleController":
                currentHp -= knuckleDamaged;
                break;
        }
    }
    void Movment()
    {
        nav.destination = enemyMovement.position;
    }

    void triggerWave2()
    {
        ghostAppeartrigger.instance.wave2Appear();
    }
}
