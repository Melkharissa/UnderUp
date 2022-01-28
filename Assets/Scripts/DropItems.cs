using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public int[] MinRandomChance;
    public int[] MaxRandomChance;
    public GameObject[] Items;

    public void Drop()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        for (int i = 0; i < Items.Length; i++)
        {
            float rx = Random.Range(x - 0.4f, x + 0.4f);
            float ry = Random.Range(y - 0.4f, y + 0.4f);
            int r = Random.Range(MinRandomChance[i], MaxRandomChance[i]);
            print(r);
            if (r == MinRandomChance[i])
            {
                GameObject item = Instantiate(Items[i], new Vector3(rx, ry, -3f), Quaternion.identity);
            }
            else continue;
        }
    }
}
