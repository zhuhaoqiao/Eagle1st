using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QAssetBundle;

namespace Eagle1st
{
    public class BulletPool : MonoSingleton<BulletPool>
    {
        private Dictionary<int, List<GameObject>> mInactiveBulletDict = new Dictionary<int, List<GameObject>>();

        private ResLoader mResLoader = null;

        public override void OnSingletonInit()
        {
            base.OnSingletonInit();

            mResLoader = ResLoader.Allocate();
        }


        public BulletElement AddBulletById(int bulletId)
        {
            if (!ModelResMgr.Instance.ActiveBulletDict.ContainsKey(bulletId))
                return null;

            GameObject BulletObj = null;

            if (mInactiveBulletDict.ContainsKey(bulletId))
            {
                BulletObj = mInactiveBulletDict[bulletId][0];
                mInactiveBulletDict[bulletId].RemoveAt(0);

                if (mInactiveBulletDict[bulletId].Count == 0 || mInactiveBulletDict[bulletId] == null)
                {
                    mInactiveBulletDict.Remove(bulletId);
                }
            }
            else
            {
                BulletObj = Instantiate(mResLoader.LoadSync<GameObject>(Bulletpre.BundleName, ModelResMgr.Instance.ActiveBulletDict[bulletId].Type)) as GameObject;
            }

            BulletElement bulletElement = BulletObj.AddComponent<BulletElement>();
            bulletElement.Id = ModelResMgr.Instance.ActiveBulletDict[bulletId].Id;
            bulletElement.Damage = ModelResMgr.Instance.ActiveBulletDict[bulletId].Damage;
            bulletElement.Type = ModelResMgr.Instance.ActiveBulletDict[bulletId].Type;
            bulletElement.Distance = ModelResMgr.Instance.ActiveBulletDict[bulletId].Distance;
            bulletElement.Blow = ModelResMgr.Instance.ActiveBulletDict[bulletId].Blow;
            bulletElement.Speed = ModelResMgr.Instance.ActiveBulletDict[bulletId].Speed;
            bulletElement.RadarValue = ModelResMgr.Instance.ActiveBulletDict[bulletId].RadarValue;
            bulletElement.transform.localPosition = Vector3.zero;

            return bulletElement;
        }

        public void RecyclePlane(BulletElement bulletElement)
        {
            int idKey = bulletElement.Id;
            GameObject bulletObj = bulletElement.gameObject;

            Destroy(bulletObj.GetComponent<BulletElement>());

            if (mInactiveBulletDict.ContainsKey(idKey))
            {
                mInactiveBulletDict[idKey].Add(bulletObj);
            }
            else
            {
                mInactiveBulletDict.Add(idKey, new List<GameObject> { bulletObj });
            }
        }

        public void Clear()
        {
            mInactiveBulletDict.Clear();
            mResLoader.Recycle2Cache();
            mResLoader = null;
        }
    }
}
