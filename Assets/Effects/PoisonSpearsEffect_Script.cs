using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSpearsEffect_Script : MonoBehaviour
{
    public GameObject Target;
    public int Poison_Time = 2;
    public int Cur_Poison_Time = 0;
    public int Poison_Damage = 1;

    public void GetTarget(GameObject target)
    {
        Target = target;
        StartCoroutine(Poisiong());
    }

    private void Update()
    {
        if (Target != null)
            transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + 0.1f, -3f);
    }

    IEnumerator Poisiong()
    {
        while (true)
        {
            if (Target != null)
            {
                if (Cur_Poison_Time <= Poison_Time)
                {
                    Cur_Poison_Time++;
                    Target.GetComponent<Health>().MinusHP(Poison_Damage);
                }
                else
                {
                    StopCoroutine(Poisiong());
                    gameObject.SetActive(false);
                }
            }
            else
            {
                StopCoroutine(Poisiong());
                gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
