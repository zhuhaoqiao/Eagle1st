/****************************************************************************
 * 2018.10 DESKTOP-RIU3M20
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace Eagle1st
{
	public class UIPlayerMainMenuData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UIPlayerMainMenu : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UIPlayerMainMenuData ?? new UIPlayerMainMenuData();
			//please add init code here
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

        /// <summary>
        /// 个人信息界面的点击事件集
        /// 1.点击个人信息进入个人信息界面（暂定）
        /// 2.飞行练习点击事件，进入其他场景
        /// </summary>
		protected override void RegisterUIEvent()
		{
            SelfInfo.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UIInfoPanel>();
                UIMgr.ClosePanel<UIPlayerMainMenu>();
            });
                     
            FlyPractice.onClick.AddListener((() =>
            {
                SceneManager.LoadScene("Game");
            }));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnClose()
		{
			base.OnClose();
		}

		void ShowLog(string content)
		{
			Debug.Log("[ UIPlayerMainMenu:]" + content);
		}
	}
}