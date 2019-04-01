using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(FirstPersonController))]
public class Player : MonoBehaviour
{
    GameController gameCtrl;
    FirstPersonController fps;
    // Start is called before the first frame update
    void Start()
    {
        gameCtrl = GameController.instance;
        fps = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        fps.enabled = !gameCtrl.isGamePaused;
    }
}
