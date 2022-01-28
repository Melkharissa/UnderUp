using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodLust : MonoBehaviour
{
    public GameObject Target;
    public GameObject BloodText;
    static public int Blood_Counter = 0;
    static public int Max_Blood_Counter = 5;

    private void Start ()
    {
        Max_Blood_Counter = 5;
        NullBloodCounter();
    }

    public void LvlUpSkill()
    {
        Max_Blood_Counter++;
    }

    public void PlusBloodCounter(GameObject target)
    {
        Target = target;
        if (Blood_Counter < Max_Blood_Counter)
        {
            Blood_Counter++;
            BloodText.SetActive(true);
            BloodText.GetComponent<TextMesh>().text = Blood_Counter.ToString();
        }
    }

    public void NullBloodCounter()
    {
        Blood_Counter = 0;
        BloodText.GetComponent<TextMesh>().text = Blood_Counter.ToString();
        BloodText.SetActive(false);
    }

    private void Update()
    {
        if (Target == null || Target.activeInHierarchy == false)
        {
            NullBloodCounter();
        }
        BloodText.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, -2f);
    }

}
