using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TRRunner
{
    public class CloudManager : MonoBehaviour
    {
        public List<Transform> clouds;
        private Transform cloudPool;

        public float moveSpeed;
        public float startX;
        public float dieX;
        public Vector2 yRange;
        public Vector2 timerRange;

        private float timer;
        private float generateTimer;

        void Start()
        {
            cloudPool = GameObject.Find("cloudPool").transform;
        }
        void Update()
        {
            float moveDelta = moveSpeed * Time.deltaTime;
            if (clouds.Count == 0)
            {
                return;
            }
            timer += Time.deltaTime;
            if (timer > generateTimer)
            {
                generateCloud();
            }
            foreach (Transform item in cloudPool)
            {
                Vector3 t = item.position;
                t.x -= moveDelta;
                if (t.x < dieX)
                {
                    item.gameObject.SetActive(false);
                }
                else
                {
                    item.position = t;
                }
            }
        }

        void generateCloud()
        {
            GameObject cloud = Instantiate<GameObject>(clouds[Random.Range(0, clouds.Count)].gameObject);
            setCloudPosition(cloud.transform);
            cloud.transform.SetParent(cloudPool.transform, false);
            generateTimer = Random.Range(timerRange.x, timerRange.y);
            timer = 0;

        }

        float rangeY()
        {
            float y = Random.Range(yRange.x, yRange.y);
            return y;
        }

        void setCloudPosition(Transform trans)
        {
            Vector3 t = trans.position;
            t.x = startX;
            t.y = rangeY();
            trans.position = t;
        }
    }
}
