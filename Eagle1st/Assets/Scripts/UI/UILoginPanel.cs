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
            //��½���������¼�����ʱ��Ϊ�����½����ת������,ͬʱ�رյ�½�İ�ť
            //����˺��Ƿ���ڣ�����������½��˺ţ�
		    //�˺������Ƿ���ȷ�������������������������˺ţ�
		    Btn_Login.onClick.AddListener(() =>
		    {
		        UIMgr.OpenPanel<UIPlayerMainMenu>();
		        UIMgr.ClosePanel<UILoginPanel>();
            });

            //ע�᰸������¼��������תע�����
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