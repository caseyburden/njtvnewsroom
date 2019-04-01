using UnityEngine;

public class ItemInteract : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Selecting Interaction with " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }
}
