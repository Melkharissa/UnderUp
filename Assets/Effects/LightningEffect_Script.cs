using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect_Script : MonoBehaviour
{
    public int Damage;
    public ParticleSystem PS;
    public GameObject Target;

    private void Update()
    {
        if (PS.isStopped)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (Target != null)
        {
            Target.GetComponent<Health>().MinusHP(Damage);
        }
    }
}
