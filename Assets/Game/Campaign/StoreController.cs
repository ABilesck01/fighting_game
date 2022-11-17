using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreController : MonoBehaviour
{
    [SerializeField] private GameObject mainFirstSelected;
    [Space]
    [SerializeField] private GameObject storePanel;
    [SerializeField] private int BaseValue;
    [SerializeField] private int incrementValue;
    [SerializeField] private List<GladiatorCard> Cards = new List<GladiatorCard>();
    private int totalValue;

    private GladiatorData selectedGladiator;

    public static StoreController Instance;

    private void Awake()
    {
        Instance = this;

        CheckTotalValue();
    }

    public void CheckTotalValue()
    {
        totalValue = BaseValue + incrementValue *
                    CampaignController.Instance.GetGladiatorsCount();
    }

    public void OnOpenStore()
    {
        for (int i = 0; i < 3; i++)
        {
            GladiatorData g = CampaignController.Instance.getGladiator(Dificulty.easy);
            Cards[i].Fill(g.Vitality, g.Force, g.Agility, g.color, g.Name,
                $"Buy({totalValue}",() =>
                {
                    BuyGladiator(g);
                }
                );
        }
    }

    public void BuyGladiator(GladiatorData data)
    {
        if (CampaignController.Instance.SpendMoney(totalValue))
        {
            CampaignController.Instance.AddGladiator(data);
            CheckTotalValue();
        }
        else
        {
            InfoController.current.ShowInfo("Not enough money!");
        }

        CloseStore();
    }

    public void CloseStore()
    {
        storePanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(mainFirstSelected);
    }
}
