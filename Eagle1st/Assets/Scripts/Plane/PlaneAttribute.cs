using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class PlaneAttribute : MonoBehaviour
    {
        public int Id;
        public string Model;
        public PlaneType CtrlType;
        public HPElement hpElement;
        public List<int> BulletId;

        public void InitInfo()
        {
            
        }

    }
}
