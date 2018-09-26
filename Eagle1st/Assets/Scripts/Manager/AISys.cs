using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class AISys : MonoBehaviour
    {
        public void Load(float eyeDistance,Transform eye)
        {
            transform.position = eye.position + new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f) + eyeDistance);
        }

        void Update()
        {
            transform.Translate(new Vector3(1f,1f,3f) * Time.deltaTime * 2f);
        }
    }
}
