/****************************************************************************
 * 2018.9 DESKTOP-S5L3H66
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Collections;

namespace Eagle1st
{
	public class UIHUDData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

    public class UIEnemyPosRefreshMsg : QMsg
    {
        public int Id;
        public GameObject EnemyGO;
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

        private GameObject mLockEnemy;
	    private GameObject mPlayerGO;

	    private bool mHUDIsShow;

        private float mShootTime = 1f;
        private bool mIsShoot;

        protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UIHUDData ?? new UIHUDData();

            mTopRightPos = GameObject.Find("TopRight").transform;
            mLowerLeftPos = GameObject.Find("LowerLeft").transform;
		    mPlayerGO = GameObject.Find("Player(Clone)") as GameObject;
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
                    mLockEnemy = posMsg.EnemyGO.transform.Find("CenterPoint").gameObject;
                    RefreshEnemyPos(posMsg.Id);
                    break;
                case (int)UIHUDEvent.PlaneDestroy:
                    UIPlaneDestroyMsg planeDestroyMsg = msg as UIPlaneDestroyMsg;
                    if(mEnemyPosBoxDict.ContainsKey(planeDestroyMsg.Id))
                    {
                        Destroy(mEnemyPosBoxDict[planeDestroyMsg.Id]);
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

        private void RefreshEnemyPos(int enemyId)
        {
            float MaxY = Camera.main.WorldToScreenPoint(mTopRightPos.position).y;
            float MaxX = Camera.main.WorldToScreenPoint(mTopRightPos.position).x;
            float MinY = Camera.main.WorldToScreenPoint(mLowerLeftPos.position).y;
            float MinX = Camera.main.WorldToScreenPoint(mLowerLeftPos.position).x;         

            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(mLockEnemy.transform.position);
            if (!mEnemyPosBoxDict.ContainsKey(enemyId))
            {
                GameObject boxGO = Instantiate(Box_Pre.gameObject) as GameObject;              
                boxGO.transform.SetParent(transform);
                boxGO.transform.localScale = Vector3.one * 0.0005f;
                mEnemyPosBoxDict.Add(enemyId, boxGO);
            }

            mEnemyPosBoxDict[enemyId].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(enemyScreenPos.x + 10f, enemyScreenPos.y, Camera.main.WorldToScreenPoint(mTopRightPos.position).z));

            if (enemyScreenPos.y < MaxY && enemyScreenPos.y > MinY && enemyScreenPos.x < MaxX && enemyScreenPos.x > MinX)
            {
                mHUDIsShow = true;
                mEnemyPosBoxDict[enemyId].Show();
            }
            else
            {
                mHUDIsShow = false;
                mEnemyPosBoxDict[enemyId].Hide();
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (mIsShoot) return;

                mIsShoot = true;
                this.Delay(mShootTime, () =>
                {
                    mIsShoot = false;
                });

                if (mHUDIsShow)
                {
                    BulletCtrl.Instance.LaunchBullet(1, mPlayerGO.transform, mLockEnemy);
                }
                else
                {
                    BulletCtrl.Instance.LaunchBullet(1, mPlayerGO.transform);
                }             
            }
        }
    }
    
}