using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class BulletElement : MonoBehaviour
    {
        public int Id;
        public string Type;
        public int Damage;
        public float Distance;
        public float Blow;
        public float speed;

        private bool mCanRun;
        private Vector3 mRunDirect = Vector3.zero;
        private string mParentTag;

        private string mAttackName;

        public bool IsAttack
        {
            get { return mAttackName == "Player" || mAttackName == "Friendly" || mAttackName == "Enemy"; }
        }

        private void OnTriggerEnter(Collider collider)
        {
            mAttackName = collider.gameObject.tag;

            if (IsAttack && mAttackName != mParentTag)
            {
                collider.gameObject.GetComponent<HPElement>().OnAttacked(Damage);
                Log.I(collider.gameObject.GetComponent<HPElement>().HP);
                Destroy(gameObject);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            mAttackName = string.Empty;
        }

        public void Launch(Transform parentTran)
        {
            mParentTag = parentTran.tag;
            mRunDirect = parentTran.localRotation.eulerAngles + Vector3.back;
            transform.SetParent(parentTran);

            this.Sequence()
               .Event(() => mCanRun = true)
               .Delay(Distance / speed)
               .Event(() => mCanRun = false)
               .Event(() => gameObject.GetComponent<SphereCollider>().radius = Blow)
               .Begin()
               .OnDisposed(() => { Destroy(gameObject); });
        }

        void Update()
        {
            if (mCanRun)
            {
                transform.Translate(mRunDirect * Time.deltaTime * speed);
            }
        }

        public void OnDestroy()
        {

        }
    }
}
