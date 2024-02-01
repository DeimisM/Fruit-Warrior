using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 10);
        rb.angularVelocity = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            print(":(");
            Destroy(gameObject);
        }
    }
}
