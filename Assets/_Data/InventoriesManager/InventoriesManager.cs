using System.Collections.Generic;
using UnityEngine;

public class InventoriesManager : DanSingleton<InventoriesManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
        this.LoadItemProfiles();
    }

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach (Transform child in transform)
        {
            InventoryCtrl inventory = child.GetComponent<InventoryCtrl>();
            if (inventory == null) continue;
            this.inventories.Add(inventory);
        }

        Debug.Log(transform.name + ": LoadInventories", gameObject);
    }

    protected virtual void LoadItemProfiles()
    {
        if (this.itemProfiles.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("");
        this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
    }

    public virtual InventoryCtrl GetByCodeName(InventoryType inventoryType)
    {
        foreach (InventoryCtrl child in inventories)
        {
            if (child.GetName() == inventoryType) return child;
        }

        return null;
    }

    public virtual InventoryCtrl Currency()
    {
        return this.GetByCodeName(InventoryType.Currency);
    }

    public virtual InventoryCtrl Item()
    {
        return this.GetByCodeName(InventoryType.Item);
    }

    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach (ItemProfileSO child in itemProfiles)
        {
            if (child.itemCode == itemCodeName) return child;
        }

        return null;
    }

    public virtual void AddItem(ItemInventory itemInventory)
    {
        InventoryType invCodeName = itemInventory.ItemProfile.inventoryType;
        InventoryCtrl inventoryCtrl = this.GetByCodeName(invCodeName);
        inventoryCtrl.AddItem(itemInventory);
    }

    public virtual void AddItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = this.GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.AddItem(item);
    }

    public virtual void RemoveItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = this.GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.RemoveItem(item);
    }

    public virtual void RemoveItem(ItemInventory itemInventory)
    {
        InventoryType inventoryType = itemInventory.ItemProfile.inventoryType;
        InventoryCtrl inventoryCtrl = this.GetByCodeName(inventoryType);
        inventoryCtrl.RemoveItem(itemInventory);
    }
}