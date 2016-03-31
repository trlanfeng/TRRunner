﻿using UnityEngine;
using System.Collections;

namespace TRRunner
{
    public class GameManager : MonoBehaviour
    {
        public float gameSpeed;
        // Use this for initialization
        void Start()
        {
            gameSpeed = 1;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 pos = transform.position;
            pos.x -= gameSpeed * Time.deltaTime;
        }
    }
}
