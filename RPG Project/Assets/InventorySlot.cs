using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //this is a kind of controller view combo.
    public Image Icon;
    public Button RemoveButton;
    public Button UseButton;
    private Item _item;


    public void AddItem(Item newItem)
    {
        _item = newItem;
        Icon.sprite = _item.Icon;
        Icon.enabled = true;
        RemoveButton.interactable = true;
    }

    public void ClearSlot()
    {
        _item = null;
        Icon.enabled = false;
        Icon.sprite = null;
        RemoveButton.interactable = false;
    }

    public void OnRemoveButtonPressed()
    {
        Inventory.Instance.Remove(_item);
    }

    public void UseItem()
    {
        if (_item != null)
        {
            _item.Use();
        }
    }
}
