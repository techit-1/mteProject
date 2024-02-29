using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    //playerMove
    private CharacterController charController;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private Camera followCamera;
    Vector3 movement;

    
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector3 (horizontalInput, 0, verticalInput) * playerSpeed * Time.deltaTime;

        transform.position += movement;
    }

}
