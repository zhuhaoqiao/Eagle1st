using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MonoSingletonPath("[Entrance]/AppMgr")]
public class AppMgr : MonoBehaviour, ISingleton
{
    public static AppMgr Instance
    {
        get { return MonoSingletonProperty<AppMgr>.Instance; }
    }

    public void OnSingletonInit() { }

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Start()
    {
        ResMgr.Init();

        //Ìí¼ÓÆô¶¯Ä£¿é
        //gameObject.AddComponent<StartProcessModule>();
    }
}
