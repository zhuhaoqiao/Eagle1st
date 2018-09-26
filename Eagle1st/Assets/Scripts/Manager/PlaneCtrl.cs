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
        private PlaneAttribute mCurrentPlane;

        public void InitPlayer()
        {
            mCurrentPlane = PlanePool.Instance.AddPlaneByModel("F10", PlaneType.Player);

            mCurrentPlane.gameObject.AddComponent<Player>();
        }

        public void ProducteEnemy()
        {
            PlanePool.Instance.AddPlaneByModel("F10", PlaneType.Enemy).gameObject.AddComponent<AISys>().Load(4f, mCurrentPlane.transform);
        }
    }
}
