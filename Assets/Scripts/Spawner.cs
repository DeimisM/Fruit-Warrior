using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fruits;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    void Spawn()
    {
        var fruit = fruits[Random.Range(0, fruits.Count)];

        GameObject obj = Instantiate(fruit);

        obj.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, -3f), 0);
    }
}
