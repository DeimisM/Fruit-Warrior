using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody2D rb;

    public int comboCount;
    public float comboTimeLeft;

    public List<AudioClip> comboSounds;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        
        //transform.position = worldPos;
        rb.MovePosition(worldPos);

        comboTimeLeft -= Time.deltaTime;

        if(comboTimeLeft <= 0)
        {
            if(comboCount > 2)
            {
                AudioSystem.Play(comboSounds[comboCount - 3]);
            }
            comboCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        var fruit = collision.gameObject.GetComponent<Fruit>();
        fruit.Slice();

        comboCount++;
        comboTimeLeft = 0.2f;
    }
}
