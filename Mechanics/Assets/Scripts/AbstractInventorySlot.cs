using UnityEngine;

/// <summary>
/// An abstarct class inventory slot
/// </summary>
public abstract class AbstractInventorySlot : MonoBehaviour
{
    /// <summary>
    /// Item stored in this slot
    /// </summary>
    private ItemPickUp _storedItem; //may be null
    public ItemPickUp StoredItem { get => _storedItem; set => _storedItem = value; }
    /// <summary>
    /// Image of the stored item
    /// </summary>
    private GameObject _imageStoredItem; //may be null
    public GameObject ImageStoredItem { get => _imageStoredItem; set => _imageStoredItem = value; }
    /// <summary>
    /// Slot full status
    /// </summary>
    private bool _isFull;
    public bool IsFull { get => _isFull; set => _isFull = value; }
    /// <summary>
    /// Sets the image of a stored item in this slot (ImageStoredItem)
    /// </summary>
    /// <param name="objectInSlot"></param>
    public abstract void SetImageSlot(GameObject objectInSlot);
    /// <summary>
    /// Removes the image of a stored item in this slot (ImageStoredItem)
    /// </summary>
    public abstract void RemoveImageSlot();
}
