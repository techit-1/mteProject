using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getKnuckleTrigger : MonoBehaviour
{
    public GameObject knuckle;

    private void Awake()
    {
        knuckle = GameObject.Find("knuckleController");
        knuckle.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            knuckle.SetActive(true);
            Debug.Log("you get a knuckle!!");
            Destroy(gameObject);

        }
    }
}
