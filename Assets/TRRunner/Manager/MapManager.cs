using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TRRunner
{
    public class MapManager : MonoBehaviour
    {
        private List<Transform> gounrds;
        private Transform lastGround;
        public float mapSpeed;

        void Start()
        {
            mapSpeed = 1f;
            initMap();
        }
        void Update()
        {

        }

        void initMap()
        {
            GameObject ground = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Map/ground"));
            
        }
    }
}
