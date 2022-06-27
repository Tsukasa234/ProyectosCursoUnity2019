using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed;
    private Vector3 targetposition;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        targetposition = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetposition, Time.deltaTime * cameraSpeed);
    }
}
