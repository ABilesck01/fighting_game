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
    private Rigidbody2D rb;
    private PlayerData playerData;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
        rb = GetComponent<Rigidbody2D>();
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
        StartCoroutine(PauseCombo());
        if (currentHealth <= 0)
        {
            onDie?.Invoke(this, new onDieEnventArgs
            {
                player = playerData.PlayerCode
            });
        }
    }

    private IEnumerator PauseCombo()
    {
        //playerCombat.gameStarted = false;
        playerMovement.gameStarted = false;
        rb.AddForce(-transform.right * 1.3f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.25f);
        //playerCombat.gameStarted = true;
        playerMovement.gameStarted = true;
    }

}
