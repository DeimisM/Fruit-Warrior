using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fruits = new List<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    void Spawn()
    {
        int random = Random.Range(1, 6);

        for (int i = 0; i < random; i++)
        {
            int randomFruit = Random.Range(0, fruits.Count);

            GameObject obj = Instantiate(fruits[randomFruit]);

            obj.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, -3f), 0);
        }
    }
}
