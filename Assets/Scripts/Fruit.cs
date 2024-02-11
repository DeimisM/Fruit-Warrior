using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosionParticles;
    public Color juiceColor;

    public AudioClip spawnSound;
    public AudioClip sliceSound;
    public AudioClip missSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0, Random.Range(13f, 15f));
        rb.angularVelocity = Random.Range(-360f, 360f);

        AudioSystem.Play(spawnSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            Miss();
        }
    }

    void Miss()
    {
        print(":(");
        Destroy(gameObject);

        AudioSystem.Play(missSound);
    }
    
    public void Slice()
    {
        var particles = Instantiate(explosionParticles);
        particles.transform.position = transform.position;
        

        if (!CompareTag("Bomb")) FruitSplit(particles);

        AudioSystem.Play(sliceSound);
        

        Destroy(gameObject);
    }

    private void FruitSplit(GameObject particles)
    {
        var children = GetComponentsInChildren<MeshRenderer>();

        foreach (var child in children)
        {
            var childRb = child.gameObject.AddComponent<Rigidbody2D>();
            childRb.velocity = rb.velocity + Random.insideUnitCircle;       // vietoj random funkcijos
        }

        transform.DetachChildren();

        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = juiceColor;
    }
}
