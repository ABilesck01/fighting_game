using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private HitBox[] hitBoxes;

    private GladiatorData data;
    [SerializeField] private bool getValueFromController;

    private void Start()
    {
        if(CampaignController.Instance != null && getValueFromController)
        {
            data = CampaignController.Instance.getPlayerGladiator();
        }
        else
        {
            data = new GladiatorData()
            {
                Vitality = 10,
                Force = 10,
                Agility = 10,
                Name = "Brutus",
                color = Color.white,
            };
        }

        playerHealth.SetMaxHealth(data.Vitality);
        playerMovement.SetSpeed(data.Agility);
        for (int i = 0; i < hitBoxes.Length; i++)
        {
            hitBoxes[i].SetDamage(data.Force);
        }


    }
}
