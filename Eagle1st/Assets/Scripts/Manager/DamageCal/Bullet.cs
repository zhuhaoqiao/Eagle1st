using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class Bullet : MonoBehaviour
    {

        public int Id;
        public string Type;
        public int Damage;
        public float Distance;
        public float Blow;

        private float speed;
        private bool mCanRun;
        private Vector3 mRunDirect = Vector3.zero;

        private string mAttackName;

        public bool IsAttack
        {
            get { return mAttackName == "player" || mAttackName == "friendly" || mAttackName == "enemy"; }
        }

        private void OnCollisionEnter(Collision collision)
        {
            mAttackName = collision.gameObject.tag;

            if (IsAttack)
            {
                collision.gameObject.GetComponent<HPElement>().OnAttacked(Damage);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            mAttackName = string.Empty;
        }

        public void Launch(Vector3 direction)
        {
            mRunDirect = direction;

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
