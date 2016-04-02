using UnityEngine;
using System.Collections;
namespace TRRunner
{
    public class Ground : MonoBehaviour
    {

        private GameManager GM;
        
        void Start()
        {
            GM = Camera.main.transform.GetComponent<GameManager>();
        }
        
        void Update()
        {
            Vector2 pos = transform.position;
            pos.x -= GM.gameSpeed * Time.deltaTime * 2;
            if (pos.x < -15)
            {
                pos.x = 15;
            }
            transform.position = pos;
        }
    }

}