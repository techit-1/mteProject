using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameUiManager : MonoBehaviour
{
    public GameObject UI_Pause;
    public GameObject UI_GameOver;
    public GameObject UI_GameisFinished;

    private enum GameUI_State
    {
        GamePlay, GamePause, GameOver, GameisFinished
    }
    GameUI_State currentState;

    public static gameUiManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchUIState(GameUI_State.GamePlay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseUI();
        }
        if (playerController.instance.Isdead == true)
        {
            SwitchUIState(GameUI_State.GameOver);
        }
        if (CheckWinner.instance.Iswinner == true)
        {
            StartCoroutine(delayGUIGameisFinished());
        }
    }

    private void SwitchUIState(GameUI_State state)
    {
        UI_Pause.SetActive(false);
        UI_GameOver.SetActive(false);
        UI_GameisFinished.SetActive(false);

        Time.timeScale = 1;

        switch (state)
        {
            case GameUI_State.GamePlay:
                playerController.instance.Canmoving = true;
                break;
            case GameUI_State.GamePause:
                Time.timeScale = 0;
                playerController.instance.Canmoving = false;
                UI_Pause.SetActive(true);
                break;
            case GameUI_State.GameOver:
                UI_GameOver.SetActive(true);
                break;
            case GameUI_State.GameisFinished:
                playerController.instance.Canmoving = false;
                UI_GameisFinished.SetActive(true);
                break;
        }
        currentState = state;
    }

    public void TogglePauseUI()
    {
        if (currentState == GameUI_State.GamePlay)
        {
            SwitchUIState(GameUI_State.GamePause);
        }
        else if (currentState == GameUI_State.GamePause)
        {
            SwitchUIState(GameUI_State.GamePlay);
        }
    }

    public void Button_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Button_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Button_Resume()
    {
        SwitchUIState(GameUI_State.GamePlay);
    }

    IEnumerator delayGUIGameisFinished()
    {
        yield return new WaitForSeconds(3f);
        SwitchUIState(GameUI_State.GameisFinished);
    }
}
