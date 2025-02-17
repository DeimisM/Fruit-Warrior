using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public List<GameObject> fruits;
    public GameObject bombPrefab;
    public List<GameObject> fruitPrefabs;
    public List<Wave> waves;


    async void Start()
    {
        foreach (var wave in waves)
        {
            foreach(var fruit in wave.items)
            {
                var randomFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];
                
                var prefab = fruit.isBomb ? bombPrefab : randomFruit;    // sutrumpintas if'as
                var go = Instantiate(prefab);
                go.transform.position = new Vector3(fruit.x, -5f, 0);

                var rigidbody2D = go.GetComponent<Rigidbody2D>();
                rigidbody2D.velocity = fruit.velocity;
                await new WaitForSeconds(fruit.delay);

                //await new WaitForSeconds(3f);
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
