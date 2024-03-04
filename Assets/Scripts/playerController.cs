using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    //playerMove
    private BoxCollider bd;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private Camera followCamera;
    Vector3 movement;

    public float maxHp = 10.0f;
    public bool Isdead = false;

    public Image hpBar;
    [SerializeField] float hpAmount;


    // Start is called before the first frame update
    void Start()
    {
        bd = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        hpAmount = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Isdead != true)
        {
            Movement();
            //hpAmount = currentHp;
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
        if(collision.collider.CompareTag("Enemy"))
        {
            takeDamage(enemyController.instance.Atk);
            
        }
    }

    void takeDamage(float damageTaken)
    {
        hpAmount = hpAmount - damageTaken;
        hpBar.fillAmount = hpAmount / 10f;

        if(hpAmount <= 0)
        {
            Isdead = true;
            Destroy(gameObject);
        }
    }

}
