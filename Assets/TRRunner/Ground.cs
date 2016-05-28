using UnityEngine;
using System.Collections;

namespace TRRunner
{
    public class Ground : MonoBehaviour
    {

        //float speed;
        public float width;

        void Update()
        {
            transform.position += Vector3.left * Time.deltaTime * Manager.GameSpeed;
            if (transform.position.x < -width)
            {
                transform.position += new Vector3(width * 2, 0, 0);
            }
        }
    }
}

