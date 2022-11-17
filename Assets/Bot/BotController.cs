using System;
using System.Collections;
using UnityEngine;

public class BotController : MonoBehaviour
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
    private Rigidbody2D rb;

    private Animator animator;

    public bool isDead = false;
    public bool canMove = true;
    private bool invulnerable = false;

    public static event EventHandler onDie;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        if (isDead || invulnerable) return;

        StopAllCoroutines();

        animator.ResetTrigger("punch");
        animator.ResetTrigger("kick");

        currentHealth -= amount;
        healthbar.SetValue(currentHealth);
        animator.SetTrigger("hit");
        if(currentHealth <= 0)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            onDie?.Invoke(this, EventArgs.Empty);   
        }
    }
}
