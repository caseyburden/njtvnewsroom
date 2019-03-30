using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameUIController : MonoBehaviour
{
    public GameObject miniMap;
    public GameObject gameMenu;

    private FirstPersonController fpsCtrl;

    private bool showMiniMap = true;
    private bool showGameMenu = false;

    private bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        fpsCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
       
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
        }


        if (gameIsPaused)
        {
            Paused();
        }
        else
        {
            Playing();
        }

    }

    void Paused ()
    {
        gameMenu.SetActive(true);
        miniMap.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Playing()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            showMiniMap = !showMiniMap;
        }

        miniMap.SetActive(showMiniMap);
        gameMenu.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
