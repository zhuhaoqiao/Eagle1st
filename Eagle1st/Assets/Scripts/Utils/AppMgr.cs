using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    [MonoSingletonPath("[Entrance]/AppMgr")]
    public class AppMgr : MonoBehaviour, ISingleton
    {
        public static AppMgr Instance
        {
            get { return MonoSingletonProperty<AppMgr>.Instance; }
        }

        public void OnSingletonInit()
        {
            Debug.Log("ResMgr Init");
            ResMgr.Init();
        }

        void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        void Start()
        {

            //Ìí¼ÓÆô¶¯Ä£¿é
            //gameObject.AddComponent<StartProcessModule>();
        }
    }
}

