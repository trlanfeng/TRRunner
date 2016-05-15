using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TRRunner
{
    public class TreeManager : MonoBehaviour
    {
        public List<Transform> trees;
        private Transform treePool;

        public float moveSpeed;
        public float startX;
        public float dieX;
        public Vector2 yRange;
        public Vector2 timerRange;

        private float timer;
        private float generateTimer;

        void Start()
        {
            treePool = GameObject.Find("treePool").transform;
        }
        void Update()
        {
            float moveDelta = moveSpeed * Time.deltaTime;
            if (trees.Count == 0)
            {
                return;
            }
            timer += Time.deltaTime;
            if (timer > generateTimer)
            {
                generatetree();
            }
            foreach (Transform item in treePool)
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

        void generatetree()
        {
            GameObject tree = Instantiate<GameObject>(trees[Random.Range(0, trees.Count)].gameObject);
            settreePosition(tree.transform);
            tree.transform.SetParent(treePool.transform, false);
            generateTimer = Random.Range(timerRange.x, timerRange.y);
            timer = 0;

        }

        float rangeY()
        {
            float y = Random.Range(yRange.x, yRange.y);
            return y;
        }

        void settreePosition(Transform trans)
        {
            Vector3 t = trans.position;
            t.x = startX;
            t.y = rangeY();
            trans.position = t;
        }
    }
}
