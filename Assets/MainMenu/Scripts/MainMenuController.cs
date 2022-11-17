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
    [Space]
    [SerializeField] private Button btnCampaign;
    [SerializeField] private Button btnVersus;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnQuit;

    private void Awake()
    {
        btnCampaign.onClick.AddListener(OnCampaignClick);
        btnVersus.onClick.AddListener(OnVersusClick);
        btnQuit.onClick.AddListener(OnQuitClick);
    }

    private void Start()
    {
        //if(CampaignController.Instance != null)
        //{
        //    Destroy(CampaignController.Instance.gameObject);
        //    CampaignController.Instance = null;
        //}
    }

    private void OnQuitClick()
    {
        Application.Quit();
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
