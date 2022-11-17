using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankruptController : MonoBehaviour
{
    private void Start()
    {
        Destroy(CampaignController.Instance.gameObject);
    }

    public void OnBackToMenu()
    {
        Loading.LoadScene("MainMenu");
    }
}
