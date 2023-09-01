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
    public float xMoveCurrent;
    public float yMoveCurrent;
    Rigidbody rigb;

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
        getInput();
        Move();
    }

    void Move()
    {
        // Movement Code From Internet
        //transform.position += (Vector3)(direction * speed * Time.deltaTime);
        transform.rotation = rotation;


        // Read Player Input and Get Corresponding Direction
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        // Player Movement Change based on Input
        if (xMove == -1)
        {
            rigb.velocity = new Vector3(xMove, 0, 0) * speed;
        }
        if (xMove == 1)
        {
            rigb.velocity = new Vector3(xMove, 0, 0) * speed;
        }
        if (yMove == -1)
        {
            rigb.velocity = new Vector3(0, yMove, 0) * speed;
        }
        if (yMove == 1)
        {
            rigb.velocity = new Vector3(0, yMove, 0) * speed;
        }
    }
    // Keyboard input by player
    private void getInput()
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
