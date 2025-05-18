using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetSO : ScriptableObject
{
    public int id;
    public string seedName;
    public Sprite seedSprite;
    public PlanetStatus statusCurrent;
    public List<StatusPrefabsList> statusPrefabs;
    public int cost;
    public int earn;
}
public enum PlanetStatus
{
    Seed,
    Half,
    Grown
}

[System.Serializable]
public class StatusPrefabsList
{
    public PlanetStatus status;
    public GameObject preFab;
}