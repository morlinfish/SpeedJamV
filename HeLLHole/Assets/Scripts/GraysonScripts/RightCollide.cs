using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollide : MonoBehaviour
{
    // Start is called before the first frame update
    public float wallPlatDist = 0.45f;

    public Rigidbody2D playerRb;
    public GameObject spawnPoint;
    public GameObject floorPlatform;
    public GameObject wallPlatformR;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BadWall")
        {
            Debug.Log("WallPlatR");

            Instantiate(wallPlatformR, gameObject.transform.position + new Vector3(wallPlatDist, 0, 0), wallPlatformR.transform.rotation);
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
