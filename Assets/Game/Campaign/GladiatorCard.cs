using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class GladiatorCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtVit;
    [SerializeField] private TextMeshProUGUI txtStr;
    [SerializeField] private TextMeshProUGUI txtSpd;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtPrice;
    [SerializeField] private Image preview;
    [SerializeField] private Button button;

    public virtual void Fill(int vit, int str, int spd, Color color, string name, 
        string ButtonText, UnityAction btnSelectAction)
    {
        txtVit.text = vit.ToString();
        txtStr.text = str.ToString();
        txtSpd.text = spd.ToString();
        txtName.text = name;
        preview.color = color;
        txtPrice.text = ButtonText;
        button.onClick.AddListener(btnSelectAction);
    }    
}
