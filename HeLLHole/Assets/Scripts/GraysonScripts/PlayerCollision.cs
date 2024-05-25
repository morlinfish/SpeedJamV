using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public float wallPlatDist = 0.45f;
    public float floorPlatDist = 1f;

    public Rigidbody2D playerRb;
    public GameObject spawnPoint;
    public GameObject wallPlatformR;
    public GameObject wallPlatformL;
    public GameObject floorPlatform;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BadWallR")
        {
            Debug.Log("WallPlatR");

            Instantiate(wallPlatformR, gameObject.transform.position + new Vector3(wallPlatDist, 0, 0), wallPlatformR.transform.rotation);
            gameObject.transform.position = spawnPoint.transform.position;
        }
        else if (collision.gameObject.tag == "BadWallL")
        {
            Debug.Log("WallPlatL");

            Instantiate(wallPlatformL, gameObject.transform.position + new Vector3(-wallPlatDist, 0, 0), wallPlatformL.transform.rotation);
            gameObject.transform.position = spawnPoint.transform.position;
        }
        else if (collision.gameObject.tag == "BadFloor")
        {
            Debug.Log("FloorPlat");
            Instantiate(floorPlatform, gameObject.transform.position + new Vector3(0, -floorPlatDist, 0), floorPlatform.transform.rotation);
            gameObject.transform.position = spawnPoint.transform.position;
            
            Debug.Log("DONE");
        }
    }

}
