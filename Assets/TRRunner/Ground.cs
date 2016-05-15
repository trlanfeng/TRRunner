using UnityEngine;
using System.Collections;

namespace TRRunner
{
    public class Ground : MonoBehaviour
    {

        public float speed;
        public float width;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x < -20.48f)
            {
                transform.position += new Vector3(20.48f * 2, 0, 0);
            }
        }
    }
}

