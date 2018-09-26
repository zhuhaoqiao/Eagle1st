using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Eagle1st
{
    public class Player : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            //Init();
        }

        private void Init()
        {
            gameObject.AddComponent<EagleFSM>().StartState(EagleState.IDLE);

            DamageCalMgr.Instance.RefreshPlans(gameObject.name, gameObject.AddComponent<HPElement>());
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                BulletCtrl.Instance.LaunchBullet(1, transform);
            }
        }
    }
}
