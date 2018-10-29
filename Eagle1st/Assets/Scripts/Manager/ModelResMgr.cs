using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using LitJson;

namespace Eagle1st
{
    public class ModelResMgr : MonoSingleton<ModelResMgr>
    {
        private Dictionary<string, PlaneAttribute> mActivePlaneDict = new Dictionary<string, PlaneAttribute>();
        private Dictionary<int, BulletElement> mActiveBulletDict = new Dictionary<int, BulletElement>();

        public Dictionary<string, PlaneAttribute> ActivePlaneDict
        {
            get { return mActivePlaneDict; }
        }

        public Dictionary<int, BulletElement> ActiveBulletDict
        {

            get { return mActiveBulletDict; }
        }

        public override void OnSingletonInit()
        {
            mActivePlaneDict.Add("Player", new PlaneAttribute() { Model = "Player" });
            mActivePlaneDict.Add("F10", new PlaneAttribute() { Model = "F10" });
            mActivePlaneDict.Add("J_11", new PlaneAttribute() { Model = "J_11" });
            mActiveBulletDict.Add(1, new BulletElement() { Id = 1, Type = "bullet_1", Distance = 10000f, Blow = 300f, Speed = 100f, Damage = 10, RadarValue = 50f });
        }

        public void GetPlaneInfo(string url)
        {
            WWWHelper.Instance.WWWGetText(url, 15f, (text) =>
             {
                 JsonMapper.ToObject<PlaneData>(text);
             });
        }

        public void GetBulletInfo(string url)
        {
            WWWHelper.Instance.WWWGetText(url, 15f, (text) =>
            {
                JsonMapper.ToObject<BulletElement>(text);
            });
        }
    }
}
