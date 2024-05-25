using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollide : MonoBehaviour
{

    public float wallPlatDist = 0.45f;

    public Rigidbody2D playerRb;
    public GameObject spawnPoint;
    public GameObject floorPlatform;
    public GameObject wallPlatformL;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BadWall")
        {
            Instantiate(wallPlatformL, gameObject.transform.position + new Vector3(-wallPlatDist, 0, 0), wallPlatformL.transform.rotation);
            player.transform.position = spawnPoint.transform.position;

            Debug.Log("COLLIDEL");
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnWall");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OffWall");
    }*/

}
