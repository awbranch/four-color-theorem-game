
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Linq.Enumerable;

public class LevelLoader : MonoBehaviour
{
    public Material mat;
    public TextAsset level;
    float width = 1;
    float height = 1;

    [System.Serializable] //put this in front of each class
    public class Shape  // define the idea of a shape
    {
        public int id;
        public int x;
        public int y;
        public int w;
        public int h;
        public string color;
        public int[] touches;

    }

    [System.Serializable]
    public class ShapeList // define the idea of a list of shapes
    {
        public Shape[] shapes;
    }


    public ShapeList shapelist = new ShapeList();  // create an instance to work with



    // Start is called before the first frame update
    void Start()
    {
        shapelist = JsonUtility.FromJson<ShapeList>(level.text); // run this on th instance to read the json file in
        Mesh[] meshList = new Mesh[shapelist.shapes.Length];


        for (int i = 0; i < shapelist.shapes.Length; i++)
        {
            Debug.Log("sdgfsdfhgdf");
            //Console.WriteLine(i);
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
            // mesh.name = "1234";

            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            // meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();


            meshFilter.mesh = mesh;
            mesh.RecalculateNormals();
            meshList[i] = mesh;
        }




    }

    // Update is called once per frame
    void Update()
    {

    }
}
