using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteInventoryItem : MonoBehaviour
{
    public Sprite defaultSprite;
    public GameObject gobject;
    public void Yes()
    {
        gobject.GetComponent<Image>().sprite = defaultSprite;
        gobject.GetComponent<Button>().onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        gobject.GetComponent<Button>().onClick.SetPersistentListenerState(1, UnityEngine.Events.UnityEventCallState.Off);
        gobject.GetComponent<Button>().onClick.SetPersistentListenerState(2, UnityEngine.Events.UnityEventCallState.Off);
        gobject.GetComponent<InventorySlots>().FreePlace = true;
        gobject.GetComponent<InventorySlots>().ClearDescription();
        GameObject go = gobject.GetComponent<InventorySlots>().Sender;
        if(go.GetComponent<WeaponItemScript>() == true)
            go.GetComponent<WeaponItemScript>().DestroyItem();
        gameObject.SetActive(false);
    }

    public void No()
    {
        gobject.GetComponent<InventorySlots>().FreePlace = false;
        gameObject.SetActive(false);
    }
}
