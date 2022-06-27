using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private PlayerController player;
    private CameraFollow camere;
    public Vector2 facingDirection = Vector2.zero;
    public string uuid;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        camere = FindObjectOfType<CameraFollow>();

        if (!player.nextUUID.Equals(uuid))
        {
            return;
        }

        player.lastMovement = facingDirection;

        player.transform.position = this.transform.position;
        camere.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, camere.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
