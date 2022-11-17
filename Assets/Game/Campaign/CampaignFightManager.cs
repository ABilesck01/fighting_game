using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignFightManager : MonoBehaviour
{
    public static event EventHandler onGameStart;

    private void Start()
    {
        StartCoroutine(countDown());
    }

    private IEnumerator countDown()
    {
        WaitForSeconds one = new WaitForSeconds(1);
        for (int i = 3; i > 0; i--)
        {
            Debug.Log(i);
            yield return one;
        }
        Debug.Log("Fight");
        onGameStart?.Invoke(this, EventArgs.Empty);
    }
}
