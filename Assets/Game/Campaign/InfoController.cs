using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtInfo;

    public static InfoController current;

    private void Awake()
    {
        current = this;
    }

    public void ShowInfo(string Message)
    {
        StopAllCoroutines();
        txtInfo.text = Message;
        StartCoroutine(ClearInfo());
    }

    private IEnumerator ClearInfo()
    {
        yield return new WaitForSeconds(4);
        txtInfo.text = "";
    }
}
