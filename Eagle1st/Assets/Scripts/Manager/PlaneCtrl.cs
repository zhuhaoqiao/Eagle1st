using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Eagle1st
{
    public enum PlaneType
    {
        Player,
        Friendly,
        Enemy
    }

    public class PlaneCtrl : MonoSingleton<PlaneCtrl>
    {
        private PlaneAttribute mPlayerPlane;

        private Dictionary<int, PlaneAttribute> mFlightPlaneDict = new Dictionary<int, PlaneAttribute>();
        private List<int> mNoUseIndexList = new List<int>();

        public Dictionary<int, PlaneAttribute> FlightPlaneDict
        {
            get { return mFlightPlaneDict; }
        }

        private int mPlaneMaxIndex;

        public override void OnSingletonInit()
        {
            base.OnSingletonInit();

            mPlaneMaxIndex = 0;
        }

        public void InitPlayer()
        {
            mPlayerPlane = PlanePool.Instance.AddPlaneByModel("F10", PlaneType.Player);
            mPlayerPlane.Id = ReturnIndex();
            mFlightPlaneDict.Add(mPlaneMaxIndex, mPlayerPlane);
        }

        public void ProducteEnemy()
        {
            int enemyIndex = ReturnIndex();

            PlaneAttribute enemyPlane = PlanePool.Instance.AddPlaneByModel("F10", PlaneType.Enemy);
            enemyPlane.gameObject.AddComponent<AISys>().Load(4f, mPlayerPlane.transform);
            enemyPlane.Id = enemyIndex;
            mFlightPlaneDict.Add(enemyIndex, enemyPlane);
        }

        public void RecyclePlane(int planeId)
        {
            if (mFlightPlaneDict.ContainsKey(planeId))
            {
                mFlightPlaneDict.Remove(planeId);
                mNoUseIndexList.Add(planeId);
            }          
        }

        private int ReturnIndex()
        {
            int index;
            if (mNoUseIndexList.Count > 0)
            {
                index = mNoUseIndexList[0];
                mNoUseIndexList.RemoveAt(0);
            }
            else
            {
                index = mPlaneMaxIndex++;
            }
            return index;
        }
    }
}
