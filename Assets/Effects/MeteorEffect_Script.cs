using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorEffect_Script : MonoBehaviour
{
    public int Damage;
    public ParticleSystem PS;
    public GameObject Target;
    public GameObject Explosion;
    public GameObject _Burning;

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
            Explosion.SetActive(true);
            Explosion.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, -3f);
            Explosion.GetComponent<ParticleSystem>().Play();
            if (Target.GetComponent<CharapterInfo>().Burn == false)
            {
                GameObject burning = Instantiate(_Burning, _Burning.transform.position, Quaternion.identity);
                burning.GetComponent<BurningEffect_Script>().GetTarget(Target);
            }
        }
    }
}
