using UnityEngine;

/// <summary>
/// An class player inventory
/// </summary>
public class PlayerInventory : AbstractPlayerInventory
{
    /// <summary>
    /// Selects a slot with index
    /// </summary>
    /// <param name="index"></param>
    public override void SelectSlot(int index)
    {
        if (Slots[CurrentSlot].StoredItem != null)
            Slots[CurrentSlot].StoredItem.gameObject.SetActive(false);
        CurrentSlot = index;
    }
    /// <summary>
    /// Selects next slot
    /// </summary>
    public override void SelectNextSlot()
    {
        if (Slots[CurrentSlot].StoredItem != null)
            Slots[CurrentSlot].StoredItem.gameObject.SetActive(false);
        CurrentSlot = (CurrentSlot + 1) % Slots.Length;
    }
    /// <summary>
    /// Selects previous slot
    /// </summary>
    public override void SelectPrevSlot()
    {
        if (Slots[CurrentSlot].StoredItem != null)
            Slots[CurrentSlot].StoredItem.gameObject.SetActive(false);
        CurrentSlot = (CurrentSlot - 1 + Slots.Length) % Slots.Length;
    }
    /// <summary>
    /// Changes the visual display of the selected slot
    /// </summary>
    public override void UpdateSelectionSlot()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].transform.localScale = (i == CurrentSlot ? new Vector3(0.7f, 0.7f, 0.7f) : new Vector3(0.5f, 0.5f, 0.5f));
        }
    }
}
