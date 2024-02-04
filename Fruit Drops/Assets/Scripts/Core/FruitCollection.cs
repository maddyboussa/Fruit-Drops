using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public enum FruitType
{
    Cherry,
    Strawberry,
    Grape,
    Pomegranate,
    Orange,
    Apple,
    Pear,
    Peach,
    Pineapple,
    Melon,
    Watermelon
}

// establishes a data collection of fruit types and their corresponding game objects
[CreateAssetMenu(menuName = "Fruit Collection")]    // allows for in-editor creation of fruit collections
public class FruitCollection : ScriptableObject
{
    [SerializedDictionary("Fruit", "Prefab")]
    public SerializedDictionary<FruitType, GameObject> fruitCollection = new SerializedDictionary<FruitType, GameObject>();

    /// <summary>
    /// Attempts to get prefab associated with fruit type
    /// </summary>
    /// <param name="fruit"></param>
    /// <returns>The prefab associate with the fruit being accessed</returns>
    public GameObject GetFruitPrefab(FruitType fruit)
    {
        if (fruitCollection.TryGetValue(fruit, out GameObject value))
        {
            return value;
        }
        else
        {
            Debug.LogError($"No stat value found for {fruit} on {this.name}");
            return null;
        }
    }

    /// <summary>
    /// Sets the prefab of a given fruit type
    /// </summary>
    /// <param name="fruit"></param>
    public void SetFruitPrefab(FruitType fruit)
    {
        if (fruitCollection.TryGetValue(fruit, out GameObject value))
        {
            fruitCollection[fruit] = value;
        }
        else
        {
            Debug.LogError($"No stat value found for {fruit} on {this.name}");
        }
    }
}
