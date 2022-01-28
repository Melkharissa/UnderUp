using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryObjects : MonoBehaviour
{
    public GameObject[] Items;
    public Text gold_Text;

    private void OnEnable()
    {
        gold_Text.text = PickUpItem.Gold.ToString() + " G.";    
    }

    public bool SetItem(GameObject sender, Sprite sprite, string description, int ItemType, int ScrollType = 0, int PotionType = 0)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if(Items[i].GetComponent<InventorySlots>().FreePlace == true)
            {
                Items[i].GetComponent<InventorySlots>().GetItem(sender, sprite, description, ItemType, ScrollType, PotionType);
                return true;
            }
        }
        return false;
    }
}
