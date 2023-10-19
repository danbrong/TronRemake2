using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Movement Keys
    public KeyCode W;
    public KeyCode A;
    public KeyCode S;
    public KeyCode D;

    // General Variables
    public float initialSpeed;
    public float speed;
    public float xMove = 0;
    public float yMove = 1;
    Rigidbody pbody;
    public GameObject player;
    public GameObject cpu;
    public Collider pCollider;

    float tiltZ;
    bool upReverse = false;
    bool downReverse = true;
    bool leftReverse = true;
    bool rightReverse = true;

    // Rotation Variables
    private Vector2 direction;
    private Quaternion rotation = Quaternion.identity;
    private Vector2 zero = Vector2.zero;

    // UI Variables
    public TextMeshProUGUI loseMsg;

    // Start is called before the first frame update
    void Start()
    {
        // Find RigidBody on Player Object
        pbody = GetComponent<Rigidbody>();
        pCollider = GetComponent<Collider>();
        

        // Initial Player Movement
        speed = initialSpeed;
        pbody.velocity = new Vector3(xMove, yMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    // Effects of Collision
    private void OnTriggerEnter(Collider other)
    {
        CPUMove cpMove = cpu.GetComponent<CPUMove>();
        cpMove.speed = 0;
        cpMove.initialSpeed = 0;
        cpMove.cCollider.enabled = false;

        loseMsg.enabled = true;

        player.SetActive(false);
    }


    // Player Movement Function
    void Move()
    {
        // Player Rotation
        direction = zero;
        transform.rotation = rotation;


        // Movement Input
        if (Input.GetKeyDown(W))
        {
            if (upReverse == false)
            {
                xMove = 0;
                yMove = 1;
                speed = speed * 2;
            }
            else if (downReverse == false)
            {
                xMove = 0;
                yMove = -1;
                speed = speed / 2;
            }
            else
            {
                xMove = 0;
                yMove = 1;
                upReverse = false;
                downReverse = true;
                leftReverse = true;
                rightReverse = true;
                direction.y += 1;
            }
        }
        if (Input.GetKeyDown(S))
        {
            if (downReverse == false)
            {
                xMove = 0;
                yMove = -1;
                speed = speed * 2;
            }
            else if (upReverse == false)
            {
                xMove = 0;
                yMove = 1;
                speed = speed / 2;
            }
            else
            {
                xMove = 0;
                yMove = -1;
                upReverse = true;
                downReverse = false;
                leftReverse = true;
                rightReverse = true;
                direction.y -= 1;
            }
        }

        if (Input.GetKeyDown(A))
        {
            if (leftReverse == false)
            {
                xMove = -1;
                yMove = 0;
                speed = speed * 2;
            }
            else if (rightReverse == false)
            {
                xMove = 1;
                yMove = 0;
                speed = speed / 2;
            }
            else
            {
                xMove = -1;
                yMove = 0;
                upReverse = true;
                downReverse = true;
                leftReverse = false;
                rightReverse = true;
                direction.x -= 1;
            }
        }

        if (Input.GetKeyDown(D))
        {
            if (rightReverse == false)
            {
                xMove = 1;
                yMove = 0;
                speed = speed * 2;
            }
            else if (leftReverse == false)
            {
                xMove = -1;
                yMove = 0;
                speed = speed / 2;
            }
            else
            {
                xMove = 1;
                yMove = 0;
                speed = speed;
                upReverse = true;
                downReverse = true;
                leftReverse = true;
                rightReverse = false;
                direction.x += 1;
            }
        }

        // Return to Base speed after control change
        if (Input.GetKeyUp(W))
        {
            speed = initialSpeed;
        }
        if (Input.GetKeyUp(S))
        {
            speed = initialSpeed;
        }
        if (Input.GetKeyUp(A))
        {
            speed = initialSpeed;
        }
        if (Input.GetKeyUp(D))
        {
            speed = initialSpeed;
        }
        // Final Move and Rotation Value
        pbody.velocity = new Vector3(xMove, yMove, 0) * speed;

        //So we remain in the last rotation set when player releases keys rather than flipping back to default.
        if (direction != zero)
        {
            rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}