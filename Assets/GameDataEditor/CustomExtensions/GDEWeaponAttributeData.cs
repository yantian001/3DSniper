// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the Game Data Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;

using GameDataEditor;

namespace GameDataEditor
{
    public class GDEWeaponAttributeData : IGDEData
    {
        private static string BoughtKey = "Bought";
		private bool _Bought;
        public bool Bought
        {
            get { return _Bought; }
            set {
                if (_Bought != value)
                {
                    _Bought = value;
                    GDEDataManager.SetBool(_key+"_"+BoughtKey, _Bought);
                }
            }
        }

        private static string PowerKey = "Power";
		private float _Power;
        public float Power
        {
            get { return _Power; }
            set {
                if (_Power != value)
                {
                    _Power = value;
                    GDEDataManager.SetFloat(_key+"_"+PowerKey, _Power);
                }
            }
        }

        private static string StabKey = "Stab";
		private float _Stab;
        public float Stab
        {
            get { return _Stab; }
            set {
                if (_Stab != value)
                {
                    _Stab = value;
                    GDEDataManager.SetFloat(_key+"_"+StabKey, _Stab);
                }
            }
        }

        private static string ClipKey = "Clip";
		private float _Clip;
        public float Clip
        {
            get { return _Clip; }
            set {
                if (_Clip != value)
                {
                    _Clip = value;
                    GDEDataManager.SetFloat(_key+"_"+ClipKey, _Clip);
                }
            }
        }

        private static string AmmoKey = "Ammo";
		private float _Ammo;
        public float Ammo
        {
            get { return _Ammo; }
            set {
                if (_Ammo != value)
                {
                    _Ammo = value;
                    GDEDataManager.SetFloat(_key+"_"+AmmoKey, _Ammo);
                }
            }
        }

        private static string InfraKey = "Infra";
		private float _Infra;
        public float Infra
        {
            get { return _Infra; }
            set {
                if (_Infra != value)
                {
                    _Infra = value;
                    GDEDataManager.SetFloat(_key+"_"+InfraKey, _Infra);
                }
            }
        }

        private static string PriceKey = "Price";
		private float _Price;
        public float Price
        {
            get { return _Price; }
            set {
                if (_Price != value)
                {
                    _Price = value;
                    GDEDataManager.SetFloat(_key+"_"+PriceKey, _Price);
                }
            }
        }

        public GDEWeaponAttributeData()
		{
			_key = string.Empty;
		}

		public GDEWeaponAttributeData(string key)
		{
			_key = key;
		}
		
        public override void LoadFromDict(string dataKey, Dictionary<string, object> dict)
        {
            _key = dataKey;

			if (dict == null)
				LoadFromSavedData(dataKey);
			else
			{
                dict.TryGetBool(BoughtKey, out _Bought);
                dict.TryGetFloat(PowerKey, out _Power);
                dict.TryGetFloat(StabKey, out _Stab);
                dict.TryGetFloat(ClipKey, out _Clip);
                dict.TryGetFloat(AmmoKey, out _Ammo);
                dict.TryGetFloat(InfraKey, out _Infra);
                dict.TryGetFloat(PriceKey, out _Price);
                LoadFromSavedData(dataKey);
			}
		}

        public override void LoadFromSavedData(string dataKey)
		{
			_key = dataKey;
			
            _Bought = GDEDataManager.GetBool(_key+"_"+BoughtKey, _Bought);
            _Power = GDEDataManager.GetFloat(_key+"_"+PowerKey, _Power);
            _Stab = GDEDataManager.GetFloat(_key+"_"+StabKey, _Stab);
            _Clip = GDEDataManager.GetFloat(_key+"_"+ClipKey, _Clip);
            _Ammo = GDEDataManager.GetFloat(_key+"_"+AmmoKey, _Ammo);
            _Infra = GDEDataManager.GetFloat(_key+"_"+InfraKey, _Infra);
            _Price = GDEDataManager.GetFloat(_key+"_"+PriceKey, _Price);
         }

        public void Reset_Bought()
        {
            GDEDataManager.ResetToDefault(_key, BoughtKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetBool(BoughtKey, out _Bought);
        }

        public void Reset_Power()
        {
            GDEDataManager.ResetToDefault(_key, PowerKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(PowerKey, out _Power);
        }

        public void Reset_Stab()
        {
            GDEDataManager.ResetToDefault(_key, StabKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(StabKey, out _Stab);
        }

        public void Reset_Clip()
        {
            GDEDataManager.ResetToDefault(_key, ClipKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(ClipKey, out _Clip);
        }

        public void Reset_Ammo()
        {
            GDEDataManager.ResetToDefault(_key, AmmoKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(AmmoKey, out _Ammo);
        }

        public void Reset_Infra()
        {
            GDEDataManager.ResetToDefault(_key, InfraKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(InfraKey, out _Infra);
        }

        public void Reset_Price()
        {
            GDEDataManager.ResetToDefault(_key, PriceKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(PriceKey, out _Price);
        }

        public void ResetAll()
        {
            GDEDataManager.ResetToDefault(_key, PowerKey);
            GDEDataManager.ResetToDefault(_key, StabKey);
            GDEDataManager.ResetToDefault(_key, ClipKey);
            GDEDataManager.ResetToDefault(_key, AmmoKey);
            GDEDataManager.ResetToDefault(_key, InfraKey);
            GDEDataManager.ResetToDefault(_key, PriceKey);
            GDEDataManager.ResetToDefault(_key, BoughtKey);


            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            LoadFromDict(_key, dict);
        }
    }
}