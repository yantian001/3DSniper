using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int Money;

    private static Player _instance = null;

    public static Player CurrentUser
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Player>();
                if (_instance == null)
                {
                    GameObject p = new GameObject("PlayerHandler");
                    _instance = p.AddComponent<Player>();
                }
            }
            return _instance;
        }
        private set
        {

        }
    }

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Init()
    {
        Money = PlayerPrefs.GetInt("money", 0);
    }

    public void OnEnable()
    {
        LeanTween.addListener((int)Events.MONEYUSED, OnMoneyUsed);
    }

    public void OnDisable()
    {
        LeanTween.removeListener((int)Events.MONEYUSED, OnMoneyUsed);
    }

    void OnMoneyUsed(LTEvent evt)
    {
        if(evt.data!=null)
        {
            UseMoney(ConvertUtil.ToInt32(evt.data,0));
        }
    }

    public void UseMoney(int moneyUse)
    {
        Money -= moneyUse;
        PlayerPrefs.SetInt("money", Money);
        PlayerPrefs.Save();
        LeanTween.dispatchEvent((int)Events.MONEYCHANGED);
    }
}
