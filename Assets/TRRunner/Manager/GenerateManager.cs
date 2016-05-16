using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TRRunner
{
    public class GenerateManager : MonoBehaviour
    {
        public List<Transform> objs;
        private Transform objList;
        Transform objPool;

        public float moveSpeed;
        public float startX;
        public float dieX;
        public Vector2 yRange;
        public Vector2 timerRange;

        private float timer;
        private float generateTimer;

        void Start()
        {
            objList = transform;
            objPool = new GameObject(transform.name + "Pool").transform;
        }
        void Update()
        {
            if (objs.Count == 0)
            {
                return;
            }
            float moveDelta = moveSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            if (timer > generateTimer)
            {
                generateobj();
            }
            for (int i = 0; i < objList.childCount; i++)
            {
                Vector3 t = objList.GetChild(i).position;
                t.x -= moveDelta;
                if (t.x < dieX)
                {
                    objList.GetChild(i).SetParent(objPool, false);
                }
                else
                {
                    objList.GetChild(i).position = t;
                }
            }
        }

        void generateobj()
        {
            Transform objTrans = null;
            if (objPool.childCount > 0)
            {
                objTrans = objPool.GetChild(Random.Range(0, objPool.childCount - 1));
            }
            else
            {
                objTrans = Instantiate<GameObject>(objs[Random.Range(0, objs.Count)].gameObject).transform;
            }
            if (objTrans == null)
            {
                return;
            }
            setobjPosition(objTrans);
            objTrans.SetParent(objList.transform, false);
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
