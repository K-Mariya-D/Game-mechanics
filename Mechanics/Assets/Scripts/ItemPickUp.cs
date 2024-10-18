using System;
using UnityEngine;

/// <summary>
/// A class of items that can be taken into player inventory
/// </summary>
public class ItemPickUp : MonoBehaviour
{
    /// <summary>
    /// Player inventory
    /// </summary>
    [SerializeField] private AbstractPlayerInventory _inventory;
    public AbstractPlayerInventory Inventory
    {
        get => _inventory;
        private set
        {
            if (value == null) throw new ArgumentNullException("PickUp: Inventory is null");
            _inventory = value;
        }
    }
    /// <summary>
    /// Image of the slot filled with this item
    /// </summary>
    [SerializeField] private GameObject _imageSlot;
    public GameObject ImageSlot
    {
        get => _imageSlot;
        private set
        {
            if (value == null) throw new ArgumentNullException("PickUp: ImageSlot is null");
            _imageSlot = value;
        }
    }
    /// <summary>
    /// State of this item in hand
    /// </summary>
    private bool _isFitHand = false;
    public bool IsFitHand { get => _isFitHand; set => _isFitHand = value; }
    /// <summary>
    /// Settings up fields
    /// </summary>
    private void Start()
    {
        if (ImageSlot == null) throw new ArgumentNullException("PickUp: ImageSlot is null");
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractPlayerInventory>();
    }
    /// <summary>
    /// Implementation of interaction with this item
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Important: the item must not be in player hand!
        if (collision != null &&
            !IsFitHand &&
            collision.gameObject.CompareTag("Player") &&
            Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < Inventory.Slots.Length; i++)
            {
                if (!Inventory.Slots[i].IsFull) //Checking that the slot is empty
                {
                    //Filling a slot with this item
                    Inventory.Slots[i].SetImageSlot(ImageSlot);
                    Inventory.Slots[i].StoredItem = this;
                    Inventory.Slots[i].StoredItem.gameObject.SetActive(false);
                    IsFitHand = true;
                    break;
                }
            }
        }
    }
}
