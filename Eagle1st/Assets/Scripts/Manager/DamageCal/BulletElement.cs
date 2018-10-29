using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public enum BulletElementType
    {
        Gun,
        Missile
    }

    public class BulletElement : MonoBehaviour
    {
        public int Id;
        public string Type;
        public int Damage;
        public float Distance;
        public float Blow;
        public float Speed;
        public float RadarValue;

        private SphereCollider mTouchScope;
        private bool mIsRadar;
        private bool mCanRun;
        private Vector3 mRunDirect = Vector3.zero;
        private string mParentTag;
        private float mInitialTouchScope;
        private GameObject mTargetGO;

        private string mAttackName;

        private BulletElementType mCurrentBulletType;

        public BulletElementType CurrentBulletType
        {
            get { return mCurrentBulletType; }
        }

        void Awake()
        {
            mTouchScope = gameObject.GetComponent<SphereCollider>();
            mInitialTouchScope = mTouchScope.radius;
        }

        public bool IsAttack
        {
            get { return mAttackName == "Player" || mAttackName == "Friendly" || mAttackName == "Enemy"; }
        }

        private void OnTriggerEnter(Collider collider)
        {
            mAttackName = collider.gameObject.tag;
            Debug.Log(collider.name);
            if (IsAttack && mAttackName != mParentTag)
            {
                if (!mIsRadar && mCurrentBulletType == BulletElementType.Missile)
                {
                    mIsRadar = true;
                    mTouchScope.radius = mInitialTouchScope;
                    Speed *= 0.02f;
                }
                else
                {
                    collider.gameObject.GetComponent<HPElement>().OnAttacked(Damage);
                    Destroy(gameObject);
                }                               
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            mAttackName = string.Empty;
        }

        public void Launch(Transform parentTran, GameObject targetGO = null)
        {
            mParentTag = parentTran.tag;
            transform.SetParent(parentTran);
            transform.localPosition = new Vector3(0f, -750f, 900f);
            mRunDirect = new Vector3(0f, 0f, 90f);

            if (targetGO != null)
            {
                mTargetGO = targetGO;
                mCurrentBulletType = BulletElementType.Missile;
                Debug.Log(Distance + " " + RadarValue);

                mTouchScope.radius = RadarValue;

                this.Sequence()
                .Event(() => mCanRun = true)
                .Delay(Distance / Speed)
                .Event(() => mCanRun = false)
                .Event(() => mTouchScope.radius = Blow)
                .Begin()
                .OnDisposed(() => { Destroy(gameObject); });
            }
            else
            {                            
                mCurrentBulletType = BulletElementType.Gun;

                this.Sequence()
               .Event(() => mCanRun = true)
               .Delay(Distance / Speed)
               .Event(() => mCanRun = false)
               .Begin()
               .OnDisposed(() => { Destroy(gameObject); });
            }
        }
        
        void Update()
        {
            if (mTargetGO == null)
            {
                mCurrentBulletType = BulletElementType.Gun;
            }
    
            if (mCanRun)
            {
                Debug.Log(mCurrentBulletType + " " + mIsRadar);
                if (mCurrentBulletType == BulletElementType.Missile && mIsRadar)
                {
                    mRunDirect = mTargetGO.transform.position - transform.position;
                }

                transform.Translate(mRunDirect * Time.deltaTime * Speed);
            }
        }

        public void OnDestroy()
        {

        }
    }
}
