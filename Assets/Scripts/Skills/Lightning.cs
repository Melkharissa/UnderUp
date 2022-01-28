using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public int Damage_Attribute_Wind = 0;
    public int Damage;
    public float CooldownTime = 1f;
    public GameObject LightningBolt;
    public int DamageForlvl = 0;
    public float CooldownForLvl = 0;

    private void Start()
    {
        StartCoroutine(LightningAttack());    
    }

    public void LvlUpSkill()
    {
        Damage = Damage + DamageForlvl;
        CooldownTime = CooldownTime - CooldownForLvl;
    }

    IEnumerator LightningAttack()
    {
        while (true)
        {
            if(GetComponent<ProjectileController>().Target != null)
            {
                Vector3 v3 = GetComponent<ProjectileController>().Target.transform.position;
                LightningBolt.transform.position = new Vector3(v3.x, v3.y + 1.4f, -3f);
                LightningBolt.SetActive(true);
                LightningBolt.GetComponent<LightningEffect_Script>().Target = GetComponent<ProjectileController>().Target;
                Damage_Attribute_Wind = GetComponent<ProjectileController>().Attack_Attribute_Wind;
                LightningBolt.GetComponent<LightningEffect_Script>().Damage = Damage + Damage_Attribute_Wind;
                yield return new WaitForSeconds(CooldownTime);
            }
            yield return new WaitForSeconds(0.35f);
        }
    }
}
