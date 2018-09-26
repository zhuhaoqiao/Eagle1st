using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QAssetBundle;

namespace Eagle1st
{
    public class PlanePool : MonoSingleton<PlanePool>
    {
        private Dictionary<string, List<GameObject>> mInactivePlaneDict = new Dictionary<string, List<GameObject>>();

        private ResLoader mResLoader = null;

        public override void OnSingletonInit()
        {
            base.OnSingletonInit();

            mResLoader = ResLoader.Allocate();
        }


        public PlaneAttribute AddPlaneByModel(string model, PlaneType planeType = PlaneType.Enemy)
        {
            if (!ModelResMgr.Instance.ActivePlaneDict.ContainsKey(model))
            {
                Debug.Log("Not Plane!!!");
                return null;
            }

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
                PlaneObj = Instantiate(mResLoader.LoadSync<GameObject>(Planepre.BundleName, model)) as GameObject;
            }

            PlaneAttribute planeAttribute = PlaneObj.AddComponent<PlaneAttribute>();
            planeAttribute.hpElement = PlaneObj.AddComponent<HPElement>();
            planeAttribute.CtrlType = planeType;
            planeAttribute.Model = model;
            planeAttribute.gameObject.tag = planeType.ToString();
            planeAttribute.transform.localPosition = Vector3.zero;

            return planeAttribute;
        }

        public void RecyclePlane(PlaneAttribute planeAttribute)
        {
            string modelKey = planeAttribute.Model;
            GameObject planeObj = planeAttribute.gameObject;
            planeObj.tag = "Untagged";

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

        public void Clear()
        {
            mInactivePlaneDict.Clear();
            mResLoader.Recycle2Cache();
            mResLoader = null;
        }
    }
}

