using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TRRunner
{
    public class MapManager : MonoBehaviour
    {
        private Transform groundPool;
        private List<Transform> grounds;
        private Transform lastGround;

        public float mapSpeed;
        public float dieX;
        public Vector2 widthRange;
        public Vector2 yRange;
        public Vector2 spaceRange;

        private float generateTimer;
        private float lastX;
        private float spaceX;

        void Start()
        {
            groundPool = new GameObject().transform;
            grounds = new List<Transform>();
            initGround();
        }
        void Update()
        {
            float moveDelta = mapSpeed * Time.deltaTime;
            if (grounds.Count == 0)
            {
                return;
            }
            lastGround = grounds[grounds.Count - 1];
            checkGenerate();
            foreach (var item in grounds)
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

        private void checkGenerate()
        {
            float a = lastGround.transform.position.x + lastGround.GetComponent<Sprite2D>().showSize.x * 0.01f / 2f;
            float b = Screen.width * 0.01f - 2;
            if (a < b)
            {
                generateGround();
                spaceX = rangeSpace();
            }
        }

        void initGround()
        {
            GameObject ground = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Map/ground"));
            ground.transform.localScale = new Vector3(3, 1, 1);
            Sprite2D s2d = ground.GetComponent<Sprite2D>();
            s2d.getSpriteSize();
            s2d.getSpriteCorner();
            lastX = s2d.Right;
            spaceX = rangeSpace();
            grounds.Add(ground.transform);
        }

        void generateGround()
        {
            GameObject ground = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Map/ground"));
            setGroundPosition(ground.transform);
            grounds.Add(ground.transform);
        }

        float rangeY()
        {
            float y = Random.Range(yRange.x, yRange.y);
            return y;
        }

        float rangeWidth()
        {
            float width = Random.Range(widthRange.x, widthRange.y);
            return width;
        }

        float rangeSpace()
        {
            float space = Random.Range(spaceRange.x, spaceRange.y);
            return space;
        }

        void setGroundPosition(Transform trans)
        {
            trans.localScale = new Vector3(rangeWidth(), 1, 1);
            Sprite2D s2d = trans.GetComponent<Sprite2D>();
            Vector3 t = trans.position;
            t.x = lastX + spaceX;
            s2d.getSpriteSize();
            float add = s2d.showSize.x * 0.01f * 0.5f;
            t.x += add;
            t.y = rangeY();
            trans.position = t;
        }
    }
}
