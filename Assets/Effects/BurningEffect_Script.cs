using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningEffect_Script : MonoBehaviour
{
    public GameObject Target;
    public int Burning_Time = 2;
    public int Cur_Burning_Time = 0;
    public int Burning_Damage = 1;
    public int Fire_Attribute = 0;
    public void GetTarget(GameObject target)
    {
        Target = target;
        Target.GetComponent<Health>().StartBurning(Burning_Time, Burning_Damage, Fire_Attribute, gameObject);
    }

    private void Update()
    {
        if (Target != null)
            transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y - 0.1f, -3f);
    }
}
