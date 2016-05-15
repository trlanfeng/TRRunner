using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    MeshRenderer MR;
    public enum BackgroundType
    {
        Sprite,
        Texture
    }
    public BackgroundType backgroundType;
    public float moveSpeed;

    void Start()
    {
        MR = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        MR.material.mainTextureOffset += new Vector2(Time.deltaTime * moveSpeed * 0.02f, 0);
    }
}
