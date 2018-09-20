using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Eagle1st
{
    public class DamageCalMgr : MonoSingleton<DamageCalMgr>
    {
        public Dictionary<string, HPElement> AllActivePlaneDict = new Dictionary<string, HPElement>();

        public void RefreshPlans(string name,HPElement hpElement)
        {
            if (AllActivePlaneDict.ContainsKey(name))
            {
                AllActivePlaneDict[name] = hpElement;
            }
            else
            {
                AllActivePlaneDict.Add(name, hpElement);
            }
        }
    }
}
