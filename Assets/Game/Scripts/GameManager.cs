using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform PlayerOneLocation;
    [SerializeField] private Healthbar playerOneHealth;
    public Color playerOneColor;
    [Space]
    [SerializeField] private Transform PlayerTwoLocation;
    [SerializeField] private Healthbar playerTwoHealth;
    public Color playerTwoColor;
    [Space]
    [SerializeField] private float matchTime = 90;
    [SerializeField] private Color[] Colors;
    private int PlayerCount = 0;
    private int PlayerReady = 0;

    public static event EventHandler onGameStart;

    public void OnPlayerJoin(PlayerInput player)
    {
        PlayerCount++;
        player.GetComponent<PlayerData>().PlayerCode = PlayerCount;
        if (PlayerCount == 1)
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            player.transform.position = PlayerOneLocation.position;
            player.GetComponent<PlayerCustomization>().SetColor(playerOneColor);
            player.GetComponent<PlayerHealth>().AsignHealthBar(playerOneHealth);
        }
        else
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            player.transform.position = PlayerTwoLocation.position;
            player.GetComponent<PlayerCustomization>().SetColor(playerTwoColor);
            player.GetComponent<PlayerHealth>().AsignHealthBar(playerTwoHealth);
        }
    }

    private void Awake()
    {
        PlayerData.onPlayerReady += PlayerData_onPlayerReady;
    }

    private void PlayerData_onPlayerReady(object sender, EventArgs e)
    {
        PlayerReady++;
        if (PlayerReady >= 2) GameStart();
    }

    public int ColorsCount() => Colors.Length;

    public Color getColor(int index) => Colors[index];

    private void GameStart()
    {
        onGameStart?.Invoke(this, EventArgs.Empty);
    }
}
