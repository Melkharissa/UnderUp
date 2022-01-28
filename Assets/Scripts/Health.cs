using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Defense Attribute")]
    public int Defense_Attribute_Fire = 0;
    public int Defense_Attribute_Water = 0;
    public int Defense_Attribute_Earth = 0;
    public int Defense_Attribute_Wind = 0;
    public int Defense_Attribute_Dark = 0;
    public int Defense_Attribute_Holy = 0;
    [Space]
    public int HP;
    public int Max_HP;

    private void Start()
    {
        HP = Max_HP = GetComponent<CharapterInfo>().getHP();
    }

    public void MinusHP(int damage, int Fire = 0, int Water = 0, int Earth = 0, int Wind = 0, int Dark = 0, int Holy = 0)
    {
        if (HP > 0)
        {
            int Att_Damage = Fire + Water + Earth + Wind + Dark + Holy;
            HP -= damage + Att_Damage;
            int differenceHp = HP - (damage + Att_Damage);
            if (differenceHp <= 0) HP = 0;
            byte hpcolor = (byte)(HP * 2.55f);
            GetComponent<SpriteRenderer>().color = new Color32(255, hpcolor, hpcolor, 255);
        }
        if (HP <= 0) Death();
    }

    public void Death()
    {
        GetComponent<EnemyController>().enabled = false;
        GetComponent<C_Animation>().enabled = false;
        GetComponent<ProjectileController>().enabled = false;
        if (tag != "Player") GetComponent<DropItems>().Drop();
        gameObject.SetActive(false);
    }

    public void StartBurning(int Time_Value, int Damage_Value, int Attribute, GameObject Sender)
    {
        if (GetComponent<CharapterInfo>().Burn == false)
        {
            int i = 0;
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(Burning(Time_Value, Damage_Value, Attribute, Sender, i));
                GetComponent<CharapterInfo>().Burn = true;
            }
        }
    }

    IEnumerator Burning(int time_value, int damage_value, int attribute, GameObject sender, int i)
    {
        while(i < time_value)
        {
            MinusHP(damage_value, attribute);
            yield return new WaitForSeconds(1);
            i++;
            if (i == time_value)
            {
                GetComponent<CharapterInfo>().Burn = false;
                sender.SetActive(false);
            }
        }
    }

}
