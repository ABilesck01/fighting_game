using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    public void EnableMove() => playerMovement?.EnableMove();
    public void DisableMove() => playerMovement?.DisableMove();
}
