using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [Header("Item Type: " +
        "\n 0 - Zero " +
        "\n 1 - Scroll" +
        "\n 2 - Potion" +
        "\n 3 - Gold" +
        "\n 4 - Weapon")]
    public int ItemType = 0;
    [Space]
    #region
    [Header("Scroll Type: \n 0 - Zero " +
        "\n 1 - Lightning Bolt" +
        "\n 2 - Meteor" +
        "\n 3 - Posion Spears" +
        "\n 4 - Rainbow Projectile" +
        "\n 5 - Bloodlust" +
        "\n 6 - Freeze Projectile" +
        "\n 7 - Fire Projectile" +
        "\n 101 - Random Skill")]
    public int ScrollType = 0;
    #endregion
    [Space]
    [Header("Potion Type: " +
        "\n 0 - Zero" +
        "\n 1 - Health Potion")]
    public int PotionType = 0;
    [Space]
    static public int Gold;
    public int Min_Gold;
    public int Max_Gold;
    [Space]
    public Sprite sprite;
    public GameObject invObj;
    [Multiline]
    public string Description;

    private void Start()
    {
        invObj = GameObject.Find("Canvas").GetComponent<WindowsController>().inventory;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (ScrollType == 101)
                ScrollType = Random.Range(1, 7);

            if (ItemType != 3)
            {
                bool PickUp = invObj.GetComponent<InventoryObjects>().SetItem(gameObject, sprite, Description, ItemType, ScrollType, PotionType);
                if(PickUp)
                {
                    GetComponent<SpriteRenderer>().sprite = null;
                    transform.SetParent(collision.gameObject.transform, true);
                }
            }
            else 
            {
                Gold += Random.Range(Min_Gold, Max_Gold);
                gameObject.SetActive(false); 
            }
        }
    }
}
