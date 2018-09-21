using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Eagle1st
{
    public class ResMgr : MonoSingleton<ResMgr>
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

        public void GetPlaneInfo(string url)
        {
            WWWHelper.Instance.WWWGetText(url, 15f, (text) =>
             {

             });
        }

        public void GetBulletInfo(string url)
        {
            WWWHelper.Instance.WWWGetText(url, 15f, (text) =>
            {

            });
        }
    }
}
