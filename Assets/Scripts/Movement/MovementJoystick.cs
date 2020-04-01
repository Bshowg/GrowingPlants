﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementJoystick : MonoBehaviour
{
    private EventEmitter ee;

    public float maxSpeed;
    public float acceleration;
    private float speed;
    bool facingRight = true;

    public FixedJoystick variableJoystick;

    void Start() {
        ee = GameObject.FindGameObjectWithTag("EventEmitter").GetComponent<EventEmitter>();
        speed = 0f;
    }

    public void FixedUpdate(){
        if (variableJoystick.Horizontal != 0f) {
            Vector3 dir = Vector3.right * Mathf.Sign(variableJoystick.Horizontal);
            movePlayer(dir);
        }
        else if (Input.GetKey(KeyCode.A)) movePlayer(Vector3.left);//changeVelocity(-1f);
        else if (Input.GetKey(KeyCode.D)) movePlayer(Vector3.right);//changeVelocity(1f);
        else {
                    speed = 0;
                }
    }
    private void movePlayer(Vector3 dir) {
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed) speed = maxSpeed;

        transform.position += dir * speed * Time.deltaTime * GameManager.customTimeScale;
        if ((dir.x > 0) ^ facingRight) Flip(); 
    }

    /*
    private void changeVelocity(float f){
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed) speed = maxSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(f * speed * GameManager.customTimeScale, GetComponent<Rigidbody2D>().velocity.y * GameManager.customTimeScale);


        if (f > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (f < 0 && facingRight)
            // ... flip the player.
            Flip();
    }
    */
    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        //Vector3 theScale =
        this.transform.localScale = Vector3.Scale(new Vector3(-1, 1, 1), this.transform.localScale);
    }

}
