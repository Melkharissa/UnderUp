using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleDetector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Transform enemy = transform.parent;
            enemy.GetComponent<EnemyController>().Player = collision.gameObject;
            collision.GetComponent<CharapterController>().ChangeSpeed(1.75f);
            collision.GetComponent<ProjectileController>().Target = enemy.gameObject;
            enemy.GetComponent<ProjectileController>().Target = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Transform enemy = transform.parent;
            enemy.GetComponent<EnemyController>().Player = null;
            collision.GetComponent<CharapterController>().ReturnSpeed();
            collision.GetComponent<ProjectileController>().Target = null;
            enemy.GetComponent<ProjectileController>().Target = null;
        }
    }
}
