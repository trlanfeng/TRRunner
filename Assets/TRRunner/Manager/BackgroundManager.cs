using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    //需要视差滚动的背景列表
    public Transform[] backgrounds;
    //背景列表中每一项对应的速度
    public float[] bgSpeeds;
    float startX;
    float startY;
    float endX;
    float endY;

    void Update()
    {
        if (backgrounds.Length != bgSpeeds.Length)
        {
            Debug.LogError("背景的数量和背景的速度设置数量不一致，请检查！");
            return;
        }
        if (backgrounds.Length == 0)
        {
            return;
        }
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 tpos = backgrounds[i].position;
            tpos.x -= bgSpeeds[i] * Time.deltaTime;
            if (tpos.x < endX)
            {
                tpos.x = 10;
            }
            backgrounds[i].position = tpos;
        }
    }
}
