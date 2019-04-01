using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton

    public static GameController instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameController found!");
            return;
        }
        instance = this;
    }

    #endregion

    public bool isGamePaused = false;

    public delegate void OnGamePause();
    public OnGamePause onGamePauseCallback;

    public delegate void OnGameResumed();
    public OnGameResumed onGameResumedCallback;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        SetCursorState(true);
        if (onGamePauseCallback != null)
        {
            Debug.Log("Game Paused");
            onGamePauseCallback.Invoke();
        }
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        SetCursorState(false);
        if (onGameResumedCallback != null)
        {
            Debug.Log("Game Resumed");
            onGameResumedCallback.Invoke();
        }
    }


    public void SetCursorState(bool isActive)
    {
        Cursor.visible = isActive;

        if (isActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
