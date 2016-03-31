using UnityEngine;
using System.Collections;
namespace TRRunner
{
    public class MapManager : MonoBehaviour
    {
        public Transform[] gounrds;
        public float groundTimer;
        public float createSpeed;
        void Start()
        {
            groundTimer = 0;
            createSpeed = 1f;
        }
        void Update()
        {
            if (groundTimer == 0)
            {
                var ground = GameObject.Instantiate(gounrds[Random.Range(0, gounrds.Length - 1)]);
                Vector2 pos = new Vector2(Random.Range(12.3f, 13.5f), Random.Range(0.5f, -3f));
                ground.position = pos;
            }
            groundTimer += Time.deltaTime;
            if (groundTimer > createSpeed)
            {
                groundTimer = 0;
            }
        }
    }
}
