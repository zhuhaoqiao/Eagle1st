using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eagle1st
{
    public class AISys : MonoBehaviour
    {
        private float mSpeed = 1000f;

        public void Load(float eyeDistance,Transform eye)

        {
            transform.position = eye.position + new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f) + eyeDistance);
        }

        void Update()
        {
            transform.Translate(new Vector3(1f,0f,0f) * Time.deltaTime * mSpeed);
            if (transform.position.x > 7000f || transform.position.x < -7000f)
            {
                mSpeed = -mSpeed;
            }
        }
    }
}
