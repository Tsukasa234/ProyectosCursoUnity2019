using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "Insert Name Scene Here!!";
    public bool needClick = false;
    public string uuid;
    private Camera sizeCamera;

    private void Start()
    {
        sizeCamera = GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NextSpawnPoint(collision.gameObject.name);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        NextSpawnPoint(collision.gameObject.name);
    }

    private void NextSpawnPoint(string objName)
    {
        if (objName == "Player") 
        {
            if (!needClick || (needClick && Input.GetButtonDown("Action")))
            {
                FindObjectOfType<PlayerController>().nextUUID = uuid;
                SceneManager.LoadScene(newPlaceName);
                CameraSize();
            }
        }
    }

    private void CameraSize()
    {
        if (newPlaceName == "House Interior")
        {
            sizeCamera.orthographicSize = 5;
        }
    }
}
