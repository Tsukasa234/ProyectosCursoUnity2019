using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;

    public GameObject bloodAnimation;
    public GameObject swingPoint;
    private GameObject currentAnim;
    public GameObject canvasDamage;

    private CharacterStats stats;

    private void Start()
    {
        swingPoint = transform.Find("SwingPoint").gameObject;
        stats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            int totalDamage = damage + stats.attackLevels[stats.level];

            if (bloodAnimation != null && swingPoint != null)
            {
                currentAnim = Instantiate(bloodAnimation, swingPoint.transform.position, swingPoint.transform.rotation);

                Invoke("DestroyTime", 0.5f);
            }

            var clone = (GameObject)Instantiate(canvasDamage, swingPoint.transform.position, Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagepoint = totalDamage;

            collision.gameObject.GetComponent<LifeManager>().DamageCharacter(totalDamage);
        }
    }

    void DestroyTime()
    {
        Destroy(currentAnim);
    }
}
