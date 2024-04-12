using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=kMr2HiU7DlE
public class ProcGen : MonoBehaviour
{
    private MeshFilter mf;

    public int sizeX = 3;
    public int sizeY = 3;

    private void Awake()
    {
        TryGetComponent(out mf);
    }

    private void Start()
    {
        if (mf)
        {
            Plane plane = new Plane(mf.mesh, sizeX, sizeY);
        }
    }
}


public abstract class ProceduralShape
{
    protected Mesh mesh_;
    protected Vector3[] vertices;
    protected int[] triangles;
    protected Vector2[] uvs;

    public ProceduralShape(Mesh mesh)
    {
        mesh_ = mesh;
    }
}

public class Plane : ProceduralShape
{
    private int sizeX_, sizeY_;

    public Plane(Mesh mesh, int sizeX, int sizeY) : base(mesh)
    {
        sizeX_ = sizeX;
        sizeY_ = sizeY;
        CreateMesh();
    }

    private void CreateMesh()
    {
        CreateVertices();
        CreateTriangles();
        CreateUVs();

        mesh_.vertices = vertices;
        mesh_.triangles = triangles;
        mesh_.uv = uvs;

        mesh_.RecalculateNormals();
    }
    private void CreateVertices()
    {
        vertices = new Vector3[sizeX_ * sizeY_];
        for (int y = 0; y < sizeY_; y++)
        {
            for (int x = 0; x < sizeX_; x++)
            {
                vertices[x + y * sizeX_] = new Vector3(x, 0.0f, y);
            }
        }
    }
    private void CreateTriangles()
    {
        triangles = new int[3 * 2 * (sizeX_ * sizeY_ - sizeX_ - sizeY_ + 1)];
        int triangleVertexCount = 0;
        for (int vertex = 0; vertex < sizeX_ * sizeY_ - sizeX_; vertex++)
        {
            if (vertex % sizeX_ != (sizeX_ - 1))
            {
                // First triangle
                int A = vertex;
                int B = A + sizeX_;
                int C = B + 1;
                triangles[triangleVertexCount] = A;
                triangles[triangleVertexCount + 1] = B;
                triangles[triangleVertexCount + 2] = C;
                //Second triangle
                B += 1;
                C = A + 1;
                triangles[triangleVertexCount + 3] = A;
                triangles[triangleVertexCount + 4] = B;
                triangles[triangleVertexCount + 5] = C;
                triangleVertexCount += 6;
            }
        }

    }
    private void CreateUVs()
    {
        uvs = new Vector2[sizeX_ * sizeY_];
        int uvIndexCounter = 0;
        foreach (Vector3 vertex in vertices)
        {
            uvs[uvIndexCounter] = new Vector2(vertex.x, vertex.z);
            uvIndexCounter++;
        }
    }
}