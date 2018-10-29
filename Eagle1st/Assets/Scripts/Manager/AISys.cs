using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class AISys : MonoBehaviour
    {
        private GameObject mPlayer;

        private float mSpeed = 1000f;

        private Vector3 mTargetPointVec3;

        private float mRotaValueLimit = 30f;
        private float mRotaValueY;
        private float mRotaSpeed = 10f;

        private int mLevel;
        public int Level
        {
            get { return mLevel; }
        }

        private bool mIsScan;
        public bool IsScan
        {
            get { return mIsScan; }
        }


        void Awake()
        {
            mPlayer = GameObject.Find("Player(Clone)");
            mIsScan = false;

        }


        public void Load(float eyeDistance,Transform eye)
        {
            transform.position = eye.position + new Vector3(Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f) + eyeDistance);
        }

        void Start()
        {            
             
        }
        void Update()
        {
            if (IsScan)
            {
                transform.LookAt(mPlayer.transform);
            }
            else
            {
                if (mRotaValueY > 60f || mRotaValueY < -60f)
                {
                    mRotaSpeed = -mRotaSpeed;
                }

                mRotaValueY += Time.deltaTime * mRotaSpeed;
                transform.localRotation = Quaternion.Euler(new Vector3(0f, mRotaValueY, 0f));
            }

            transform.position += transform.forward * Time.deltaTime * mSpeed;
        }

        public void RadarScanPlayer()
        {
            mIsScan = true;
        }
        
        public void RadarNotScanPlayer()
        {
            mIsScan = false;
        }
    }
}
