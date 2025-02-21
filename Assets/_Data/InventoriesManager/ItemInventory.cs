using System;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    protected ItemProfileSO itemProfile;
    public ItemProfileSO ItemProfile => itemProfile;

    protected int itemId;
    public int ItemId => itemId;

    [SerializeField] protected string itemName;

    public int itemCount;

    public ItemInventory(ItemProfileSO itemProfile, int itemCount)
    {
        this.itemProfile = itemProfile;
        this.itemCount = itemCount;
        this.itemName = itemProfile.itemName;
    }

    public virtual void SetId(int id)
    {
        this.itemId = id;
    }

    public virtual void SetName(string name)
    {
        this.itemName = name;
    }

    public virtual string GetItemName()
    {
        if (this.itemName == null || this.itemName == "") return this.itemProfile.itemName;
        return this.itemName;
    }

    public virtual bool Deduct(int number)
    {
        if (!this.CanDeduct(number)) return false;
        this.itemCount -= number;
        return true;
    }

    public virtual bool CanDeduct(int number)
    {
        return this.itemCount >= number;
    }
}