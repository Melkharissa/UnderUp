using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemScript : MonoBehaviour
{
    public bool Weapon;
    public int Attack_Fire = 0;
    public int Attack_Water = 0;
    public int Attack_Earth = 0;
    public int Attack_Wind = 0;
    public int Attack_Dark = 0;
    public int Attack_Holy = 0;
    public float Reload;

    private void OnTransformParentChanged()
    {
        if (Weapon)
        {
            transform.parent.GetComponent<ProjectileController>().Reload -= Reload;
            transform.parent.GetComponent<ProjectileController>().Max_Reload -= Reload;
            transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Fire += Attack_Fire;
            transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Water += Attack_Water;
            transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Earth += Attack_Earth;
            transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Wind += Attack_Wind;
            transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Dark += Attack_Dark;
            transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Holy += Attack_Holy;
        }
    }

    public void DestroyItem()
    {
        transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Fire -= Attack_Fire;
        transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Water -= Attack_Water;
        transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Earth -= Attack_Earth;
        transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Wind -= Attack_Wind;
        transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Dark -= Attack_Dark;
        transform.parent.GetComponent<ProjectileController>().Attack_Attribute_Holy -= Attack_Holy;
        transform.parent.GetComponent<ProjectileController>().Max_Reload += Reload;
        transform.parent.GetComponent<ProjectileController>().Reload += Reload;
        Destroy(gameObject);
    }
}
