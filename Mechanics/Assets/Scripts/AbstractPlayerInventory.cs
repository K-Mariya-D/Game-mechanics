using System;
using UnityEngine;

/// <summary>
/// An abstract class that implements game inventory
/// </summary>
public abstract class AbstractPlayerInventory : MonoBehaviour
{
    /// <summary>
    /// Massive of abstract inventory slots
    /// </summary>
    [SerializeField] private AbstractInventorySlot[] _slots;
    public AbstractInventorySlot[] Slots
    {
        get => _slots;
        protected set
        {
            if (value == null) throw new ArgumentNullException("Inventory: Slots is null");
            _slots = value;
        }
    }
    /// <summary>
    /// Current selecting slot
    /// </summary>
    [SerializeField] private int _currentSlot;
    public int CurrentSlot
    {
        get => _currentSlot;
        protected set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("QuickAccess: CurrSlot < 0");
            if (value > Slots.Length) throw new ArgumentOutOfRangeException("QuickAccess: CurrSlot is more than count of Inventory Slots");
            _currentSlot = value;
        }
    }
    /// <summary>
    /// Settings up fields
    /// </summary>
    private void Start()
    {
        if (Slots == null) throw new ArgumentNullException("PlayerInventory: Slots is null");
        SelectSlot(0); //Selecting a slot with index 0 (number 1)
    }
    /// <summary>
    /// Inventory slot management
    /// </summary>
    public void Update()
    {
        //Switch between slots using buttons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
            UpdateSelectionSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
            UpdateSelectionSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
            UpdateSelectionSlot();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SelectNextSlot();
            UpdateSelectionSlot();
        }
        //Switch between slots using mouse
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SelectNextSlot();
            UpdateSelectionSlot();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SelectPrevSlot();
            UpdateSelectionSlot();
        }
    }
    /// <summary>
    /// Selects a slot with index
    /// </summary>
    /// <param name="index"></param>
    public abstract void SelectSlot(int index);
    /// <summary>
    /// Selects next slot
    /// </summary>
    public abstract void SelectNextSlot();
    /// <summary>
    /// Selects previous slot
    /// </summary>
    public abstract void SelectPrevSlot();
    /// <summary>
    /// Changes the visual display of the selected slot
    /// </summary>
    public abstract void UpdateSelectionSlot();
}
