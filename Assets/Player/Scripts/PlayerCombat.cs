using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [Header("punch")]
    [SerializeField] private string punchTrigger;
    [SerializeField] private InputActionReference punchAction;
    [Header("Kick")]
    [SerializeField] private string kickTrigger;
    [SerializeField] private InputActionReference kickAction;
    [Space]
    [SerializeField] private float attackTime;

    private float nextAttackTime;
    private Animator animator;
    public bool gameStarted = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void GameManager_onGameStart(object sender, System.EventArgs e)
    {
        gameStarted = true;
    }

    private void Start()
    {
        if (CampaignController.Instance != null)
        {
            gameStarted = true;
        }
    }

    private void OnEnable()
    {
        GameManager.onGameStart += GameManager_onGameStart;
        PlayerHealth.onDie += PlayerHealth_onDie;
        GetComponent<PlayerHealth>().onTakeDamage += PlayerCombat_onTakeDamage;
    }


    private void OnDisable()
    {
        GameManager.onGameStart -= GameManager_onGameStart;
        PlayerHealth.onDie -= PlayerHealth_onDie;
        GetComponent<PlayerHealth>().onTakeDamage -= PlayerCombat_onTakeDamage;
    }
    private void PlayerHealth_onDie(object sender, PlayerHealth.onDieEnventArgs e)
    {
        animator.SetBool("isDead", true);
        gameStarted = false;
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (!gameStarted) return;

        if(context.phase == InputActionPhase.Started && nextAttackTime <= 0)
        {
            animator.SetTrigger(punchTrigger);
            nextAttackTime = attackTime;
        }
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        if (!gameStarted) return;

        if (context.phase == InputActionPhase.Started && nextAttackTime <= 0)
        {
            animator.SetTrigger(kickTrigger);
            nextAttackTime = attackTime;
        }
    }

    private void PlayerCombat_onTakeDamage(object sender, System.EventArgs e)
    {
        if (!gameStarted) return;

        animator.SetTrigger("hit");
    }

    private void Update()
    {
        if(nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }
    }
}
