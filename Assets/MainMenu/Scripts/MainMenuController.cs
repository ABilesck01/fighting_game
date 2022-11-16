using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string campaignScene;
    [SerializeField] private string versusScene;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject settingsFirstSelected;
    [Space]
    [SerializeField] private Button btnCampaign;
    [SerializeField] private Button btnVersus;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnQuit;

    private void Awake()
    {
        btnCampaign.onClick.AddListener(OnCampaignClick);
        btnVersus.onClick.AddListener(OnVersusClick);
        btnSettings.onClick.AddListener(OnSettingsClick);
        btnQuit.onClick.AddListener(OnQuitClick);
    }

    private void OnQuitClick()
    {
        Application.Quit();
    }

    private void OnSettingsClick()
    {
        EventSystem.current.SetSelectedGameObject(settingsFirstSelected);
        settingsPanel.SetActive(true);
    }

    private void OnVersusClick()
    {
        //SceneManager.LoadScene(versusScene);
        Loading.LoadScene(versusScene);
    }

    private void OnCampaignClick()
    {
        Loading.LoadScene(campaignScene);
        //SceneManager.LoadScene(campaignScene);
    }
}
