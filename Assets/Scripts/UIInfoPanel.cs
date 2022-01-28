using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoPanel : MonoBehaviour
{
    public GameObject Charapter;
    public Text[] text_attack_attribute;
    public Text[] text_resist_attribute;
    public Text[] text_stats;

    public void OnEnable()
    {
        text_attack_attribute[0].text = Charapter.GetComponent<ProjectileController>().Attack_Attribute_Fire.ToString() + "/55";
        text_attack_attribute[1].text = Charapter.GetComponent<ProjectileController>().Attack_Attribute_Water.ToString() + "/55";
        text_attack_attribute[2].text = Charapter.GetComponent<ProjectileController>().Attack_Attribute_Earth.ToString() + "/55";
        text_attack_attribute[3].text = Charapter.GetComponent<ProjectileController>().Attack_Attribute_Wind.ToString() + "/55";
        text_attack_attribute[4].text = Charapter.GetComponent<ProjectileController>().Attack_Attribute_Dark.ToString() + "/55";
        text_attack_attribute[5].text = Charapter.GetComponent<ProjectileController>().Attack_Attribute_Holy.ToString() + "/55";
        text_resist_attribute[0].text = Charapter.GetComponent<Health>().Defense_Attribute_Fire.ToString() + "/55";
        text_resist_attribute[1].text = Charapter.GetComponent<Health>().Defense_Attribute_Water.ToString() + "/55";
        text_resist_attribute[2].text = Charapter.GetComponent<Health>().Defense_Attribute_Earth.ToString() + "/55";
        text_resist_attribute[3].text = Charapter.GetComponent<Health>().Defense_Attribute_Wind.ToString() + "/55";
        text_resist_attribute[4].text = Charapter.GetComponent<Health>().Defense_Attribute_Dark.ToString() + "/55";
        text_resist_attribute[5].text = Charapter.GetComponent<Health>().Defense_Attribute_Holy.ToString() + "/55";
        text_stats[0].text = "Health: " + Charapter.GetComponent<Health>().HP.ToString();
        text_stats[1].text = "Atk Spd: " + Charapter.GetComponent<ProjectileController>().Reload.ToString();
        text_stats[2].text = "M Spd: " + Charapter.GetComponent<CharapterController>().Speed.ToString();
    }
}
