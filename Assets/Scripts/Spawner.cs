using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public List<GameObject> fruits;
    public GameObject bombPrefab;
    public GameObject fruitPrefab;
    public List<Wave> waves;


    async void Start()
    {
        foreach (var wave in waves)
        {
            foreach(var fruit in wave.items)
            {
                var prefab = fruit.isBomb ? bombPrefab : fruitPrefab;    // sutrumpintas if'as
                var go = Instantiate(prefab);
                go.transform.position = new Vector3(fruit.x, -5f, 0);

                await new WaitForSeconds(3f);
            }
        }
        //InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    /*
    void Spawn()
    {
        var fruit = fruits[Random.Range(0, fruits.Count)];

        GameObject obj = Instantiate(fruit);

        obj.transform.position = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, -3f), 0);
    }
    */
}
