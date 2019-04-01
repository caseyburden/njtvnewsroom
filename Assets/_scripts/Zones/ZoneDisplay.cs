using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoneDisplay : MonoBehaviour
{
    private Zone currentZone;

    public TextMeshProUGUI zoneText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerCtrl.onEnteredRoomCallback += PlayerEnteredRoom;
        playerCtrl.onExitRoomCallback += PlayerExitedRoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentZone != null)
        {
            zoneText.text = currentZone.name;
        }
        else
        {
            zoneText.text = "";
        }
    }

    void PlayerEnteredRoom(RoomZone room)
    {
        currentZone = room.zone;
    }

    void PlayerExitedRoom()
    {
        currentZone = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(10, 10, 10));
    }
}
