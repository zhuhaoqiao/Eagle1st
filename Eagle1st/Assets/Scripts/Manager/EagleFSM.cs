using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

namespace Eagle1st
{
    public enum EagleState
    {
        IDLE,
        TAKEOFF,
        FLIGHT,
        SPEEDUP,
        LANDING,
        DEATH
    }

    public enum EagleFSMEvent
    {
        GameBegin,
        TakeOffSuccess,
        LandingBegin,
        UpSpeed,
        DownSpeed,
        Dstroyed,
        LandingSuccess
    }

    public class EagleFSM : MonoBehaviour
    {   
        QFSMLite mEagleFSMLite = new QFSMLite();

        public Action GameBeginCallBack;
        public Action TakeOffSuccessCallBack;
        public Action LandingBeginCallBack;
        public Action UpSpeedCallBack;
        public Action DownSpeedCallBack;
        public Action DestroyedCallBack;
        public Action LandingSuccessCallBack;

        private EagleState mCurrentState;

        public EagleState CurrentState
        {
            get { return mCurrentState; }
        }

        void Start()
        {
            mEagleFSMLite.AddState(EagleState.IDLE.ToString());
            mEagleFSMLite.AddState(EagleState.TAKEOFF.ToString());
            mEagleFSMLite.AddState(EagleState.FLIGHT.ToString());
            mEagleFSMLite.AddState(EagleState.SPEEDUP.ToString());
            mEagleFSMLite.AddState(EagleState.LANDING.ToString());
            mEagleFSMLite.AddState(EagleState.DEATH.ToString());

            mEagleFSMLite.AddTranslation(EagleState.IDLE.ToString(), EagleFSMEvent.GameBegin.ToString(), EagleState.TAKEOFF.ToString(), delegate
             {
                 GameBeginCallBack.InvokeGracefully();
                 mCurrentState = EagleState.TAKEOFF;
             });

            mEagleFSMLite.AddTranslation(EagleState.TAKEOFF.ToString(), EagleFSMEvent.TakeOffSuccess.ToString(), EagleState.FLIGHT.ToString(), delegate
            {
                TakeOffSuccessCallBack.InvokeGracefully();
                mCurrentState = EagleState.FLIGHT;
            });

            mEagleFSMLite.AddTranslation(EagleState.FLIGHT.ToString(), EagleFSMEvent.LandingBegin.ToString(), EagleState.LANDING.ToString(), delegate
            {
                LandingBeginCallBack.InvokeGracefully();
                mCurrentState = EagleState.LANDING;
            });

            mEagleFSMLite.AddTranslation(EagleState.FLIGHT.ToString(), EagleFSMEvent.UpSpeed.ToString(), EagleState.SPEEDUP.ToString(), delegate
            {
                UpSpeedCallBack.InvokeGracefully();
                mCurrentState = EagleState.SPEEDUP;
            });

            mEagleFSMLite.AddTranslation(EagleState.SPEEDUP.ToString(), EagleFSMEvent.DownSpeed.ToString(), EagleState.FLIGHT.ToString(), delegate
            {
                DownSpeedCallBack.InvokeGracefully();
                mCurrentState = EagleState.FLIGHT;
            });

            mEagleFSMLite.AddTranslation(EagleState.FLIGHT.ToString(), EagleFSMEvent.Dstroyed.ToString(), EagleState.DEATH.ToString(), delegate
            {
                DestroyedCallBack.InvokeGracefully();
                mCurrentState = EagleState.DEATH;
            });

            mEagleFSMLite.AddTranslation(EagleState.LANDING.ToString(), EagleFSMEvent.LandingSuccess.ToString(), EagleState.IDLE.ToString(), delegate
            {
                LandingSuccessCallBack.InvokeGracefully();
                mCurrentState = EagleState.IDLE;
            });
        }

        public void StartState(EagleState startState)
        {
            mEagleFSMLite.Start(startState.ToString());
        }

        public void Clear()
        {
            GameBeginCallBack = null;
            TakeOffSuccessCallBack = null;
            LandingBeginCallBack = null;
            UpSpeedCallBack = null;
            DownSpeedCallBack = null;
            DestroyedCallBack = null;
            LandingSuccessCallBack = null;
            mEagleFSMLite.Clear();
        }

        public void Perform(EagleFSMEvent eagleFSMEvent)
        {
            mEagleFSMLite.HandleEvent(eagleFSMEvent.ToString());
        }
    }
}
