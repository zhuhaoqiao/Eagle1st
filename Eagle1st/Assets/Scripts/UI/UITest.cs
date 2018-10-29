/****************************************************************************
 * 2018.10 DESKTOP-S5L3H66
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Eagle1st
{
	public class UITestData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UITest : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UITestData ?? new UITestData();
			//please add init code here
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

		protected override void RegisterUIEvent()
		{
            BtnTest.onClick.AddListener(() =>
            {
                Log.I("OnClick");
            });
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
			Debug.Log("[ UITest:]" + content);
		}
	}
}