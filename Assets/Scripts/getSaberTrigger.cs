using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSaberTrigger : MonoBehaviour
{
    public GameObject saber;

    private void Awake()
    {
        saber = GameObject.Find("saberController");
        saber.SetActive(false);
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
            saber.SetActive(true);
            Debug.Log("you get a saber!!");
            Destroy(gameObject);

        }
    }
}
