﻿using UnityEngine;
using System.Collections;
namespace TRRunner
{
    public class Ground : MonoBehaviour
    {

        private GameManager GM;

        // Use this for initialization
        void Start()
        {
            GM = Camera.main.transform.GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 pos = transform.position;
            pos.x -= GM.gameSpeed * Time.deltaTime * 2;
            transform.position = pos;
        }
    }

}