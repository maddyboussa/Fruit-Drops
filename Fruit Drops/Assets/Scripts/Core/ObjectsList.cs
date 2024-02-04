using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName = "Object List")]
public class ObjectList : ScriptableObject
{
    [SerializedDictionary("Stat", "Value")]
}

