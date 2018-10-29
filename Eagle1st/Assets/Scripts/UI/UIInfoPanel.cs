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
	public class UIInfoPanelData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UIInfoPanel : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UIInfoPanelData ?? new UIInfoPanelData();
			//please add init code here
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

		protected override void RegisterUIEvent()
		{
            BasicInfo.onClick.AddListener((() =>
            {
                BasicInfoPanel.Show();
                HisGradePanel.Hide();
                AddPalPanel.Hide();
            } ));

           HisGrade.onClick.AddListener((() =>
           {
               HisGradePanel.Show();
               AddPalPanel.Hide();
               BasicInfoPanel.Hide();
           }));

            AddPal.onClick.AddListener((() =>
            {
                AddPalPanel.Show();
                BasicInfoPanel.Hide();
                HisGradePanel.Hide();
            }));

            Btn_QuitPanel.onClick.AddListener((() =>
            {
                UIMgr.OpenPanel<UIPlayerMainMenu>();
                CloseSelf();
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
			Debug.Log("[ UIInfoPanel:]" + content);
		}
	}
}