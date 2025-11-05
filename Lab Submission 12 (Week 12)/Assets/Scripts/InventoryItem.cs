using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public float Value { get; private set; }

    public InventoryItem (int id, string name, float value)
    {
        ID = id;
        Name = name;
        Value = value;
    }

    public override string ToString()
    {
        return $"[ID: {ID}, Name: {Name}, Value: {Value:F2}]";
    }
}
