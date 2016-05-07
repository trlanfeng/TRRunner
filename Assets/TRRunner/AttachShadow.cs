using UnityEngine;
using System.Collections;

public class AttachShadow : MonoBehaviour
{
    public Transform attachRoot;
    void Update()
    {
        Vector3 p = attachRoot.position;
        p.y = transform.position.y;
        transform.position = p;
    }
}
