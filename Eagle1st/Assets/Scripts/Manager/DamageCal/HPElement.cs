using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using QFramework;

namespace Eagle1st
{
    public class HPElement : MonoBehaviour
    {

        private int mHP;

        public Action OnDestroyed;

        public int HP
        {
            get { return mHP; }
        }

        void Start()
        {
            mHP = 100;
        }

        public void OnAttacked(int damage)
        {
            mHP -= damage;

            if (mHP <= 0)
            {
                OnDestroyed.InvokeGracefully();

                Destroy(gameObject);
            }
        }

        void OnDestroy()
        {
            OnDestroyed = null;
        }
    }
}
