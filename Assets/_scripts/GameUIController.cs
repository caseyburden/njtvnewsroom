using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUIController : MonoBehaviour
{
    public GameObject miniMap;

    private bool showMiniMap = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            showMiniMap = !showMiniMap;
        }

        miniMap.SetActive(showMiniMap);
    }


}
