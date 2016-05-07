using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    MeshRenderer MR;
    Material mat;
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
        mat = MR.material;
    }

    void Update()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime * moveSpeed * 0.2f;
        mat.mainTextureOffset = offset;
        MR.material = new Material(mat);
    }
}
