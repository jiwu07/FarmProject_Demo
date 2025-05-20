using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DecorationSO : ScriptableObject
{
    public string decorationName;
    public Sprite decorationSprite;
    public string decorationDescription;
    public GameObject decorationPrefab;
}
