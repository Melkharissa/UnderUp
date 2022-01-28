using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharapterInfo : MonoBehaviour
{
    public bool Frezee;
    public bool Burn;
    public bool Acid;
    public int Health;

    public int getHP()
    {
        return Health;
    }
}
