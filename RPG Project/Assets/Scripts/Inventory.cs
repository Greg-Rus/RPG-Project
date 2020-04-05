using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;
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

        if (_items.Count >= InventorySpace)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }

        _items.Add(item);
        OnItemChangedCallback?.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
        OnItemChangedCallback?.Invoke();
    }
}
