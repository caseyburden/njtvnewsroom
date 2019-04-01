using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject helpMenu;


    GameController gameCtrl;

    bool showPauseMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        gameCtrl = GameController.instance;
        gameCtrl.onGameResumedCallback += GameHasResumed;
        gameCtrl.onGamePauseCallback += GameHasPaused;
    }

    // Update is called once per frame
    void Update()
    {
        if (showPauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ExitToMenu();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                helpMenu.SetActive(!helpMenu.activeSelf);
            }
        }
        gameMenu.SetActive(showPauseMenu);
    }

    void GameHasPaused()
    {
        Debug.Log("Show Pause Menu");
        showPauseMenu = true;
    }

    void GameHasResumed()
    {
        Debug.Log("Pause Menu Removed");
        showPauseMenu = false;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
