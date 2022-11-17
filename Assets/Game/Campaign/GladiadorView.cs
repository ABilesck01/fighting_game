using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GladiadorView : MonoBehaviour
{
    [SerializeField] private Image preview;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private Button btnSelect;

    public void Fill(GladiatorData data, UnityAction btnSelectAction)
    {
        preview.color = data.color;
        txtName.name = data.Name;
        btnSelect.onClick.AddListener(btnSelectAction);
    }
}
