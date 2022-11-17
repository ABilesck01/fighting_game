using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI txtEnd;

    private void OnEnable()
    {
        if (CampaignController.Instance != null)
        {
            CampaignFightManager.onGameStart += GameManager_onGameStart;
        }
        else
        {
            GameManager.onGameStart += GameManager_onGameStart;
        }
        PlayerHealth.onDie += PlayerHealth_onDie;
    }


    private void OnDisable()
    {
        if (CampaignController.Instance != null)
        {
            CampaignFightManager.onGameStart -= GameManager_onGameStart;
        }
        else
        {
            GameManager.onGameStart -= GameManager_onGameStart;
        }
        PlayerHealth.onDie -= PlayerHealth_onDie;
    }

    private void GameManager_onGameStart(object sender, System.EventArgs e)
    {
        startPanel.SetActive(false);
    }
    private void PlayerHealth_onDie(object sender, PlayerHealth.onDieEnventArgs e)
    {
        if (e.player == 1)
            txtEnd.text = "Player 2 wins!";
        else
            txtEnd.text = "Player 1 wins!";
        
        endPanel.SetActive(true);
    }
}
