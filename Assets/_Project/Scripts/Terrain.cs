using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainData", menuName = "ScriptableObjects/Terrain")]
public class Terrain : ScriptableObject
{
    public int MovementCost;
    public bool IsWater;
    public Sprite Sprite;
}