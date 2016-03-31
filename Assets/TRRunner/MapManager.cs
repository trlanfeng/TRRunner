using UnityEngine;
using System.Collections;
namespace TRRunner
{
    public class MapManager : MonoBehaviour
    {
        public Transform[] gounrds;
        public float groundTimer;
        public float createSpeed;

        private GameManager GM;
        void Start()
        {
            groundTimer = 0;
            createSpeed = 1f;
            GM = transform.GetComponent<GameManager>();
        }
        void Update()
        {
            if (groundTimer == 0)
            {
                GameObject ground = GameObject.Instantiate(gounrds[Random.Range(0, gounrds.Length - 1)]).gameObject;
                Vector2 pos = new Vector2(Random.Range(12.3f, 13.5f), Random.Range(0.5f, -3f));
                ground.transform.position = pos;
                ground.AddComponent<Ground>();
            }
            groundTimer += Time.deltaTime;
            if (groundTimer > createSpeed / GM.gameSpeed)
            {
                groundTimer = 0;
            }
        }
    }
}
