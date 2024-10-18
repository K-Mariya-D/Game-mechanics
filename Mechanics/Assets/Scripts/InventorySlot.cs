using UnityEngine;

/// <summary>
/// A class inventory slot
/// </summary>
public class InventorySlot : AbstractInventorySlot
{
    /// <summary>
    /// Sets the image of a stored item in this slot (ImageStoredItem)
    /// </summary>
    /// <param name="objectInSlot"></param>
    public override void SetImageSlot(GameObject objectInSlot)
    {
        if (ImageStoredItem == null) //Checking that the ImageStoredItem is empty
        {
            ImageStoredItem = Instantiate(objectInSlot, this.transform);
            IsFull = true;
        }
    }
    /// <summary>
    /// Removes the image of a stored item in this slot (ImageStoredItem)
    /// </summary>
    public override void RemoveImageSlot()
    {
        if (ImageStoredItem != null)
        {
            Destroy(ImageStoredItem);
            IsFull = false;
            ImageStoredItem = null;
        }
    }
}
