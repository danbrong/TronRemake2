using System.Collections;
using UnityEngine;

public class TrailGeneration : MonoBehaviour
{
    // Variable Declaration
    public GameObject TrailWall;
    Collider wall;

    // Wall Spawn Function
    void SpawnWall()
    {
        GameObject g = Instantiate(TrailWall);
        wall = g.GetComponent<Collider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        // Copy of SpawnWall Declaration, for some reason helps smooth out movement
        void SpawnWall()
        {
            GameObject g = Instantiate(TrailWall, transform.position, Quaternion.identity);
            wall = g.GetComponent<Collider>();
        }
        SpawnWall();
    }

    
}
