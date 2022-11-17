using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    [SerializeField] private GameObject myGladiator;
    [SerializeField] private GladiadorView viewPrefab;
    [SerializeField] private Transform viewContainer;
    [Space]
    [SerializeField] private List<GladiatorCard> Cards = new List<GladiatorCard>();

    private void OnEnable()
    {
        FillGladiators();
        FillEnemies();
    }

    private void FillEnemies()
    {
        GladiatorData easy = CampaignController.Instance.getGladiator(Dificulty.easy);
        Cards[0].Fill(easy.Vitality, easy.Force, easy.Agility, easy.color, easy.Name,
                $"Fight(20)", () =>
                {
                    CampaignController.Instance.SetEnemyToFight(easy, Dificulty.easy);
                    myGladiator.SetActive(true);
                });

        GladiatorData medium = CampaignController.Instance.getGladiator(Dificulty.medium);
        Cards[1].Fill(medium.Vitality, medium.Force, medium.Agility, medium.color, 
            medium.Name, $"Fight(40)", () =>
                {
                    CampaignController.Instance.SetEnemyToFight(medium, Dificulty.medium);
                    myGladiator.SetActive(true);
                });

        GladiatorData Hard = CampaignController.Instance.getGladiator(Dificulty.hard);
        Cards[2].Fill(Hard.Vitality, Hard.Force, Hard.Agility, Hard.color,
            Hard.Name, $"Fight(60)", () =>
            {
                CampaignController.Instance.SetEnemyToFight(Hard, Dificulty.hard);
                myGladiator.SetActive(true);
            });
    }

    private void FillGladiators()
    {
        foreach (Transform item in viewContainer)
        {
            if(!item.name.Contains("template"))
                Destroy(item.gameObject);
        }

        foreach (GladiatorData item in CampaignController.Instance.Gladiators)
        {
            GladiadorView view = Instantiate(viewPrefab, viewContainer);
            view.Fill(item, () =>
            {
                CampaignController.Instance.SetGladiatorToFIght(item);
                Loading.LoadScene("StoryFight");
            });
            view.gameObject.name = $"gladiator_{item.Name}";
            view.gameObject.SetActive(true);
        }
    }

    public void CloseFight()
    {
        gameObject.SetActive(false);
    }

}
