using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int playerCode;

    public static event EventHandler onPlayerReady;

    public int PlayerCode { get => playerCode; set => playerCode = value; }

    private void Start()
    {
        onPlayerReady?.Invoke(this, EventArgs.Empty);
    }

}
