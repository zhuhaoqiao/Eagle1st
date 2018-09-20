using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Eagle1st
{
    public class PlanePool : MonoSingleton<PlanePool>
    {
        private Dictionary<string, PlaneAttribute> mActivePlaneDict = new Dictionary<string, PlaneAttribute>();
        private Dictionary<string, List<GameObject>> mInactivePlaneDict = new Dictionary<string, List<GameObject>>();

        private ResLoader mResLoader = null;

        public override void OnSingletonInit()
        {
            base.OnSingletonInit();

            mResLoader = ResLoader.Allocate();
        }


        public PlaneAttribute AddPlaneByModel(string model, PlaneType planeType = PlaneType.Enemy)
        {
            GameObject PlaneObj = null;

            if (mInactivePlaneDict.ContainsKey(model))
            {
                PlaneObj = mInactivePlaneDict[model][0];
                mInactivePlaneDict[model].RemoveAt(0);

                if (mInactivePlaneDict[model].Count == 0 || mInactivePlaneDict[model] == null)
                {
                    mInactivePlaneDict.Remove(model);
                }             
            }
            else
            {
                PlaneObj = Instantiate(mResLoader.LoadSync<GameObject>("", model)) as GameObject;                
            }

            PlaneAttribute planeAttribute = PlaneObj.AddComponent<PlaneAttribute>();
            planeAttribute.hpElement = PlaneObj.AddComponent<HPElement>();
            planeAttribute.CtrlType = planeType;
            planeAttribute.Model = model;

            mActivePlaneDict.Add(model, planeAttribute);

            return planeAttribute;
        }

        public void RecyclePlane(PlaneAttribute planeAttribute)
        {
            string modelKey = planeAttribute.Model;
            GameObject planeObj = planeAttribute.gameObject;

            List<Component> comList = new List<Component>();
            foreach (var component in planeObj.GetComponents<Component>())
            {
                comList.Add(component);
            }
            foreach (Component item in comList)
            {
                Destroy(item);
            }

            if (mInactivePlaneDict.ContainsKey(modelKey))
            {
                mInactivePlaneDict[modelKey].Add(planeObj);
            }
            else
            {
                mInactivePlaneDict.Add(modelKey, new List<GameObject> { planeObj });
            }
        }
    }
}

