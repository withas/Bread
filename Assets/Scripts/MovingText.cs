using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MovingText : BaseMeshEffect
{
    private float time = 0;

    private float radius = 1.5f;

    public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
    {
        if (!IsActive())
        {
            return;
        }

        List<UIVertex> vertices = new List<UIVertex>();
        vh.GetUIVertexStream(vertices);

        TextMove(ref vertices);

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertices);
    }

    private void TextMove(ref List<UIVertex> vertices)
    {
        for (int c = 0; c < vertices.Count; c += 6)
        {
            float rad = Random.Range(0,360) * Mathf.Deg2Rad;
            Vector3 dir = new Vector3 (radius * Mathf.Cos (rad), radius * Mathf.Sin (rad), 0);

            for(int i = 0; i < 6; i++)
            {
                var vert       = vertices [c+i];
                vert.position  = vert.position + dir;
                vertices [c+i] = vert;
            }
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.05f)
        {
            time = 0;
            base.GetComponent<Graphic>().SetVerticesDirty();
        }
    }
}
