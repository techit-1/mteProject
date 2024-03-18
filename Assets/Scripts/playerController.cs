using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    //playerMove
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private Camera followCamera;
    Vector3 movement;

    public float maxHp;
    public bool Isdead = false;

    public Image hpBar;
    [SerializeField] float hpAmount;


    float time;


    // Start is called before the first frame update
    void Start()
    {
        hpAmount = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Isdead != true)
        {
            Movement();
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector3 (horizontalInput, 0, verticalInput) * playerSpeed * Time.deltaTime;

        transform.position += movement;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Spawner"))
        {
            takeDamage(enemyController.instance.atk);
        }
    }

    private void OnCollisionStay(Collision stillCollision)
    {
        if(stillCollision.collider.CompareTag("Enemy") || stillCollision.collider.CompareTag("Spawner"))
        {
            time += Time.deltaTime;
            if( time >= 1.0f)
            {
                takeDamage(enemyController.instance.atk);
                time = 0f;
            }
        }
    }

    void takeDamage(float damageTaken)
    {
        hpAmount = hpAmount - damageTaken;
        hpBar.fillAmount = hpAmount / maxHp;
        Debug.Log("Enemy attacked you!!");

        if (hpAmount <= 0)
        {
            Isdead = true;
            Destroy(gameObject);
            Debug.Log("You died!!");
        }
    }

}
