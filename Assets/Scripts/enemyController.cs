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
        knuckleDamaged = 1f;
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
                case Enemy.miniBoss:
                    Destroy(gameObject);
                    Debug.Log("You destroy Mini boss!!");
                    break;
                case Enemy.Spawner:
                    Destroy(gameObject);
                    if(gameObject.name == "ghostSpawnerController2")
                        triggerBossWave();
                    else
                        triggerNextWave();
                    Debug.Log("You destroyed enemy spawner!!");
                    break;
                case Enemy.Boss:
                    Destroy(gameObject);
                    Debug.Log("you destroy Boss enemy!!");
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

    void triggerNextWave()
    {
        ghostAppeartrigger.instance.wave2Appear();
    }

    void triggerBossWave()
    {
        ghostAppeartrigger.instance.finalWaveAppear();
    }
}
