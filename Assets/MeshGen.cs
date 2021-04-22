using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
    public float width = 1;
    public float height = 1;

    public void Start()
    {


        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                Debug.Log("Mouse Down Hit the following object: " + hit.collider.name);
            else
                Debug.Log("Nothing was hit!");
        }














































        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(0, height, 0),
            new Vector3(width, height, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;
        mesh.name = "1234";

        /*
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;
        */

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
       // meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();


        meshFilter.mesh = mesh;
        mesh.RecalculateNormals();
       
    }




}
