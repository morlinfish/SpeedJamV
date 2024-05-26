using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDPlatform : MonoBehaviour
{
    public GameObject sdPlatform;
    public GameObject spawnPoint;
    public GameObject player;
    public Transform cameraPos;
    public GameObject spawnPoint2;
    public int sdPlatformUnused = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E-Press");

            if (sdPlatformUnused >= 1)
            {
                Instantiate(sdPlatform, gameObject.transform.position + new Vector3(0, 0, 0), sdPlatform.transform.rotation);
                gameObject.transform.position = spawnPoint.transform.position;
                sdPlatformUnused = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject[] myTriggers = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject trigger in myTriggers)
            {
                Destroy(trigger);
            }

            gameObject.transform.position = spawnPoint.transform.position;
            sdPlatformUnused = 1;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ENDLEVEL1")
        {
            spawnPoint.transform.position = spawnPoint2.transform.position;
            gameObject.transform.position = spawnPoint2.transform.position;
            Camera.main.transform.Translate(23, 5, 0);
            sdPlatformUnused = 1;

            GameObject[] myTriggers = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject trigger in myTriggers)
            {
                Destroy(trigger);
            }
        }
    }
}
