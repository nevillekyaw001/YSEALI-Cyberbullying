using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    float randomSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        randomSpeed = Random.Range(minSpeed, maxSpeed); 
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(randomSpeed, 0);
    }

    private void OnMouseDown()
    {
        GameObject.FindAnyObjectByType<MusicNoteSpawner>().AddValueToProgressBar(1);
        Destroy(gameObject);
    }
}
