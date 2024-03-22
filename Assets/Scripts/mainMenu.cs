using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public static mainMenu instance;

    public GameObject creditScene;
    bool creditIsOpen;

    private void Awake()
    {
        instance = this;
        creditScene = GameObject.Find("credit");
        creditScene.gameObject.SetActive(false);
        creditIsOpen = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            creditScene.gameObject.SetActive(false);
            creditIsOpen = false;
        }
    }

    public void Button_Start()
    {
        SceneManager.LoadScene("LV1");
    }

    public void Button_Credit()
    {
        if(creditIsOpen == false)
        {
            creditIsOpen = true;
            creditScene.gameObject.SetActive(true);
        }
    }

    public void Button_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}