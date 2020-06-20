using UnityEngine;

[CreateAssetMenu (fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //when editing any of those values in the asset, remember to save to project. Otherwise git will not pick up the changes.
    public string Name = "New Item";
    public Sprite Icon = null;
    public bool IsDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + Name);
    }
}
