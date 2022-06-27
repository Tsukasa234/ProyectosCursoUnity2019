using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
