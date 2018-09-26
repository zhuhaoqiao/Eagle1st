using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Eagle1st
{
    public class BulletCtrl : MonoSingleton<BulletCtrl>
    {

        public void LaunchBullet(int bullerId, Transform parentTran)
        {
            BulletPool.Instance.AddBulletById(bullerId).Launch(parentTran);
        }
    }
}
