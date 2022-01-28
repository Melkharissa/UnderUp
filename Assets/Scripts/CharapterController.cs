using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharapterController : MonoBehaviour
{
    public Transform Camera;
    public float Speed = 2.5f;
    public float MaxSpeed = 2.5f;
    public Sprite[] Idle = new Sprite[0];
    public Sprite[] Run = new Sprite[0];
    Rigidbody2D r2D;

    private void Start()
    {
        Speed = MaxSpeed;
        r2D = GetComponent<Rigidbody2D>();
        GetComponent<C_Animation>().StartAnimation(Idle, "Idle");
    }


    public float ChangeSpeed(float ValueSpeed)
    {
        return Speed = Speed / ValueSpeed;    
    }

    public float ReturnSpeed()
    {
        return Speed = MaxSpeed;
    }

    private void Update()
    {
        Camera.position = new Vector3(transform.position.x, transform.position.y, -10f);
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(GetComponent<C_Animation>().AnimationName != "Run")
            GetComponent<C_Animation>().StartAnimation(Run, "Run");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (GetComponent<C_Animation>().AnimationName != "Run")
                GetComponent<C_Animation>().StartAnimation(Run, "Run");

            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (GetComponent<C_Animation>().AnimationName != "Run")
                GetComponent<C_Animation>().StartAnimation(Run, "Run");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (GetComponent<C_Animation>().AnimationName != "Run")
                GetComponent<C_Animation>().StartAnimation(Run, "Run");
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (GetComponent<C_Animation>().AnimationName != "Idle")
                GetComponent<C_Animation>().StartAnimation(Idle, "Idle");

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (GetComponent<C_Animation>().AnimationName != "Idle")
                GetComponent<C_Animation>().StartAnimation(Idle, "Idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (GetComponent<C_Animation>().AnimationName != "Idle")
                GetComponent<C_Animation>().StartAnimation(Idle, "Idle");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (GetComponent<C_Animation>().AnimationName != "Idle")
                GetComponent<C_Animation>().StartAnimation(Idle, "Idle");
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            r2D.velocity = Vector2.up * Speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            r2D.velocity = Vector2.left * Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            r2D.velocity = Vector2.down * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            r2D.velocity = Vector2.right * Speed;
        }
    }
}
