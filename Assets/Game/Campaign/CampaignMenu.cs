using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CampaignMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] txtMoney;
    [Space]
    [SerializeField] private GameObject FightMenu;
    [SerializeField] private GameObject FightFirstSelected;
    [Space]
    [SerializeField] private GameObject StoreMenu;
    [SerializeField] private GameObject StoreFirstSelected;
    [SerializeField] private StoreController storeController;
    [Space]
    [SerializeField] private Button btnFight;
    [SerializeField] private Button btnStore;
    [SerializeField] private Button btnGladiators;
    [SerializeField] private Button btnQuit;

    private void Awake()
    {
        btnFight.onClick.AddListener(OnFight);
        btnStore.onClick.AddListener(OnStore);
        btnQuit.onClick.AddListener(OnQuit);
    }


    private void OnEnable()
    {
        CampaignController.OnSpendMoney += CampaignController_OnSpendMoney;
    }

    private void OnDisable()
    {
        CampaignController.OnSpendMoney -= CampaignController_OnSpendMoney;
    }

    private void CampaignController_OnSpendMoney(object sender, 
        CampaignController.onSpendMoney e)
    {
        for (int i = 0; i < txtMoney.Length; i++)
        {
            txtMoney[i].text = e.newMoney.ToString();
        }
    }
    private void OnFight()
    {
        if(CampaignController.Instance.GetGladiatorsCount() > 0)
        {
            FightMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(FightFirstSelected);
        }
        else
        {
            InfoController.current.ShowInfo("You dont have any gladiators! Go to store to buy one.");
        }
    }

    private void OnStore()
    {
        storeController.OnOpenStore();
        StoreMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(StoreFirstSelected);
    }

    private void OnQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
