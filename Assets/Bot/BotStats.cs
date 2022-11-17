using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;
    public float Speed;
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private float StatsMultiplier;
    [SerializeField] private HitBox[] hitBoxes;
    [SerializeField] private SpriteRenderer gfx;

    private GladiatorData data;
    [SerializeField] private bool getValueFromController;

    private Animator animator;

    public bool isDead = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        GetData();
        UpdateStats();
        healthbar.Initialize(currentHealth);
    }

    private void UpdateStats()
    {
        gfx.color = data.color;
        Speed += data.Agility * StatsMultiplier;
        currentHealth += data.Vitality * StatsMultiplier;

        for (int i = 0; i < hitBoxes.Length; i++)
        {
            hitBoxes[i].SetDamage(data.Force);
        }
    }

    private void GetData()
    {
        if (CampaignController.Instance != null && getValueFromController)
        {
            data = CampaignController.Instance.getEnemyGladiator();
        }
        else
        {
            data = new GladiatorData()
            {
                Vitality = 10,
                Force = 10,
                Agility = 10,
                Name = "Spartacus",
                color = Color.red,
            };
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        healthbar.SetValue(currentHealth);
        animator.SetTrigger("hit");
        if(currentHealth <= 0)
        {
            isDead = true;
            animator.SetBool("isDead", true);
        }

    }
}
