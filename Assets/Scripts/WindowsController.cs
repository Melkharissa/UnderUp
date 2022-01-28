using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    public GameObject inventory;

    public void WindowController(GameObject window)
    {
        bool active = GetComponent<Toggle>().isOn;
        window.SetActive(active);
    }
}
