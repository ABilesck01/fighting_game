using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float SpeedMultiplier;
    [SerializeField] private InputActionReference moveAction;

    private float horizontal = 0;

    private Rigidbody2D rb;
    private bool canMove = false;
    private bool gameStarted = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    private void OnDisable()
    {
        GameManager.onGameStart -= GameManager_onGameStart;
        PlayerHealth.onDie -= PlayerHealth_onDie;
    }

    private void GameManager_onGameStart(object sender, System.EventArgs e)
    {
        gameStarted = true;
    }

    private void PlayerHealth_onDie(object sender, PlayerHealth.onDieEnventArgs e)
    {
        gameStarted = false;
    }

    public void Action_performed(InputAction.CallbackContext obj)
    {
        if (canMove && gameStarted)
            horizontal = obj.ReadValue<Vector2>().x;
        else
            horizontal = 0;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }

    public void SetSpeed(int value)
    {
        Speed += value * SpeedMultiplier;
    }

    public void EnableMove() => canMove = true;
    public void DisableMove() => canMove = false;

}
