namespace Eagle1st
{
    using UnityEngine;
    using System.Collections;
    using QFramework;

    public class TestUITest : MonoBehaviour
    {
        [SerializeField] SystemLanguage mSystemLanguage = SystemLanguage.Chinese;

        private IEnumerator Start()
        {
            ResMgr.Init();

            yield return new WaitForEndOfFrame();

            UIMgr.SetResolution(1280, 720,0);
            UIMgr.OpenPanel<UITest>(UILevel.Common);
        }
    }
}