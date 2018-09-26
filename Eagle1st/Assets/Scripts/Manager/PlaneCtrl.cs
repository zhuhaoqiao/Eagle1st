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
            Debug.Log("Init Player");
            mCurrentPlane = PlanePool.Instance.AddPlaneByModel("F10", PlaneType.Player);

            mCurrentPlane.gameObject.AddComponent<Player>();
        }

        
    }
}
