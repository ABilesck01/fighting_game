using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    private float currentHealth;
    [SerializeField] private Healthbar healthbar;

    private PlayerCombat playerCombat;

    public event EventHandler onTakeDamage;
    public class onDieEnventArgs : EventArgs
    {
        public int player;
    }
    public static event EventHandler<onDieEnventArgs> onDie;
    private PlayerData playerData;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
        playerCombat = GetComponent<PlayerCombat>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        if(healthbar != null)
        {
            healthbar.Initialize(maxHealth);
        }
    }

    public void SetMaxHealth(int value)
    {
        maxHealth += value;
        currentHealth = maxHealth;
        healthbar.Initialize(maxHealth);
    }

    public void AsignHealthBar(Healthbar healthbar)
    {
        this.healthbar = healthbar;
        this.healthbar.Initialize(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        StopAllCoroutines();

        currentHealth -= amount;
        healthbar?.SetValue(currentHealth);
        onTakeDamage?.Invoke(this, EventArgs.Empty);
        if (currentHealth <= 0)
        {
            onDie?.Invoke(this, new onDieEnventArgs
            {
                player = playerData.PlayerCode
            });
        }
    }

}
