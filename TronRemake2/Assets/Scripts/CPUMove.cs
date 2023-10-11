using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUMove : MonoBehaviour
{
    // General Variables
    public float initialSpeed;
    private float speed;
    public float xMove = 0;
    public float yMove = -1;
    Rigidbody cbody;

    public float delay;
    public float delay2;
    float timer;
    float timer2;

    float tiltZ;
    bool upReverse = true;
    bool downReverse = false;
    bool leftReverse = true;
    bool rightReverse = true;

    // Rotation Variables
    private Vector2 direction;
    private Quaternion rotation = Quaternion.Euler(0, 0, -180);
    private Vector2 zero = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Find RigidBody on Player Object
        cbody = GetComponent<Rigidbody>();

        // Initial Player Movement
        speed = initialSpeed;
        cbody.velocity = new Vector3(xMove, yMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    // Code to Stop Player Movement on Collision
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        //speed = 0;
    }

    // Player Movement Function
    void Move()
    {
        // Player Rotation
        direction = zero;
        transform.rotation = rotation;

        // Random Direction choice
        float randomNum = Random.Range(0, 3);

        timer += Time.deltaTime;
        if (timer > delay)
        {
            if (downReverse == false)
            {
                switch (randomNum)
                {
                    case 0:
                        xMove = -1;
                        yMove = 0;
                        timer = 0;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = false;
                        rightReverse = true;
                        break;

                    case 1:
                        xMove = 1;
                        yMove = 0;
                        timer = 0;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = false;
                        break;

                    case 2:
                        xMove = 0;
                        yMove = -1;
                        timer = 0;

                        upReverse = true;
                        downReverse = false;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                }
            }

            else if (leftReverse == false)
            {
                switch (randomNum)
                {
                    case 0:
                        xMove = 0;
                        yMove = -1;
                        timer = 0;

                        upReverse = true;
                        downReverse = false;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                    case 1:
                        xMove = 0;
                        yMove = 1;
                        timer = 0;

                        upReverse = false;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                    case 2:
                        xMove = -1;
                        yMove = 0;
                        timer = 0;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = false;
                        rightReverse = true;
                        break;
                }
            }

            else if (rightReverse == false)
            {
                switch (randomNum)
                {
                    

                    case 0:
                        xMove = 0;
                        yMove = -1;
                        timer = 0;

                        upReverse = true;
                        downReverse = false;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                    case 1:
                        xMove = 0;
                        yMove = 1;
                        timer = 0;

                        upReverse = false;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = true;
                        break;
                    
                    case 2:
                        xMove = 1;
                        yMove = 0;
                        timer = 0;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = false;
                        break;

                }
            }

            else if (upReverse == false)
            {
                switch (randomNum)
                {
                    

                    case 0:
                        xMove = 1;
                        yMove = 0;
                        timer = 0;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = false;
                        break;

                    case 1:
                        xMove = -1;
                        yMove = 0;
                        timer = 0;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = false;
                        rightReverse = true;
                        break;

                    case 2:
                        xMove = 0;
                        yMove = 1;
                        timer = 0;

                        upReverse = false;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = true;
                        break;
                }
            }
        }

        //// Delay for Direction Change
        //timer2 += Time.deltaTime;
        //if (timer2 > delay2)
        //{
        //    float randomNum2 = Random.Range(0, 3);

        //    // Switch Case Implementation for Direction
        //    switch (randomNum2)
        //    {
        //        case 0:
        //            timer2 = 0;
        //            break;
        //        case 1:
        //            transform.Rotate(0, 0, 90);
        //            timer2 = 0;
        //            break;
        //        case 2:
        //            transform.Rotate(0, 0, -90);
        //            timer2 = 0;
        //            break;
        //    }
        //}

        // Final Move and Rotation Value
        cbody.velocity = new Vector3(xMove, yMove, 0) * speed;

        //So we remain in the last rotation set when player releases keys rather than flipping back to default.
        if (direction != zero)
        {
            rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
