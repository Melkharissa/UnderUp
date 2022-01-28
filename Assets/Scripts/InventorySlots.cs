using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public GameObject Charapter;
    public GameObject[] Skills;
    public GameObject[] RainbowProjectile;
    public GameObject[] FreezeProjectile;
    public GameObject[] FireProjectile;
    public Sprite DefaultSprite;
    public bool FreePlace = true;
    public float doubleClickTime = 0.2f;
    float firstClick = 0f;
    float secondClick = 0f;
    public int ScrollType = 0;
    public int PotionType = 0;
    Sprite DescriptionSprite;
    string Description;
    public Image DescriptionImage;
    public Text DescriptionText;
    public GameObject Sender;

    public void GetItem(GameObject sender, Sprite sprite, string description, int ItemType, int scrollType = 0, int potionType = 0)
    {
        Sender = sender;
        DescriptionSprite = sprite;
        Description = description;
        ScrollType = scrollType;
        PotionType = potionType;
        GetComponent<Image>().sprite = sprite;
        FreePlace = false;
        GetComponent<Button>().onClick.SetPersistentListenerState(1, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
        switch (ItemType)
        {
            case 1:
                    GetComponent<Button>().onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
                break;
            case 2:
                GetComponent<Button>().onClick.SetPersistentListenerState(2, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
                break;
            case 4:
                GetComponent<Button>().onClick.SetPersistentListenerState(1, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
                break;
        }
    }

    public void Scrolls()
    {
        if (firstClick == 0)
        {
            firstClick = Time.realtimeSinceStartup;
            Invoke("CancelDoubleClick", doubleClickTime);
        }
        else
        {
            secondClick = Time.realtimeSinceStartup;

            float clickTime = secondClick - firstClick;
            print(clickTime);
            if (clickTime < doubleClickTime)
            {
                LearnScroll();
                ClearDescription();
                CancelDoubleClick();
            }
        }
    }
    public void Potion()
    {
        if (firstClick == 0)
        {
            firstClick = Time.realtimeSinceStartup;
            Invoke("CancelDoubleClick", doubleClickTime);
        }
        else
        {
            secondClick = Time.realtimeSinceStartup;

            float clickTime = secondClick - firstClick;
            if (clickTime < doubleClickTime)
            {
                UsePotion();
                ClearDescription();
                CancelDoubleClick();
            }
        }
    }

    void UsePotion()
    {
        switch(PotionType)
        {
            case 1:
                Charapter.GetComponent<Health>().MinusHP(-25);
                break;
        }
        GetComponent<Button>().onClick.SetPersistentListenerState(2, UnityEngine.Events.UnityEventCallState.Off);
        GetComponent<Button>().onClick.SetPersistentListenerState(1, UnityEngine.Events.UnityEventCallState.Off);
        GetComponent<Image>().sprite = DefaultSprite;
        FreePlace = true;
    }

    void LearnScroll()
    {
        switch(ScrollType)
        {
            case 1:
                print("Lightning Bolt");
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().Lvl++;
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().ChangeValue();
                Charapter.GetComponent<Lightning>().LvlUpSkill();
                break;
            case 2:
                print("Meteor");
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().Lvl++;
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().ChangeValue();
                Charapter.GetComponent<Meteor>().LvlUpSkill();
                break;
            case 3:
                print("Poison Spears");
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().Lvl++;
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().ChangeValue();
                Charapter.GetComponent<PoisonSpears>().LvlUpSkill();
                break;
            case 4:
                print("Rainbow Projectile");
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().Lvl++;
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().ChangeValue();
                for(int i = 0; i < RainbowProjectile.Length; i++)
                {
                    RainbowProjectile[i].GetComponent<ProjectileMove>().LvlUpSkill();
                }
                break;
            case 5:
                print("Bloodlust");
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().Lvl++;
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().ChangeValue();
                break;
            case 6:
                print("Freeze Projectile");
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().Lvl++;
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().ChangeValue();
                for (int i = 0; i < FreezeProjectile.Length; i++)
                {
                    FreezeProjectile[i].GetComponent<ProjectileMove>().LvlUpSkill();
                }
                break;
            case 7:
                print("Fire Projectile");
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().Lvl++;
                Skills[ScrollType - 1].GetComponent<UILeftSkills>().ChangeValue();
                for (int i = 0; i < FireProjectile.Length; i++)
                {
                    FireProjectile[i].GetComponent<ProjectileMove>().LvlUpSkill();
                }
                break;
        }
        GetComponent<Button>().onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        GetComponent<Button>().onClick.SetPersistentListenerState(1, UnityEngine.Events.UnityEventCallState.Off);
        GetComponent<Image>().sprite = DefaultSprite;
        FreePlace = true;
    }

    void CancelDoubleClick()
    {
        firstClick = 0;
        secondClick = 0;
    }

    public void SetDescription()
    {
        DescriptionImage.sprite = DescriptionSprite;
        DescriptionText.text = Description;
    }

    public void ClearDescription()
    {
        DescriptionImage.sprite = DefaultSprite;
        DescriptionText.text = "";
    }

}
