using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSpears : MonoBehaviour
{
    public int Damage_Attribute_Dark = 0;
    public int Damage;
    public float CooldownTime = 10f;
    public GameObject _PoisonSpears;
    public int DamageForlvl = 0;

    private void Start()
    {
        InvokeRepeating("PoisonSpearsAttack", 1f, CooldownTime);
    }

    public void LvlUpSkill()
    {
        Damage = Damage + DamageForlvl;
    }

    void PoisonSpearsAttack()
    {
        if (GetComponent<ProjectileController>().Target != null)
        {
            GameObject poison = Instantiate(_PoisonSpears, _PoisonSpears.transform.position, Quaternion.identity);
            poison.GetComponent<PoisonSpearsEffect_Script>().GetTarget(GetComponent<ProjectileController>().Target);
            Vector3 v3 = GetComponent<ProjectileController>().Target.transform.position;
            poison.transform.position = new Vector3(v3.x, v3.y, -3f);
            poison.GetComponent<PoisonSpearsEffect_Script>().GetTarget(GetComponent<ProjectileController>().Target);
            Damage_Attribute_Dark = GetComponent<ProjectileController>().Attack_Attribute_Dark;
            poison.GetComponent<PoisonSpearsEffect_Script>().Poison_Damage = Damage + Damage_Attribute_Dark;
        }
    }
}
