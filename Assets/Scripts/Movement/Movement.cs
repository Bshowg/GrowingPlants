﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 1.0f;
    private bool moveRight=false;
    private bool moveLeft=false;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || (moveLeft && !moveRight))
            transform.position -= Vector3.right * speed * Time.deltaTime * GameManager.customTimeScale;
        if (Input.GetKey(KeyCode.D) || (moveRight && !moveLeft))
            transform.position += Vector3.right * speed * Time.deltaTime  *GameManager.customTimeScale;

        /*if (moveLeft && !moveRight)
            //rigidbody2D.AddForce(Vector3.left * speed);

        if (moveRight && !moveLeft)
            rigidbody2D.AddForce(Vector2.right * speed);*/
    }

    public void move(Vector2 dir)
    {
        this.transform.position = dir * speed * Time.deltaTime * GameManager.customTimeScale;
    }
    public void startRight()
    {
        //Debug.Log("move");
        //this.transform.position += Vector3.right * speed * Time.deltaTime;
        moveRight = true;
    }

    public void stopRight()
    {
        //Debug.Log("move");
        //this.transform.position += Vector3.right * speed * Time.deltaTime;
        moveRight = false;
    }
    public void startLeft()
    {
        //this.transform.position += -Vector3.right * speed * Time.deltaTime;
        moveLeft = true;
    }
    public void stopLeft()
    {
        //this.transform.position += -Vector3.right * speed * Time.deltaTime;
        moveLeft = false;
    }
}
