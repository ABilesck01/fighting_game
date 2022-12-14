using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CampaignController : MonoBehaviour
{

    [SerializeField] private int Money = 50;

    [SerializeField] private List<GladiatorData> gladiators = new List<GladiatorData>();

    [Header("Gladiator parameters")]
    [SerializeField] private List<string> Names = new List<string>();
    [SerializeField] private List<Color> Colors = new List<Color>();

    public static CampaignController Instance;

    private GladiatorData gladiatorToFight;
    private GladiatorData enemyGladiatorToFight;
    private Dificulty currentDificulty;

    public bool bankrupt = false;

    public List<GladiatorData> Gladiators { get => gladiators; set => gladiators = value; }

    public class onSpendMoney : EventArgs
    {
        public int newMoney;
    }
    public static event EventHandler<onSpendMoney> OnSpendMoney;

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        OnSpendMoney?.Invoke(this, new onSpendMoney
        {
            newMoney = Money
        });
    }

    private void Start()
    {
        OnSpendMoney?.Invoke(this, new onSpendMoney
        {
            newMoney = Money
        });
    }

    public int GetGladiatorsCount() => gladiators.Count;

    public bool SpendMoney(int amount)
    {
        if(amount > Money) return false;

        Money -= amount;

        OnSpendMoney?.Invoke(this, new onSpendMoney
        {
            newMoney = Money
        });

        return true;
    }

    public void AddGladiator(GladiatorData gladiator)
    {
        gladiators.Add(gladiator);
    }

    public void SetGladiatorToFIght(GladiatorData gladiator)
    {
        gladiatorToFight = gladiator;
    }

    public GladiatorData getPlayerGladiator()
    {
        return gladiatorToFight;
    }

    public GladiatorData getEnemyGladiator()
    {
        return enemyGladiatorToFight;
    }

    public void SetEnemyToFight(GladiatorData gladiator, Dificulty dif)
    {
        enemyGladiatorToFight = gladiator;
        currentDificulty = dif;
    }

    public GladiatorData getGladiator(Dificulty dificulty)
    {
        int dif = 0;

        if (dificulty == Dificulty.easy) dif = 5;
        else if (dificulty == Dificulty.medium) dif = 7;
        else dif = 9;

        return getRandomGladiator(dif);
    }

    private GladiatorData getRandomGladiator(int dif)
    {
        GladiatorData data = new GladiatorData();

        for (int i = 0; i < dif; i++)
        {
            float rand = Random.value;
            if(rand <= .33f )
            {
                data.Vitality++;
            }
            else if( rand <= .66f)
            {
                data.Force++;
            }
            else
            {
                data.Agility++;
            }
        }

        data.Name = Names[Random.Range(0, Names.Count)];
        data.color = Colors[Random.Range(0, Colors.Count)];

        return data;
    }



    public void PlayerLostMatch()
    {
        gladiators.Remove(gladiatorToFight);

        if(Money <= 30 && gladiators.Count == 0)
        {
            Debug.Log("Bankrupt");
            bankrupt = true;
        }
    }

    public void PlayerWonMatch()
    {
        switch (currentDificulty)
        {
            case Dificulty.easy:
                Money += 40;
                break;
            case Dificulty.medium:
                Money += 80;
                break;
            case Dificulty.hard:
                Money += 120;
                break;
        }
    }
}

public enum Dificulty
{
    easy = 1,
    medium,
    hard
}
