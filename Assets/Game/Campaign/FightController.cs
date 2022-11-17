using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FightController : MonoBehaviour
{
    [SerializeField] private GameObject mainFirstSelected;
    [Space]
    [SerializeField] private GameObject myGladiator;
    [SerializeField] private GameObject Enemies;
    [SerializeField] private GladiadorView viewPrefab;
    [SerializeField] private Transform viewContainer;
    [Space]
    [SerializeField] private List<GladiatorCard> Cards = new List<GladiatorCard>();

    private void OnEnable()
    {
        FillEnemies();
    }

    private void FillEnemies()
    {
        GladiatorData easy = CampaignController.Instance.getGladiator(Dificulty.easy);
        Cards[0].Fill(easy.Vitality, easy.Force, easy.Agility, easy.color, easy.Name,
                $"Fight(20)", () =>
                {
                    CampaignController.Instance.SetEnemyToFight(easy, Dificulty.easy);
                    OnChoseEnemy();
                });

        GladiatorData medium = CampaignController.Instance.getGladiator(Dificulty.medium);
        Cards[1].Fill(medium.Vitality, medium.Force, medium.Agility, medium.color, 
            medium.Name, $"Fight(40)", () =>
                {
                    CampaignController.Instance.SetEnemyToFight(medium, Dificulty.medium);
                    OnChoseEnemy();
                });

        GladiatorData Hard = CampaignController.Instance.getGladiator(Dificulty.hard);
        Cards[2].Fill(Hard.Vitality, Hard.Force, Hard.Agility, Hard.color,
            Hard.Name, $"Fight(60)", () =>
            {
                CampaignController.Instance.SetEnemyToFight(Hard, Dificulty.hard);
                OnChoseEnemy();
            });
    }

    private void OnChoseEnemy()
    {
        myGladiator.SetActive(true);
        Enemies.SetActive(false);
        FillGladiators();
    }

    private void FillGladiators()
    {
        foreach (Transform item in viewContainer)
        {
            if(!item.name.Contains("template"))
                Destroy(item.gameObject);
        }

        bool hasSelectedButton = false;

        foreach (GladiatorData item in CampaignController.Instance.Gladiators)
        {
            GladiadorView view = Instantiate(viewPrefab, viewContainer);
            view.Fill(item, () =>
            {
                CampaignController.Instance.SetGladiatorToFIght(item);
                Loading.LoadScene("StoryFight");
                CloseFight();
            });
            view.gameObject.name = $"gladiator_{item.Name}";
            view.gameObject.SetActive(true);
            if(!hasSelectedButton)
            {
                EventSystem.current.SetSelectedGameObject(view.btnSelect.gameObject);
                hasSelectedButton = true;
            }
        }
    }

    public void CloseFight()
    {
        myGladiator.SetActive(false);
        gameObject.SetActive(false);
        Enemies.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainFirstSelected);
    }

}
