using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField]
    int Weapon_Attribute_Fire = 0;
    [SerializeField]
    int Weapon_Attribute_Water = 0;
    [SerializeField]
    int Weapon_Attribute_Earth = 0;
    [SerializeField]
    int Weapon_Attribute_Wind = 0;
    [SerializeField]
    int Weapon_Attribute_Dark = 0;
    [SerializeField]
    int Weapon_Attribute_Holy = 0;
    [SerializeField]
    [Space]
    public bool Freeze = false;
    public int Freeze_Time = 0;
    public int Freeze_Max_Time = 3;
    public bool Burn = false;
    public int Burn_Damage = 1;
    public int Burn_Time = 0;
    public int Burn_Max_Time = 3;
    public bool Acid = false;
    public int Acid_Time = 0;
    public int Acid_Max_Time = 3;
    [Space]
    public bool Explosion = false;
    public GameObject[] Explosion_Effect;
    Rigidbody2D r2D;
    public GameObject Parent;
    public int Damage;
    Vector3 DefaultPosition;
    public GameObject Target;
    public Vector3 TargetTransform;
    public float Speed;
    public int DamageForlvl = 0;

    private void Start()
    {
        Burn_Time = Burn_Max_Time;
        Freeze_Time = Freeze_Max_Time;
        Acid_Time = Acid_Max_Time;
        r2D = GetComponent<Rigidbody2D>();
    }

    public void LvlUpSkill()
    {
        Damage = Damage + DamageForlvl;
    }

    public void ProjectileInfo(Vector3 targetPosition, int Fire = 0, int Water = 0, int Earth = 0, int Wind = 0, int Dark = 0, int Holy = 0)
    {
        TargetTransform = targetPosition;
        Weapon_Attribute_Fire = Fire;
        Weapon_Attribute_Water = Water;
        Weapon_Attribute_Earth = Earth;
        Weapon_Attribute_Wind = Wind;
        Weapon_Attribute_Dark = Dark;
        Weapon_Attribute_Holy = Holy;
    }

    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 myV21 = transform.position;
            float dist1 = Vector2.Distance(myV21, Target.transform.position);

            if(dist1 <= 0.15f)
            {
                Target.GetComponent<Health>().MinusHP(Damage + BloodLust.Blood_Counter,
                    Weapon_Attribute_Fire,
                    Weapon_Attribute_Water,
                    Weapon_Attribute_Earth,
                    Weapon_Attribute_Wind,
                    Weapon_Attribute_Dark,
                    Weapon_Attribute_Holy);

                ReturnProjectile();
            }

            Vector2 myV2 = transform.position;
            float dist = Vector2.Distance(myV2, TargetTransform);
            if (dist >= 0.1f)
            {
                Vector3 v3 = TargetTransform - transform.position;
                r2D.AddForce(v3 * Speed);
            }
            else
            {
                ReturnProjectile();
            }
        }
    }

    int a = 0;
    public void CreateExplosion()
    {
        for (int i = 0; i < Explosion_Effect.Length; i++)
        {
            if (Explosion_Effect[i].GetComponent<ParticleSystem>().isPlaying)
                continue;
            else
            {
                a = i;
            }
        }

        Explosion_Effect[a].transform.position = gameObject.transform.position;
        Explosion_Effect[a].GetComponent<ParticleSystem>().Play();

    }

    public void ReturnProjectile()
    {
        if (Explosion)
            CreateExplosion();
        if (Freeze)
            Target.GetComponent<ProjectileController>().StartFreeze(Freeze_Time);
        if(Burn)
            Target.GetComponent<Health>().StartBurning(Burn_Time, Burn_Damage, Weapon_Attribute_Fire, gameObject);
        gameObject.SetActive(false);
    }
}
