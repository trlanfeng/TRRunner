using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TRRunner
{
    public class GenerateManager : MonoBehaviour
    {
        public List<Transform> objs;
        private Transform objPool;

        public float moveSpeed;
        public float startX;
        public float dieX;
        public Vector2 yRange;
        public Vector2 timerRange;

        private float timer;
        private float generateTimer;

        void Start()
        {
            objPool = transform;
        }
        void Update()
        {
            float moveDelta = moveSpeed * Time.deltaTime;
            if (objs.Count == 0)
            {
                return;
            }
            timer += Time.deltaTime;
            if (timer > generateTimer)
            {
                generateobj();
            }
            foreach (Transform item in objPool)
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

        void generateobj()
        {
            GameObject obj = Instantiate<GameObject>(objs[Random.Range(0, objs.Count)].gameObject);
            setobjPosition(obj.transform);
            obj.transform.SetParent(objPool.transform, false);
            generateTimer = Random.Range(timerRange.x, timerRange.y);
            timer = 0;

        }

        float rangeY()
        {
            float y = Random.Range(yRange.x, yRange.y);
            return y;
        }

        void setobjPosition(Transform trans)
        {
            Vector3 t = trans.position;
            t.x = startX;
            t.y = rangeY();
            trans.position = t;
        }
    }
}
