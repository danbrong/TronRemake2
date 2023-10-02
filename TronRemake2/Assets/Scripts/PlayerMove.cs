using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Movement Keys
    public KeyCode W;
    public KeyCode A;
    public KeyCode S;
    public KeyCode D;

    // Variable Declaration
    public float speed;
    public float xMoveInitial = 0;
    public float yMoveInitial = 1;
    Rigidbody rigb;

    float upMove = 1;
    float downMove = -1;
    float leftMove = -1;
    float rightMove = 1;
    bool upReverse = false;
    bool downReverse = true;
    bool leftReverse = true;
    bool rightReverse = true;

    float directionXmove;
    float directionYmove;

    private Vector2 direction;
    private Quaternion rotation = Quaternion.identity;
    private Vector2 zero = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        // Find RigidBody on Player Object
        rigb = GetComponent<Rigidbody>();

        // Initial Player Movement
        rigb.velocity = new Vector3(xMoveInitial, yMoveInitial, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // EXPERIMENTAL: Trying to connect movement direction with reverse status
        if (Input.GetKey(W))
            directionYmove = 1;

        if (directionYmove == 1)
            upReverse = false;
            downReverse = true;
            leftReverse = true;
            rightReverse = true;

        if (Input.GetKey(S))
            directionYmove = -1;

        if (directionYmove == -1)
            upReverse = true;
            downReverse = false;
            leftReverse = true;
            rightReverse = true;

        if (Input.GetKey(A))
            directionXmove = -1;

        if (directionXmove == -1)
            upReverse = true;
            downReverse = true;
            leftReverse = false;
            rightReverse = true;

        if (Input.GetKey(D))
            directionXmove = 1;

        if (directionXmove == 1)
            upReverse = true;
            downReverse = true;
            leftReverse = true;
            rightReverse = false;

        Rotate();
        Move();
    }

    void Move()
    {
        // Movement Code From Internet
        //transform.position += (Vector3)(direction * speed * Time.deltaTime);
        transform.rotation = rotation;

        // Movement Code Redux
        if (Input.GetKeyDown(W) && upReverse == false)
            rigb.velocity = new Vector3(0, upMove, 0) * (speed *2);
        if (Input.GetKeyDown(W) && downReverse == false)
            rigb.velocity = new Vector3(0, upMove, 0) * (speed / 2);
        if (Input.GetKeyDown(W) && upReverse == true)
            rigb.velocity = new Vector3(0, upMove, 0) * speed;
        if (Input.GetKeyDown(W) && downReverse == true)
            rigb.velocity = new Vector3(0, upMove, 0) * speed;


        if (Input.GetKeyDown(S) && downReverse == false)
            rigb.velocity = new Vector3(0, downMove, 0) * (speed * 2);
        if (Input.GetKeyDown(S) && upReverse == false)
            rigb.velocity = new Vector3(0, downMove, 0) * (speed / 2);
        if (Input.GetKeyDown(S) && downReverse == true)
            rigb.velocity = new Vector3(0, downMove, 0) * speed;
        if (Input.GetKeyDown(S) && upReverse == true)
            rigb.velocity = new Vector3(0, downMove, 0) * speed;

        
        if (Input.GetKeyDown(A) && leftReverse == false)
            rigb.velocity = new Vector3(leftMove, 0, 0) * (speed * 2);
        if (Input.GetKeyDown(A) && rightReverse == false)
            rigb.velocity = new Vector3(leftMove, 0, 0) * (speed / 2);
        if (Input.GetKeyDown(A) && leftReverse == true)
            rigb.velocity = new Vector3(leftMove, 0, 0) * speed;
        if (Input.GetKeyDown(A) && rightReverse == true)
            rigb.velocity = new Vector3(leftMove, 0, 0) * speed;


        if (Input.GetKeyDown(D) && rightReverse == false)
            rigb.velocity = new Vector3(rightMove, 0, 0) * (speed * 2);
        if (Input.GetKeyDown(D) && leftReverse == false)
            rigb.velocity = new Vector3(rightMove, 0, 0) * (speed / 2);
        if (Input.GetKeyDown(D) && rightReverse == true)
            rigb.velocity = new Vector3(rightMove, 0, 0) * speed;
        if (Input.GetKeyDown(D) && leftReverse == true)
            rigb.velocity = new Vector3(rightMove, 0, 0) * speed;
        

        // ARCHIVE: Original Player Movement
        // Read Player Input and Get Corresponding Direction

        //float xMove = Input.GetAxisRaw("Horizontal");
        //float yMove = Input.GetAxisRaw("Vertical");

        // Player Movement Change based on Input
        //if (xMove == -1)
        //{
        //    rigb.velocity = new Vector3(xMove, 0, 0) * speed;
        //}
        //if (xMove == 1)
        //{
        //    rigb.velocity = new Vector3(xMove, 0, 0) * speed;
        //}
        //if (yMove == -1)
        //{
        //    rigb.velocity = new Vector3(0, yMove, 0) * speed;
        //}
        //if (yMove == 1)
        //{
        //    rigb.velocity = new Vector3(0, yMove, 0) * speed;
        //}
    }


    // Player Rotation Control based on Input
    private void Rotate()
    {
        direction = zero;

        if (Input.GetKey(W))
        {
            direction.y += 1;
        }

        if (Input.GetKey(S))
        {
            direction.y -= 1;
        }

        if (Input.GetKey(A))
        {
            direction.x -= 1;
        }

        if (Input.GetKey(D))
        {
            direction.x += 1;
        }

        //So we remain in the last rotation set when player releases keys rather than flipping back to default.
        if (direction != zero)
        {
            rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
