using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float damageSpeed;
    public float damagepoint;

    public Vector2 direction = new Vector2(1, 0);
    public float timeToDirection = 1;
    private float timeToDirectionCounter = 1;

    public TMP_Text damageText;

    // Update is called once per frame
    void Update()
    {

        timeToDirectionCounter -= Time.deltaTime;

        if (timeToDirectionCounter < timeToDirectionCounter/2)
        {
            direction *= -1;
            timeToDirectionCounter += timeToDirection;
        }


        damageText.text = "" + damagepoint;
        this.transform.position = new Vector3(this.transform.position.x + direction.x * damageSpeed * Time.deltaTime, 
                                                this.transform.position.y + damageSpeed * Time.deltaTime, 
                                                this.transform.position.z);

        this.transform.localScale = this.transform.localScale * (1 - Time.deltaTime / 10);
    }
}
