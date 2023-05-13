using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceMove : MonoBehaviour
{
    float randomSpeed;
    Rigidbody2D rb;


    [SerializeField] bool red;
    [SerializeField] bool green;
    [SerializeField] bool blue;
    [SerializeField] bool yellow;

    private void Start()
    {
        randomSpeed = Random.Range(2, 5);
        rb = this.GetComponent<Rigidbody2D>();

        if (red)
        {
            rb.velocity = new Vector2(-randomSpeed, 0);
        }
        else if (blue)
        {
            rb.velocity = new Vector2(0, randomSpeed);
        }
        else if (green)
        {
            rb.velocity = new Vector2(randomSpeed, 0);
        }
        else if (yellow)
        {
            rb.velocity = new Vector2(0, -randomSpeed);
        }
        else
        {
            Debug.Log("There is no color, bruh");
        }

    }

    private void OnMouseDown()
    {
        GameObject.FindAnyObjectByType<DanceNoteSpawner>().AddValueToProgressBar(1);
        Destroy(gameObject);
    }
}
