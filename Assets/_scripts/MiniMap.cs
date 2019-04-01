using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    GameController gameCtrl;

    public GameObject miniMap;

    private bool showMiniMap = true;

    // Start is called before the first frame update
    void Start()
    {
        gameCtrl = GameController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameCtrl.isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                showMiniMap = !showMiniMap;
            }

            miniMap.SetActive(showMiniMap);
        }
        else
        {
            miniMap.SetActive(false);
        }
    }
}
