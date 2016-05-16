using UnityEngine;
using System.Collections;

namespace TRRunner
{
    public class Ground : MonoBehaviour
    {

        public float speed;
        public float width;

        void Update()
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            if (transform.position.x < -20.48f)
            {
                transform.position += new Vector3(20.48f * 2, 0, 0);
            }
        }
    }
}

