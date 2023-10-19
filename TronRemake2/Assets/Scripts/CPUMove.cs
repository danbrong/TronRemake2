using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CPUMove : MonoBehaviour
{
    // General Variables
    public float initialSpeed;
    public float speed;
    public float xMove = 0;
    public float yMove = -1;
    Rigidbody cbody;
    public GameObject player;
    public GameObject cpu;
    public Collider cCollider;

    private float tiltZ;
    bool upReverse = true;
    bool downReverse = false;
    bool leftReverse = true;
    bool rightReverse = true;

    // Secondary Variables
    public float delay;
    public float delay2;
    float timer;
    float timer2;
    private Ray ray;
    private RaycastHit hit;
    public float rayDistance;

    // Rotation Variables
    private Vector2 directionFace;
    private Quaternion rotation = Quaternion.Euler(0, 0, -180);
    private Vector2 zero = Vector2.zero;

    // UI Variables
    public TextMeshProUGUI winMsg;

    // Start is called before the first frame update
    void Start()
    {
        // Find RigidBody on Player Object
        cbody = GetComponent<Rigidbody>();
        cCollider = GetComponent<Collider>();
        

        // Initial Player Movement
        speed = initialSpeed;
        cbody.velocity = new Vector3(xMove, yMove, 0) * speed;
        directionFace = zero;
       
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast Targetting
        ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        Move();

    }

    // Code to Stop Player Movement on Collision
    private void OnTriggerEnter(Collider other)
    {
        GameObject WinMsg = GameObject.Find("HUDWinMsg");
        PlayerMove playMove = player.GetComponent<PlayerMove>();
        playMove.speed = 0;
        playMove.initialSpeed = 0;
        playMove.pCollider.enabled = false;

        winMsg.enabled = true;
        cpu.SetActive(false);
    }

    // Player Movement Function
    void Move()
    {
        // CPU Rotation
        transform.rotation = rotation;
        timer += Time.deltaTime;

        if (timer > delay2)
        {
            // Random Direction choice
            float randomNum2 = Random.Range(0, 3);

            if (downReverse == false)
            {
                switch (randomNum2)
                {
                    case 0:
                        xMove = -1;
                        yMove = 0;
                        timer = 0;
                        directionFace = Vector2.left;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = false;
                        rightReverse = true;
                        break;

                    case 1:
                        xMove = 1;
                        yMove = 0;
                        timer = 0;
                        directionFace = Vector2.right;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = false;
                        break;

                    case 2:
                        xMove = 0;
                        yMove = -1;
                        timer = 0;
                        directionFace = Vector2.down;

                        upReverse = true;
                        downReverse = false;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                }
            }

            else if (leftReverse == false)
            {
                switch (randomNum2)
                {
                    case 0:
                        xMove = 0;
                        yMove = -1;
                        timer = 0;
                        directionFace = Vector2.down;

                        upReverse = true;
                        downReverse = false;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                    case 1:
                        xMove = 0;
                        yMove = 1;
                        timer = 0;
                        directionFace = Vector2.up;

                        upReverse = false;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                    case 2:
                        xMove = -1;
                        yMove = 0;
                        timer = 0;
                        directionFace = Vector2.left;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = false;
                        rightReverse = true;
                        break;
                }
            }

            else if (rightReverse == false)
            {
                switch (randomNum2)
                {
                    case 0:
                        xMove = 0;
                        yMove = -1;
                        timer = 0;
                        directionFace = Vector2.down;

                        upReverse = true;
                        downReverse = false;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                    case 1:
                        xMove = 0;
                        yMove = 1;
                        timer = 0;
                        directionFace = Vector2.up;

                        upReverse = false;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = true;
                        break;

                    case 2:
                        xMove = 1;
                        yMove = 0;
                        timer = 0;
                        directionFace = Vector2.right;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = false;
                        break;

                }
            }

            else if (upReverse == false)
            {
                switch (randomNum2)
                {


                    case 0:
                        xMove = 1;
                        yMove = 0;
                        timer = 0;
                        directionFace = Vector2.right;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = false;
                        break;

                    case 1:
                        xMove = -1;
                        yMove = 0;
                        timer = 0;
                        directionFace = Vector2.left;

                        upReverse = true;
                        downReverse = true;
                        leftReverse = false;
                        rightReverse = true;
                        break;

                    case 2:
                        xMove = 0;
                        yMove = 1;
                        timer = 0;
                        directionFace = Vector2.up;

                        upReverse = false;
                        downReverse = true;
                        leftReverse = true;
                        rightReverse = true;
                        break;
                }
            }
        }

        // Raycast Movement Response
        if (Physics.Raycast(ray, out hit))
        {
            if (timer > delay)
            {
                if (hit.distance < rayDistance)
                {
                    // Random Direction choice
                    float randomNum = Random.Range(0, 2);

                    if (downReverse == false)
                    {
                        switch (randomNum)
                        {
                            case 0:
                                xMove = -1;
                                yMove = 0;
                                timer = 0;
                                directionFace = Vector2.left;

                                upReverse = true;
                                downReverse = true;
                                leftReverse = false;
                                rightReverse = true;
                                break;

                            case 1:
                                xMove = 1;
                                yMove = 0;
                                timer = 0;
                                directionFace = Vector2.right;

                                upReverse = true;
                                downReverse = true;
                                leftReverse = true;
                                rightReverse = false;
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
                                directionFace = Vector2.down;

                                upReverse = true;
                                downReverse = false;
                                leftReverse = true;
                                rightReverse = true;
                                break;

                            case 1:
                                xMove = 0;
                                yMove = 1;
                                timer = 0;
                                directionFace = Vector2.up;

                                upReverse = false;
                                downReverse = true;
                                leftReverse = true;
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
                                directionFace = Vector2.down;

                                upReverse = true;
                                downReverse = false;
                                leftReverse = true;
                                rightReverse = true;
                                break;

                            case 1:
                                xMove = 0;
                                yMove = 1;
                                timer = 0;
                                directionFace = Vector2.up;

                                upReverse = false;
                                downReverse = true;
                                leftReverse = true;
                                rightReverse = true;
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
                                directionFace = Vector2.right;

                                upReverse = true;
                                downReverse = true;
                                leftReverse = true;
                                rightReverse = false;
                                break;

                            case 1:
                                xMove = -1;
                                yMove = 0;
                                timer = 0;
                                directionFace = Vector2.left;

                                upReverse = true;
                                downReverse = true;
                                leftReverse = false;
                                rightReverse = true;
                                break;
                        }
                    }
                }
            }
        }

        // Final Move and Rotation Value
        cbody.velocity = new Vector3(xMove, yMove, 0) * speed;

        //So we remain in the last rotation set when player releases keys rather than flipping back to default.
        if (directionFace != zero)
        {
            rotation = Quaternion.LookRotation(Vector3.forward, directionFace);
        }
    }
}
