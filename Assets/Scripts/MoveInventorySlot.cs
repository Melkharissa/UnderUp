using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int index;
    public List<RectTransform> Items = new List<RectTransform>();
    public RectTransform myTransform;
    public Transform MainParent;
    public Transform defaultParent;
    public RectTransform DeleteBucket;
    public GameObject DeleteWindow;

    private void Start()
    {
        Items.Remove(myTransform);
        myTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //transform.SetParent(MainParent, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += (Vector3)eventData.delta;


        float d_dist = Vector3.Distance(myTransform.position, DeleteBucket.position);
        if (d_dist < 125f)
        {
            DeleteBucket.gameObject.GetComponent<Image>().color = Color.red;
        }
        else
            DeleteBucket.gameObject.GetComponent<Image>().color = new Color32(142, 142, 142, 54);

        for (int i = 0; i < Items.Count; i++)
        {
            float dist = Vector3.Distance(myTransform.position, Items[i].position);
            if (dist < 125f)
                Items[i].gameObject.GetComponent<Image>().color = Color.gray;
            else
                Items[i].gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float d_dist = Vector3.Distance(myTransform.position, DeleteBucket.position);

        if (d_dist < 125f)
        {
            DeleteWindow.SetActive(true);
            DeleteWindow.GetComponent<DeleteInventoryItem>().gobject = gameObject;
            DeleteBucket.gameObject.GetComponent<Image>().color = new Color32(142, 142, 142, 54);
        }

        for (int i = 0; i < Items.Count; i++)
        {
            float dist = Vector3.Distance(myTransform.position, Items[i].position);
            if (dist < 125f)
            {
                int ind = Items[i].gameObject.GetComponent<MoveInventorySlot>().index;
                //myTransform.SetSiblingIndex(ind);
                Items[i].SetSiblingIndex(index);
                int _index = index;
                index = ind;
                Items[i].gameObject.GetComponent<MoveInventorySlot>().index = _index;
                Items[i].gameObject.GetComponent<Image>().color = Color.white;
            }
        }

        myTransform.SetSiblingIndex(Items.Count + 1);
        myTransform.SetSiblingIndex(index);
    }
}
