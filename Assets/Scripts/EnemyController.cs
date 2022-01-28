using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public float DistForMove = 2f;
    public float Speed = 2.5f;
    public Sprite[] Idle = new Sprite[0];
    Vector2 DefaultPosition;
    public Vector2 MovePoint;
    Rigidbody2D r2D;

    private void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
        DefaultPosition = transform.position;
        GetComponent<C_Animation>().StartAnimation(Idle, "Idle");
        InvokeRepeating("IdleMove", 1f, 2f);
    }

    void IdleMove()
    {
        float x = Random.Range(DefaultPosition.x, DefaultPosition.x + 2.5f);
        float y = Random.Range(DefaultPosition.y, DefaultPosition.y + 2.5f);
        MovePoint = new Vector3(x, y, -1f);
    }

    private void Update()
    {
        if (Player == null)
        {
            Vector2 myV2 = transform.position;
            float dist = Vector2.Distance(myV2, MovePoint);
            if (dist > 0.1f)
            {
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -1f), new Vector3(MovePoint.x, MovePoint.y, -1f), Speed * Time.deltaTime);
            }
        }
        //else
        //{
        //    Vector2 myV2 = transform.position;
        //    float dist = Vector2.Distance(myV2, Player.transform.position);
        //    if (dist > DistForMove)
        //    {
        //        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -1f), new Vector3(Player.transform.position.x, Player.transform.position.y, -1f), Speed * Time.deltaTime);
        //    }
        //}
    }

}
