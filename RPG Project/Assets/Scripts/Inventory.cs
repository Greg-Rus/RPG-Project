using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;

    public List<Item> Items
    {
        get { return _items; }
        set { _items = value; }
    }

    void Awake()
    {
        if (Instance != null) throw new ArgumentException("Inventory already exists");
        Instance = this;
    }
    #endregion Singleton

    [SerializeField] private List<Item> _items = new List<Item>();
    public int InventorySpace = 20;

    public delegate void OnItemChanged();

    public OnItemChanged OnItemChangedCallback;

    public bool Add(Item item)
    {
        if (item.IsDefaultItem) return false;

        if (Items.Count >= InventorySpace)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }

        Items.Add(item);
        OnItemChangedCallback?.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        OnItemChangedCallback?.Invoke();
    }
}
