using UnityEngine;
using System.Collections.Generic;
using GameDataEditor;

public class WeaponManager : MonoBehaviour
{

    #region Properties
    /// <summary>
    /// 所有武器
    /// </summary>
    List<GDEWeaponData> lstWeapons = new List<GDEWeaponData>();
    /// <summary>
    /// 当前武器
    /// </summary>
    public GDEWeaponData currentWeapon = null;
    #endregion

    #region 单例模式

    private static WeaponManager _instance = null;

    public WeaponManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WeaponManager>();
                if (_instance == null)
                {
                    GameObject o = new GameObject("WeaponManagerContainer");
                    _instance = o.AddComponent<WeaponManager>();
                }
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }



    #endregion

    #region Monobehavior Method
    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            InitWeaponData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Custom Method

    /// <summary>
    /// 初始化武器数据
    /// </summary>
    void InitWeaponData()
    {
        GDEDataManager.Init("gde_data");
        List<string> wpKeys = new List<string>();
        if (GDEDataManager.GetAllDataKeysBySchema("Weapon", out wpKeys))
        {
            lstWeapons.Clear();
            for (int i = 0; i < wpKeys.Count; i++)
            {
                GDEWeaponData wp = null;
                GDEDataManager.DataDictionary.TryGetCustom(wpKeys[i], out wp);
                if (wp != null)
                {
                    lstWeapons.Add(wp);
                    if (wp.Equped)
                    {
                        currentWeapon = wp;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Get Weapon keys failed!!");
        }
    }

    /// <summary>
    /// 装备武器
    /// </summary>
    /// <param name="id"></param>
    public void EqWeaon(int id)
    {
        for (int i = 0; i < lstWeapons.Count; i++)
        {
            if (lstWeapons[i].Id != id)
            {
                lstWeapons[i].Equped = false;
            }
            else
            {
                lstWeapons[i].Equped = true;
                currentWeapon = lstWeapons[i];
            }
        }
    }

    /// <summary>
    /// 购买武器
    /// </summary>
    /// <param name="id">武器id</param>
    /// <returns>返回是否购买成功</returns>
    public bool BuyWeapon(int id)
    {

        GDEWeaponData w = lstWeapons.Find((p) => { return p.Id == id; });
        if (w != null)
        {
            if (w.Owend)
            {
                return true;
            }
            if (Player.CurrentUser.IsMoneyEnough(ConvertUtil.ToInt32(w.Cost, 1000000)))
            {
                Player.CurrentUser.UseMoney(ConvertUtil.ToInt32(w.Cost, 1000000));
                w.Owend = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region 计算相关
    /// <summary>
    /// 武器属性相加 ,返回结果.
    /// </summary>
    /// <param name="attr1"></param>
    /// <param name="attr2"></param>
    /// <returns></returns>
    public GDEWeaponAttributeData AttributeAdd(GDEWeaponAttributeData attr1 , GDEWeaponAttributeData attr2)
    {
        return null;
    }

    #endregion
}
