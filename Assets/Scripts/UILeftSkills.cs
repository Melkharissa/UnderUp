using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UILeftSkills : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Sprite sprite;
    public int SerialNumber = 0;
    public Text txt;
    public int Lvl;
    public Text Description;
    [Multiline]
    public string description;
    public RectTransform MainParent;
    public RectTransform ParentPanel;
    public RectTransform[] RightPanel;
    public RectTransform Panel;

    private void Start()
    {

    }

    private void Enable()
    {
        ChangeValue();
    }

    public void ChangeValue()
    {
        txt.text = Lvl.ToString() + " Lvl";
    }

    public void Touch()
    {
        Description.text = description;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += (Vector3)eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(MainParent, false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentPanel, false);

        for (int i = 0; i < RightPanel.Length; i++)
        {
            float dist = Vector3.Distance(Panel.position, RightPanel[i].position);
            if (dist < 100f)
            {
                RightPanel[i].GetComponent<UIRightSkills>().GetSkill(sprite, SerialNumber, txt.text);
                gameObject.SetActive(false);
            }
        }
    }

    public void setActive()
    {
        gameObject.SetActive(true);
        print("Active " + gameObject.name);
        transform.SetParent(ParentPanel, false);
    }
}
