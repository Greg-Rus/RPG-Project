using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckupItem : Interactable
{
    public Item Item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up item " + Item.Name);
        var stored = Inventory.Instance.Add(Item);
        if(stored) Destroy(gameObject);
    }
}
