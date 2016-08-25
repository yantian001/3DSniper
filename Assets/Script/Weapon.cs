using System.Collections;
using GameDataEditor;

public enum WeaponAttrType
{
    /// <summary>
    /// 火力
    /// </summary>
    Power = 0,
    /// <summary>
    /// 稳定性
    /// </summary>
    Stab,
    /// <summary>
    /// 弹夹容量
    /// </summary>
    Clip,
    /// <summary>
    /// 瞄准镜倍数
    /// </summary>
    Ammo,
    /// <summary>
    /// 红外线
    /// </summary>
    Infra,
}

public class Weapon
{
    /// <summary>
    /// Weapon Id(武器ID)
    /// </summary>
    public int Id
    {
        get
        {
            return WeaponData.Id;
        }
    }
    /// <summary>
    /// 武器名称
    /// </summary>
    public string Name
    {
        get
        {
            return WeaponData.Name;
        }
    }

    /// <summary>
    /// 武器火力
    /// </summary>
    public float Power
    {
        get
        {
            return GetWeaponAttr(WeaponAttrType.Power);
        }
    }
    /// <summary>
    /// 武器的最大火力
    /// </summary>
    public float MaxPower
    {
        get
        {
            return GetWeaponAttr(WeaponAttrType.Power, false);
        }
    }
    /// <summary>
    /// 稳定性
    /// </summary>
    public float Stab
    {
        get
        {
            return GetWeaponAttr(WeaponAttrType.Stab);
        }
    }
    /// <summary>
    /// 弹夹容量
    /// </summary>
    public float Clip
    {
        get
        {
            return GetWeaponAttr(WeaponAttrType.Clip);
        }
    }
    /// <summary>
    /// 瞄准镜倍数
    /// </summary>
    public float Ammo
    {
        get
        {
            return GetWeaponAttr(WeaponAttrType.Ammo);
        }
    }
    /// <summary>
    /// 红外线时间
    /// </summary>
    public float Infra
    {
        get
        {
            return GetWeaponAttr(WeaponAttrType.Infra);
        }
    }

    /// <summary>
    /// 获取武器属性的数值,current = true时,返回当前属性值(已升级),否则返回最大值(可升级).
    /// </summary>
    /// <param name="type">属性的类型</param>
    /// <param name="current">是否获取当前值</param>
    /// <returns>current = true时,返回当前属性值(已升级),否则返回最大值(可升级).</returns>
    public float GetWeaponAttr(WeaponAttrType type, bool current = true)
    {
        float value = 0f;
        GDEWeaponComponentData wc = null;
        for (int i = 0; i < WeaponData.WeaponComponents.Count; i++)
        {
            wc = WeaponData.WeaponComponents[i];
            for (int j = 0; j < wc.WeaponAttrs.Count; j++)
            {
                if (current || wc.WeaponAttrs[j].Bought)
                {
                    switch (type)
                    {
                        case WeaponAttrType.Power:
                            value += wc.WeaponAttrs[j].Power;
                            break;
                        case WeaponAttrType.Stab:
                            value += wc.WeaponAttrs[j].Stab;
                            break;
                        case WeaponAttrType.Clip:
                            value += wc.WeaponAttrs[j].Clip;
                            break;
                        case WeaponAttrType.Ammo:
                            value += wc.WeaponAttrs[j].Ammo;
                            break;
                        case WeaponAttrType.Infra:
                            value += wc.WeaponAttrs[j].Infra;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        return value;
    }

    /// <summary>
    /// 获得武器组件下一等级的属性
    /// </summary>
    /// <param name="componentId"></param>
    /// <returns></returns>
    public GDEWeaponAttributeData GetComponentNextAttr(int componentId)
    {
        GDEWeaponAttributeData ret = null;
        var component = WeaponData.WeaponComponents.Find(p => { return p.Id == componentId; });
        if (component != null)
        {
            for (int i = 0; i < component.WeaponAttrs.Count; i++)
            {
                if (!component.WeaponAttrs[i].Bought)
                    ret = component.WeaponAttrs[i];
            }
        }
        return ret;
    }
     
    public GDEWeaponData WeaponData;

    public Weapon(GDEWeaponData wd)
    {
        WeaponData = wd;
    }

}
