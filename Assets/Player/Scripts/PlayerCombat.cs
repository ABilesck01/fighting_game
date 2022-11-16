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

    private Animator animator;
    private bool gameStarted = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void GameManager_onGameStart(object sender, System.EventArgs e)
    {
        gameStarted = true;
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
        gameStarted = false;
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (!gameStarted) return;

        if(context.phase == InputActionPhase.Started)
        {
            animator.SetTrigger(punchTrigger);
        }
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        if (!gameStarted) return;

        if (context.phase == InputActionPhase.Started)
        {
            animator.SetTrigger(kickTrigger);
        }
    }

    private void PlayerCombat_onTakeDamage(object sender, System.EventArgs e)
    {
        if (!gameStarted) return;

        animator.SetTrigger("hit");
    }
}
