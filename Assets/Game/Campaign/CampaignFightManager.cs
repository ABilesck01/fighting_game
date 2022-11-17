using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignFightManager : MonoBehaviour
{
    public static event EventHandler onGameStart;

    public bool instantPlay;

    private void Start()
    {
        StartCoroutine(countDown());
    }

    private IEnumerator countDown()
    {
        WaitForSeconds one = new WaitForSeconds(1);
        WaitForSeconds instant = new WaitForSeconds(.1f);
        if(instantPlay)
        {
            yield return instantPlay;
            onGameStart?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            for (int i = 3; i > 0; i--)
            {
                Debug.Log(i);
                yield return one;
            }
            Debug.Log("Fight");
            onGameStart?.Invoke(this, EventArgs.Empty);
        }
    }
}
