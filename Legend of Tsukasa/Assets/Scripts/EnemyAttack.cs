using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //public float timeToRevivePlayer;
    //private float timeReviveCounter;
    //private bool playerRevival;
    public int damage;
    public GameObject canvasDamage;

    private CharacterStats stats;

    //private GameObject thePlayer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            int totalDamage = Mathf.Clamp(damage / stats.defenseLevels[stats.level], 1, 9999);

            collision.gameObject.GetComponent<LifeManager>().DamageCharacter(totalDamage);

            var clone = (GameObject)Instantiate(canvasDamage, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagepoint = totalDamage;

            collision.gameObject.GetComponent<LifeManager>().DamageCharacter(totalDamage);
        }
    }
}
