using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticker : MonoBehaviour
{
    public float MoveSpeed;
    Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (rigidbody != null) 
        {
            if (GamePadController.Ins.MoveLeft && transform.position.x >= -3.5)
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            if (GamePadController.Ins.MoveRight && transform.position.x <= 3.5)
                transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }
    }
}
