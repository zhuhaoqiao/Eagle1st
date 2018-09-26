using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class UICtrl : MonoBehaviour
    {

        private LoadingCanvas mLoadingCanvas;

        // Use this for initialization
        void Start()
        {
            mLoadingCanvas = GameObject.Find("LoadingCanvas").GetComponent<LoadingCanvas>();

            OpenUIMain();
        }

        private void OpenUIMain()
        {
            if (mLoadingCanvas.gameObject)
            {
                Destroy(mLoadingCanvas.gameObject);
            }

            UIMgr.SetResolution(1280, 720, 0);

            PlaneCtrl.Instance.InitPlayer();

            PlaneCtrl.Instance.ProducteEnemy();
        }
    }
}
