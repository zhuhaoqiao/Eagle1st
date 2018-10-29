using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Eagle1st
{
    public class Enemy : MonoBehaviour
    {
        private PlaneAttribute mPlaneAttribute;

        void Start()
        {
            mPlaneAttribute = gameObject.GetComponent<PlaneAttribute>();
        }

        void Update()
        {
            QMsgCenter.Instance.SendMsg(new UIEnemyPosRefreshMsg() {
                EventID = (ushort)UIHUDEvent.RefreshHUD,
                Id = mPlaneAttribute.Id,
                EnemyGO = gameObject
            });
        }

        void OnDestroy()
        {
            QMsgCenter.Instance.SendMsg(new UIPlaneDestroyMsg()
            {
                EventID = (ushort)UIHUDEvent.PlaneDestroy,
                Id = mPlaneAttribute.Id,
            });
        }
    }
}
