using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    public Transform BackgroundsRoot;
    //需要视差滚动的背景列表
    public Transform[] backgrounds;
    //背景列表中每一项对应的速度
    public float[] bgSpeeds;
    public float baseSpeed;
    float startX;
    float startY;
    float endX;
    float endY;

    void Start()
    {
        BackgroundsRoot = GameObject.Find("Backgrounds").transform;
        int backgroundsCount = BackgroundsRoot.childCount;
        backgrounds = new Transform[backgroundsCount];
        for (int i = 0; i < backgroundsCount; i++)
        {
            backgrounds[i] = BackgroundsRoot.GetChild(i);
        }
        bgSpeeds = new float[backgroundsCount];
        for (int i = 0; i < backgroundsCount; i++)
        {
            bgSpeeds[i] = baseSpeed * (i + 1) * 0.6f;
        }
    }

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
