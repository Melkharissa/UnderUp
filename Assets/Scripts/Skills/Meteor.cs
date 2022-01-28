using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int Damage;
    public float CooldownTime = 1f;
    public GameObject _Meteor;
    public int DamageForlvl = 0;
    public float CooldownForLvl = 0;

    private void Start()
    {
        StartCoroutine(MeteorAttack());
    }

    public void LvlUpSkill()
    {
        Damage = Damage + DamageForlvl;
        CooldownTime = CooldownTime - CooldownForLvl;
    }

    IEnumerator MeteorAttack()
    {
        while (true)
        {
            if (GetComponent<ProjectileController>().Target != null)
            {
                Vector3 v3 = GetComponent<ProjectileController>().Target.transform.position;
                _Meteor.transform.position = new Vector3(v3.x, v3.y + 1.4f, -3f);
                _Meteor.SetActive(true);
                _Meteor.GetComponent<MeteorEffect_Script>().Target = GetComponent<ProjectileController>().Target;
                _Meteor.GetComponent<MeteorEffect_Script>().Damage = Damage;
                yield return new WaitForSeconds(CooldownTime);
            }
            yield return new WaitForSeconds(0.35f);
        }
    }
}
