using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SinglePlayerHUD : MonoBehaviour
{
    [SerializeField] private GameObject pnlGameOver;
    [SerializeField] private GameObject button;
    [SerializeField] private TextMeshProUGUI txtInfo;

    private void OnEnable()
    {
        PlayerHealth.onDie += PlayerHealth_onDie;
        BotController.onDie += BotController_onDie;
    }

    private void OnDisable()
    {
        PlayerHealth.onDie -= PlayerHealth_onDie;
        BotController.onDie -= BotController_onDie;
    }

    private void BotController_onDie(object sender, System.EventArgs e)
    {
        StartCoroutine(OpenPanel());
        Debug.Log("Player won!");
        txtInfo.text = "Player won!";
        EventSystem.current.SetSelectedGameObject(button);
        CampaignController.Instance.PlayerWonMatch();
    }

    private void PlayerHealth_onDie(object sender, PlayerHealth.onDieEnventArgs e)
    {
        StartCoroutine(OpenPanel());
        Debug.Log("Player lost!");
        txtInfo.text = "Player lost!";
        CampaignController.Instance.PlayerLostMatch();
        EventSystem.current.SetSelectedGameObject(button);

    }
    
    private IEnumerator OpenPanel()
    {
        yield return new WaitForSeconds(1.5f);
        pnlGameOver.SetActive(true);
    }

    public void BackToMenu()
    {
        Loading.LoadScene("StoryMode");
    }
}
