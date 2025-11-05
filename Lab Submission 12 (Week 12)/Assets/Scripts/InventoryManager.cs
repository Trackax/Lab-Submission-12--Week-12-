using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    void Start()
    {
        InitializeInventory();
        Debug.Log("Initial Inventory:");
        PrintInventory();
        InventoryItem foundItem = LinearSearchByName("Item 3");
        if (foundItem != null)
        {
            Debug.Log($"Found item by name: {foundItem.Name} (ID: {foundItem.ID})");
        }
        else
        {
            Debug.Log("Item 'Item 3' not found.");
        }
        Debug.Log("\nSorting inventory by ID for Binary Search...");
        inventory = inventory.OrderBy(item => item.ID).ToList();
        PrintInventory();
        InventoryItem foundItemByID = BinarySearchByID(5);
        if (foundItemByID != null)
        {
            Debug.Log($"Found item by ID: {foundItemByID.ID} (Name: {foundItemByID.Name})");
        }
        else
        {
            Debug.Log("Item with ID 5 not found.");
        }
        Debug.Log("\nSorting inventory by Value using QuickSort...");
        QuickSortByValue(inventory, 0, inventory.Count - 1);
        PrintInventory();
    }

    void InitializeInventory()
    {
        for (int i = 0; i < 10; i++)
        {
            int randomID = Random.Range(1, 100);
            string itemName = $"Item {i + 1}";
            float randomValue = Random.Range(10f, 100f);
            inventory.Add(new InventoryItem(randomID, itemName, randomValue));
        }
    }

    public InventoryItem LinearSearchByName(string itemName)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.Name == itemName)
            {
                return item;
            }
        }
        return null;
    }

    public InventoryItem BinarySearchByID(int itemID)
    {
        int left = 0;
        int right = inventory.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (inventory[mid].ID == itemID)
            {
                return inventory[mid];
            }
            else if (inventory[mid].ID < itemID)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return null;
    }

    public void QuickSortByValue(List<InventoryItem> items, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(items, low, high);
            QuickSortByValue(items, low, pivotIndex - 1);
            QuickSortByValue(items, pivotIndex + 1, high);
        }
    }

    private int Partition(List<InventoryItem> items, int low, int high)
    {
        float pivot = items[high].Value;
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (items[j].Value <= pivot)
            {
                i++;
                Swap(items, i, j);
            }
        }
        Swap(items, i + 1, high);
        return i + 1;
    }

    private void Swap(List<InventoryItem> items, int i, int j)
    {
        InventoryItem temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }

    void PrintInventory()
    {
        foreach (InventoryItem item in inventory)
        {
            Debug.Log($"ID: {item.ID}, Name: {item.Name}, Value: {item.Value}");
        }
    }
}
