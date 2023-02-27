using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoundingBox : MonoBehaviour
{
    Matrix4x4 trs;
    private List<Vector3> boundingBox;
    Mesh render;
    MeshRenderer ren;
    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<MeshRenderer>();
        render = ren.GetComponent<Mesh>();
        boundingBox = new List<Vector3>();
        if (render != null)
        {
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[0].x - (transform.localScale.x / 2), render.vertices[0].y - (transform.localScale.y / 2), render.vertices[0].z - (transform.localScale.z / 2)));
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[1].x - (transform.localScale.x / 2), render.vertices[1].y - (transform.localScale.y / 2), render.vertices[1].z + (transform.localScale.z / 2)));
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[2].x - (transform.localScale.x / 2), render.vertices[2].y + (transform.localScale.y / 2), render.vertices[2].z - (transform.localScale.z / 2)));
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[3].x - (transform.localScale.x / 2), render.vertices[3].y + (transform.localScale.y / 2), render.vertices[3].z + (transform.localScale.z / 2)));
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[4].x + (transform.localScale.x / 2), render.vertices[4].y + (transform.localScale.y / 2), render.vertices[4].z - (transform.localScale.z / 2)));
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[5].x + (transform.localScale.x / 2), render.vertices[5].y + (transform.localScale.y / 2), render.vertices[5].z + (transform.localScale.z / 2)));
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[6].x + (transform.localScale.x / 2), render.vertices[6].y - (transform.localScale.y / 2), render.vertices[6].z - (transform.localScale.z / 2)));
            boundingBox.Add(transform.rotation * new Vector3(render.vertices[7].x + (transform.localScale.x / 2), render.vertices[7].y - (transform.localScale.y / 2), render.vertices[7].z + (transform.localScale.z / 2)));
        }
    }
    private void Update()
    {
        if (render != null)
        {
            boundingBox[0] = (transform.rotation * new Vector3(render.vertices[0].x - (transform.localScale.x / 2), render.vertices[0].y - (transform.localScale.y / 2), render.vertices[0].z - (transform.localScale.z / 2)));
            boundingBox[1] = (transform.rotation * new Vector3(render.vertices[1].x - (transform.localScale.x / 2), render.vertices[1].y - (transform.localScale.y / 2), render.vertices[1].z + (transform.localScale.z / 2)));
            boundingBox[2] = (transform.rotation * new Vector3(render.vertices[2].x - (transform.localScale.x / 2), render.vertices[2].y + (transform.localScale.y / 2), render.vertices[2].z - (transform.localScale.z / 2)));
            boundingBox[3] = (transform.rotation * new Vector3(render.vertices[3].x - (transform.localScale.x / 2), render.vertices[3].y + (transform.localScale.y / 2), render.vertices[3].z + (transform.localScale.z / 2)));
            boundingBox[4] = (transform.rotation * new Vector3(render.vertices[4].x + (transform.localScale.x / 2), render.vertices[4].y + (transform.localScale.y / 2), render.vertices[4].z - (transform.localScale.z / 2)));
            boundingBox[5] = (transform.rotation * new Vector3(render.vertices[5].x + (transform.localScale.x / 2), render.vertices[5].y + (transform.localScale.y / 2), render.vertices[5].z + (transform.localScale.z / 2)));
            boundingBox[6] = (transform.rotation * new Vector3(render.vertices[6].x + (transform.localScale.x / 2), render.vertices[6].y - (transform.localScale.y / 2), render.vertices[6].z - (transform.localScale.z / 2)));
            boundingBox[7] = (transform.rotation * new Vector3(render.vertices[7].x + (transform.localScale.x / 2), render.vertices[7].y - (transform.localScale.y / 2), render.vertices[7].z + (transform.localScale.z / 2)));
        }
        else
            Debug.Log("fuck");
    }
    void OnDrawGizmosSelected()
    {
        if (boundingBox != null)
        {
            for (int i = 0; i < boundingBox.Count; i++)
            {
                if (render != null)
                    Gizmos.DrawSphere(render.vertices[i], 0.2f);
            }
        }
    }
    public List<Vector3> GetBoundingBox()
    {
        return boundingBox;
    }
}
