using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CharacterSO : ScriptableObject
{
    public int id;
    public string characterName;
    public string description;
    public Sprite icon;
    public GameObject prefab;
}

