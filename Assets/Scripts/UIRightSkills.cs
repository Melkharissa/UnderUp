using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRightSkills : MonoBehaviour
{
    public GameObject[] UISkills;
    public GameObject[] RainbowProjectiles;
    public GameObject[] FreezeProjectiles;
    public GameObject[] FireProjectiles;
    public GameObject Charapter;
    public int lastSkill = 0;
    int serialnumber;
    public enum Skill {Zero, LightningBolt, Meteor, PosionSpears, RainbowProjectile, Bloodlist, FreezeProjectile, FireProjectile};
    public Skill skill = Skill.Zero;

    public void GetSkill(Sprite sprite, int serialNumber, string txt)
    {
        GetComponent<Image>().sprite = sprite;
        transform.GetChild(0).GetComponent<Text>().text = txt;
        if(lastSkill != serialNumber) 
        {
            switch (lastSkill)
            {
                case 1:
                    skill = Skill.LightningBolt;
                    UISkills[0].GetComponent<UILeftSkills>().setActive();
                    Charapter.GetComponent<Lightning>().enabled = false;
                    break;
                case 2:
                    skill = Skill.Meteor;
                    UISkills[1].GetComponent<UILeftSkills>().setActive();
                    Charapter.GetComponent<Meteor>().enabled = false;
                    break;
                case 3:
                    skill = Skill.PosionSpears;
                    UISkills[2].GetComponent<UILeftSkills>().setActive();
                    Charapter.GetComponent<PoisonSpears>().enabled = false;
                    break;
                case 4:
                    skill = Skill.RainbowProjectile;
                    UISkills[3].GetComponent<UILeftSkills>().setActive();
                    for (int i = 0; i < 8; i++)
                    {
                        Charapter.GetComponent<ProjectileController>().Projectiles[i] = FireProjectiles[i];
                    }
                    break;
                case 5:
                    skill = Skill.Bloodlist;
                    UISkills[4].GetComponent<UILeftSkills>().setActive();
                    Charapter.GetComponent<BloodLust>().enabled = false;
                    Charapter.GetComponent<ProjectileController>().BloodLust_Skill = false;
                    break;
                case 6:
                    skill = Skill.FreezeProjectile;
                    UISkills[5].GetComponent<UILeftSkills>().setActive();
                    for (int i = 0; i < 8; i++)
                    {
                        Charapter.GetComponent<ProjectileController>().Projectiles[i] = FireProjectiles[i];
                    }
                    break;
                case 7:
                    skill = Skill.FireProjectile;
                    UISkills[6].GetComponent<UILeftSkills>().setActive();
                    for (int i = 0; i < 8; i++)
                    {
                        Charapter.GetComponent<ProjectileController>().Projectiles[i] = FireProjectiles[i];
                    }
                    break;
            }
        }

            switch (serialNumber)
            {
                case 1:
                    skill = Skill.LightningBolt;
                    Charapter.GetComponent<Lightning>().enabled = true;
                    break;
                case 2:
                    skill = Skill.Meteor;
                    Charapter.GetComponent<Meteor>().enabled = true;
                    break;
                case 3:
                    skill = Skill.PosionSpears;
                    Charapter.GetComponent<PoisonSpears>().enabled = true;
                    break;
                case 4:
                    skill = Skill.RainbowProjectile;
                    for (int i = 0; i < 8; i++)
                    {
                        Charapter.GetComponent<ProjectileController>().Projectiles[i] = RainbowProjectiles[i];
                    }
                    break;
                case 5:
                    skill = Skill.Bloodlist;
                    Charapter.GetComponent<BloodLust>().enabled = true;
                    Charapter.GetComponent<ProjectileController>().BloodLust_Skill = true;
                    break;
                case 6:
                    skill = Skill.FreezeProjectile;
                    for (int i = 0; i < 8; i++)
                    {
                        Charapter.GetComponent<ProjectileController>().Projectiles[i] = FreezeProjectiles[i];
                    }
                    break;
                case 7:
                    skill = Skill.FireProjectile;
                    for (int i = 0; i < 8; i++)
                    {
                        Charapter.GetComponent<ProjectileController>().Projectiles[i] = FireProjectiles[i];
                    }
                    break;
            }

        lastSkill = serialNumber;
        serialnumber = serialNumber;
    }
}
