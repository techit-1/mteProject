using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    private Transform enemyMovement;
    private NavMeshAgent nav;
    private float damaged;
    [SerializeField] public float atk = 1.0f;

    public enum Enemy
    {
        Spawner,
        typeA,
        typeB,
        typeC,
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
        damaged = weaponController.instance.attackValue;
        currentHp = MaxHp;

        /*switch(Enemy)
        case Enemy.Spawner:
            atk = 1.0f;
            break;
        case Enemy.typeA:
            atk = 2.0f;
            break;*/

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
            Destroy(gameObject);
        }
            
    }

    //damage taken
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapons"))
        {
            currentHp = currentHp - damaged;
        }
    }
    void Movment()
    {
        nav.destination = enemyMovement.position;
    }
}
