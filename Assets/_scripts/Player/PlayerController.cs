using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public delegate void OnEnteredRoom(RoomZone zone);
    public OnEnteredRoom onEnteredRoomCallback;

    public delegate void OnExitRoom();
    public OnExitRoom onExitRoomCallback;

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
        if (other.tag == "Interactable")
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }

        if (other.tag == "Zone")
        {
            RoomZone roomZone = other.GetComponent<RoomZone>();
            if (roomZone != null)
            {
                if (onEnteredRoomCallback != null)
                {
                    onEnteredRoomCallback.Invoke(roomZone);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            RemoveFocus();

        }

        if (other.tag == "Zone")
        {
            Debug.Log("Did exit room");
            if (onExitRoomCallback != null)
            {
                onExitRoomCallback.Invoke();
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }

            focus = newFocus;
        }

        newFocus.OnFocused(transform);
        Debug.Log("Focused on " + newFocus.name);
        
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        Debug.Log("Focused removed");
    }
}
