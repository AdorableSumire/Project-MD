using System;
using Unity.AppUI.Redux;
using UnityEngine;

[Serializable]
public class ItemStack
{
public ItemData item;
public int count;
}
public class Inventory : MonoBehaviour
{
    [SerializeField] int slotCount = 50;
    [SerializeField] ItemData testItem;

    ItemStack[] slots;

    public event System.Action OnChanged;
    public int SlotCount => SlotCount;

    void Awake() => slots = new ItemStack[slotCount];

    public ItemStack Get(int i) => slots[i];

    //0 = everything added
    public int Add(ItemData item, int amount)
    {
        //Fill existing stack
        for (int i = 0; i < slots.Length && amount > 0; i++)
        {
            var s = slots[i];
            if (s != null && s.item == item && s.count < item.maxStack)
            {
                int add = Mathf.Min(item.maxStack - s.count, amount);
                s.count += add;
                amount -= add;
            }    
        }
        //use empty slots
        for (int i = 0; i < slots.Length && amount > 0; i++)
        {
            if (slots[i] == null)
            {
                int add = Mathf.Min(item.maxStack, amount);
                slots[i] = new ItemStack { item = item, count = add };
                amount -= add;
            }    
        }
        OnChanged?.Invoke();
        return amount;
    }
    
    public void Remove(int index, int amount = 1)
    {
        var s = slots[index];
        if (s == null) return;
        s.count -= amount;
        if (s.count <= 0) slots[index] = null;
        OnChanged?.Invoke();
    }

    public void Swap(int a, int b)
    {
        (slots[a], slots[b]) = (slots[b], slots[a]);
        OnChanged?.Invoke();
    }

    //right click Add Item
    [ContextMenu("Add Test Item")]
    void AddTestItem()
    {
        if (testItem != null) Add(testItem, 5);
    }    
    
}
