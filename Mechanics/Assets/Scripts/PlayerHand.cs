using UnityEngine;
using System;

/// <summary>
/// A class of player hand
/// </summary>
public class PlayerHand : MonoBehaviour
{
    /// <summary>
    /// Player inventory
    /// </summary>
    private AbstractPlayerInventory _inventory;
    public AbstractPlayerInventory Inventory
    {
        get => _inventory;
        private set
        {
            if (value == null) throw new ArgumentNullException("PlayerHand: Inventory is null");
            _inventory = value;
        }
    }
    /// <summary>
    /// Settings up fields
    /// </summary>
    private void Start()
    {
        Inventory = this.GetComponent<AbstractPlayerInventory>();
    }
    /// <summary>
    /// Controlling the player's inventory hand
    /// </summary>
    private void Update()
    {
        //Drop an item using mouse
        if (Input.GetKey(KeyCode.Mouse0)) DropSelectionSlot();

        TakeSelectionSlotInHand();
    }
    /// <summary>
    /// Takes an item in the player hand
    /// </summary>
    public void TakeSelectionSlotInHand()
    {
        if (Inventory.Slots[Inventory.CurrentSlot].StoredItem != null)
        {
            Inventory.Slots[Inventory.CurrentSlot].StoredItem.gameObject.SetActive(true);
            Transform item_trans = Inventory.Slots[Inventory.CurrentSlot].StoredItem.transform;
            item_trans.position = transform.position + transform.right;
            item_trans.rotation = transform.rotation;
        }
    }
    /// <summary>
    /// Drops an item and clear the current slot
    /// </summary>
    public void DropSelectionSlot()
    {
        if (Inventory.Slots[Inventory.CurrentSlot].StoredItem != null)
        {
            //Clearing the current slot
            Inventory.Slots[Inventory.CurrentSlot].StoredItem.gameObject.SetActive(true);
            Inventory.Slots[Inventory.CurrentSlot].StoredItem.IsFitHand = false;
            Inventory.Slots[Inventory.CurrentSlot].RemoveImageSlot();
            Inventory.Slots[Inventory.CurrentSlot].StoredItem = null;
        }
    }
}