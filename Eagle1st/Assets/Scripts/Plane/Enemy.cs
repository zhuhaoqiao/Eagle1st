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
            UIManager.Instance.SendMsg(new UIEnemyPosRefreshMsg() {
                Id = mPlaneAttribute.Id,
                WorldPos = transform.position
            });
        }

        void OnDestroy()
        {
            UIManager.Instance.SendMsg(new UIPlaneDestroyMsg()
            {
                Id = mPlaneAttribute.Id,
            });
        }
    }
}
