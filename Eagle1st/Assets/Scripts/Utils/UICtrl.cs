using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour {

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

    }
}