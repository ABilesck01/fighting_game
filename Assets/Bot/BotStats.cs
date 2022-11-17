using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStats : MonoBehaviour
{
    public float Speed;
    [SerializeField] private float StatsMultiplier;
    [SerializeField] private SpriteRenderer gfx;

    private GladiatorData data;
    [SerializeField] private bool getValueFromController;

    private void Start()
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

        gfx.color = data.color;

        Speed += data.Agility * StatsMultiplier;

    }
}
