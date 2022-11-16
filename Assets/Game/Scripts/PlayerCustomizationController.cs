using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCustomizationController : MonoBehaviour
{
    [SerializeField]private GameManager gameManager;
    [SerializeField] private int player;
    [SerializeField] private InputActionReference selectButton;
    private int ColorSelected = 0;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        selectButton.action.started += OnSelect;
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            ColorSelected = ColorSelected + 1 % gameManager.ColorsCount();
            if(player == 1)
                gameManager.playerOneColor = gameManager.getColor(ColorSelected);
            else
                gameManager.playerTwoColor = gameManager.getColor(ColorSelected);

            spriteRenderer.color = gameManager.getColor(ColorSelected);
        }
    }
}
