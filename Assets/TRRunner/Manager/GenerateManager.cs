using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TRRunner
{
    public class GenerateManager : MonoBehaviour
    {
        public List<Transform> objs;
        public List<Transform> objPool;

        public bool useSelfSpeed;
        public float moveSpeed;
        public float startX;
        public float dieX;
        public Vector2 yRange;
        public Vector2 timerRange;

        private float timer;
        private float generateTimer;
        public float baseGenerateTime;

        void Start()
        {
            generateTimer = 0;
            objPool = new List<Transform>();
            if (baseGenerateTime == 0)
            {
                baseGenerateTime = 3;
            }
        }
        void Update()
        {
            if (objs.Count == 0)
            {
                return;
            }
            if (!useSelfSpeed)
            {
                moveSpeed = Manager.GameSpeed;
            }
            float moveDelta = moveSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            if (timer > generateTimer * (baseGenerateTime / moveSpeed))
            {
                generateobj();
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    Vector3 t = transform.GetChild(i).position;
                    t.x -= moveDelta;
                    if (t.x < dieX)
                    {
                        transform.GetChild(i).gameObject.SetActive(false);
                        objPool.Add(transform.GetChild(i));
                    }
                    else
                    {
                        transform.GetChild(i).position = t;
                    }
                }
            }
        }

        void generateobj()
        {
            Transform objTrans = null;
            if (objPool.Count > 0)
            {
                objTrans = objPool[Random.Range(0, objPool.Count - 1)];
                objPool.Remove(objTrans);
            }
            else
            {
                objTrans = Instantiate<GameObject>(objs[Random.Range(0, objs.Count)].gameObject).transform;
                objTrans.SetParent(transform);
            }
            if (objTrans == null)
            {
                return;
            }
            setObjPosition(objTrans);
            objTrans.gameObject.SetActive(true);
            generateTimer = Random.Range(timerRange.x, timerRange.y);
            timer = 0;
        }

        float rangeY()
        {
            float y = Random.Range(yRange.x, yRange.y);
            return y;
        }

        void setObjPosition(Transform trans)
        {
            Vector3 t = trans.position;
            t.x = startX;
            t.y = rangeY();
            t.z = Random.Range(0f, 1f);
            trans.localPosition = t;
        }
    }
}
