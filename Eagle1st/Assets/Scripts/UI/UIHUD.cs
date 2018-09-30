/****************************************************************************
 * 2018.9 DESKTOP-S5L3H66
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Eagle1st
{
	public class UIHUDData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

    public class UIEnemyPosRefreshMsg : QMsg
    {
        public int Id;
        public Vector3 WorldPos = new Vector3();
    }

    public class UIPlaneDestroyMsg : QMsg
    {
        public int Id;
    }

    public partial class UIHUD : UIPanel
	{
        private Dictionary<int,GameObject> mEnemyPosBoxDict = new Dictionary<int, GameObject>();

        private Transform mTopRightPos;
        private Transform mLowerLeftPos;

        protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UIHUDData ?? new UIHUDData();

            mTopRightPos = GameObject.Find("TopRight").transform;
            mLowerLeftPos = GameObject.Find("LowerLeft").transform;
            //please add init code here

            GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 76f);
            GetComponent<RectTransform>().sizeDelta = new Vector2(30f, 25f);
        }

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
            switch (eventId)
            {
                case (int)UIHUDEvent.RefreshHUD:
                    UIEnemyPosRefreshMsg posMsg = msg as UIEnemyPosRefreshMsg;                  
                    RefreshEnemyPos(posMsg.Id, posMsg.WorldPos);
                    break;
                case (int)UIHUDEvent.PlaneDestroy:
                    UIPlaneDestroyMsg planeDestroyMsg = msg as UIPlaneDestroyMsg;
                    if(mEnemyPosBoxDict.ContainsKey(planeDestroyMsg.Id))
                    {
                        mEnemyPosBoxDict.Remove(planeDestroyMsg.Id);
                    }
                    break;
            }
        }
        

		protected override void RegisterUIEvent()
		{
            RegisterEvent(UIHUDEvent.RefreshHUD);
            RegisterEvent(UIHUDEvent.PlaneDestroy);
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
			Debug.Log("[ UIHUD:]" + content);
		}

        private void RefreshEnemyPos(int enemyId,Vector3 enemyWorldPos)
        {
            float MaxY = Camera.main.WorldToScreenPoint(mTopRightPos.position).y;
            float MaxX = Camera.main.WorldToScreenPoint(mTopRightPos.position).x;
            float MinY = Camera.main.WorldToScreenPoint(mLowerLeftPos.position).y;
            float MinX = Camera.main.WorldToScreenPoint(mLowerLeftPos.position).x;

            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemyWorldPos);
            if (!mEnemyPosBoxDict.ContainsKey(enemyId))
            {
                GameObject boxGO = Instantiate(Box_Pre.gameObject) as GameObject;
                boxGO.transform.SetParent(transform);
                mEnemyPosBoxDict.Add(enemyId, boxGO);
            }

            mEnemyPosBoxDict[enemyId].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(enemyScreenPos.x, enemyScreenPos.y, Camera.main.WorldToScreenPoint(transform.position).z));

            if (enemyScreenPos.y < MaxY && enemyScreenPos.y > MinY && enemyScreenPos.x < MaxX && enemyScreenPos.x > MinX)
            {
                mEnemyPosBoxDict[enemyId].Show();
            }
            else
            {
                mEnemyPosBoxDict[enemyId].Hide();
            }
        }
    }
    
}