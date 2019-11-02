using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject button;

    [SerializeField]
    private Transform panel;

    GameObject btn;

    public Text btnText;

    void Awake()
    {
        for (int i = 0; i < 210; i++)
        {
            btn = Instantiate(button);
            btn.name = "" + i;
            btn.transform.SetParent(panel, false);
            btnText = btn.GetComponentInChildren<Text>();
            
        }
    }

}
