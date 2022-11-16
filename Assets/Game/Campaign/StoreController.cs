using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    [SerializeField] private int BaseValue;
    [SerializeField] private int incrementValue;
    private int totalValue;

    private GladiatorData selectedGladiator;

    private void Awake()
    {
        CheckTotalValue();
    }

    private void CheckTotalValue()
    {
        totalValue = BaseValue * incrementValue *
                    CampaignController.Instance.GetGladiatorsCount();
    }

    public void BuyGladiator()
    {
        if(CampaignController.Instance.SpendMoney(totalValue))
        {
            CampaignController.Instance.AddGladiator(selectedGladiator);
            CheckTotalValue();
        }
    }
}
