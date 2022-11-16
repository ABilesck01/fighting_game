using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CampaignMenu : MonoBehaviour
{
    [SerializeField] private Button btnFight;
    [SerializeField] private Button btnStore;
    [SerializeField] private Button btnGladiators;
    [SerializeField] private Button btnQuit;

    private void Awake()
    {
        btnQuit.onClick.AddListener(OnQuit);
    }

    private void OnQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
