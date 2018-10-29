using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class Radar : MonoBehaviour
    {
        private float mScopeRadius;
        public float Scope
        {
            get { return mScopeRadius; }
        }

        public Action OnEnterExecute;
        public Action OnExitExecute;


        void Awake()
        {
            GetComponent<SphereCollider>().radius = 0f;
            OnEnterExecute = null;
            OnExitExecute = null;
        }

        public void OpenRadar(float radius,Action onEnter = null,Action onExit = null)
        {
            GetComponent<SphereCollider>().radius = radius;

            if(onEnter != null)
            {
                OnEnterExecute = null;
                OnEnterExecute = onEnter;
            }

            if (onExit != null)
            {
                OnExitExecute = null;
                OnExitExecute = onExit;
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            OnEnterExecute.Invoke();
        }

        private void OnTriggerExit(Collider collider)
        {
            OnExitExecute.Invoke();
        }
    }
}
