using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignController : MonoBehaviour
{
    [SerializeField] private int Money = 50;

    [SerializeField] private List<GladiatorData> Gladiators = new List<GladiatorData>();

    public static CampaignController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetGladiatorsCount() => Gladiators.Count;

    public bool SpendMoney(int amount)
    {
        if(amount > Money) return false;

        Money -= amount;
        return true;
    }

    public void AddGladiator(GladiatorData gladiator)
    {
        Gladiators.Add(gladiator);
    }
}
