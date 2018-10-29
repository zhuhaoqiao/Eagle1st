/****************************************************************************
 * 2018.10 DESKTOP-RIU3M20
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Eagle1st
{
	public class UILoginPanelData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UILoginPanel : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UILoginPanelData ?? new UILoginPanelData();
			//please add init code here
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

		protected override void RegisterUIEvent()
		{
            //登陆按键触发事件，暂时定为点击登陆就跳转主界面,同时关闭登陆的按钮
            //检查账号是否存在（否则就提醒新建账号）
		    //账号密码是否正确（否则就提醒玩玩家重新输入账号）
		    Btn_Login.onClick.AddListener(() =>
		    {
		        UIMgr.OpenPanel<UIPlayerMainMenu>();
		        UIMgr.ClosePanel<UILoginPanel>();
            });

            //注册案件点击事件，点击跳转注册界面
            Btn_Registe.onClick.AddListener((() =>
            {
                UIMgr.OpenPanel<UIRegistePanel>();
                UIMgr.ClosePanel<UILoginPanel>();
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
			Debug.Log("[ UILoginPanel:]" + content);
		}
	}
}