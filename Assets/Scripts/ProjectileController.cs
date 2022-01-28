using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Header("Effects")]
    public bool BloodLust_Skill = false;
    [Space]
    [Header("Attack Attribute")]
    public int Attack_Attribute_Fire = 0;
    public int Attack_Attribute_Water = 0;
    public int Attack_Attribute_Earth = 0;
    public int Attack_Attribute_Wind = 0;
    public int Attack_Attribute_Dark = 0;
    public int Attack_Attribute_Holy = 0;
    [Space]
    public GameObject Target;
    public GameObject[] Projectiles;
    public float Reload;
    public float Max_Reload;
    [HideInInspector]
    public bool Have_Effect = false;

    void Start()
    {
        Reload = Max_Reload;
        StartCoroutine(Attack());
    }

    public float ReduceAttackSpeed(float Value)
    {
        Have_Effect = true;
        float value = Reload * Value;
        //print("ReduceAttackSpeed on value: " + value + " in " + gameObject.name);
        return value;
    }

    public float ReturnAttackSpeed()
    {
        Have_Effect = false;
        Reload = Max_Reload;
        //print("ReturnAttackSpeed on value: " + Reload + " in " + gameObject.name);
        return Reload;
    }

    IEnumerator Attack()
    {
        while (true)
        {
            if (Target != null)
            {
                ProjectileControl();
                GameObject bullet = Projectiles[a];
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
                bullet.GetComponent<ProjectileMove>().Target = Target;

                bullet.GetComponent<ProjectileMove>().ProjectileInfo(Target.transform.position,
                    Attack_Attribute_Fire,
                    Attack_Attribute_Water,
                    Attack_Attribute_Earth,
                    Attack_Attribute_Wind,
                    Attack_Attribute_Dark,
                    Attack_Attribute_Holy);

                if (BloodLust_Skill)
                    GetComponent<BloodLust>().PlusBloodCounter(Target);
            }
            yield return new WaitForSeconds(Reload);
        }
    }

    int a = 0;
    public void ProjectileControl()
    {
        for(int i = 0; i < Projectiles.Length; i++)
        {
            if (Projectiles[i].activeInHierarchy)
                continue;
            else
            {
                a = i;
            }
        }
    }

    public void StartFreeze(int Value)
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(FreezeTarget(Value));
        }
    }

    IEnumerator FreezeTarget(int value)
    {
        if (GetComponent<CharapterInfo>().Frezee == false)
        {
            Reload = ReduceAttackSpeed(3);
            GetComponent<CharapterInfo>().Frezee = true;
            yield return new WaitForSeconds(value);
            Reload = ReturnAttackSpeed();
            GetComponent<CharapterInfo>().Frezee = false;
        }
    }
}
