using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FruitSpawnData
{
    public float delay;
    public bool isBomb;
    public float x;
    public Vector2 velocity = new Vector2(0, 10);
}
