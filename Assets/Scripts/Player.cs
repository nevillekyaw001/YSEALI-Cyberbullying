using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 targetPos;

    [SerializeField] float groundLevel;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    private void Move()
    {
        if(Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            targetPos.y = groundLevel;
        }

        transform.position = Vector3.MoveTowards(transform.position,targetPos, moveSpeed * Time.deltaTime);
    }
}
