using UnityEditor;//Edit
using UnityEngine;
using System.Collections;

public class FieldQuad : MonoBehaviour {
	
	[MenuItem("GameObject/Create Other/FieldQuad")]
	// Use this for initialization
	
	static void Create ()
	{
		GameObject obj = new GameObject("FieldQuad");
		MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
		meshRenderer.material = new Material (Shader.Find ("Diffuse"));
		
		MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
		
		meshFilter.mesh = new Mesh ();
		Mesh m = meshFilter.sharedMesh;
		m.name = "FieldQuad";
				
		Vector3[] vertices = new Vector3[]
		{
			new Vector3( 0.0f,  0.3f, 0.0f),
			new Vector3( 0.5f,  0.0f, 0.0f),
			new Vector3(-0.5f,  0.0f, 0.0f),
			new Vector3( 0.0f, -0.3f, 0.0f)
		};
		int[] triangles = new int[]
		{
			0, 1, 2,
			3, 2, 1
		};
		Vector2[] uv = new Vector2[]
		{
			new Vector2 (1.0f, 1.0f),
			new Vector2 (1.0f, 0.0f),
			new Vector2 (0.0f, 1.0f),
			new Vector2 (0.0f, 0.0f),
		};

		m.vertices = vertices;
		m.triangles = triangles;
		m.uv = uv;
		m.RecalculateNormals();
		m.RecalculateBounds ();
		m.Optimize();
		
		AssetDatabase.CreateAsset (m, "Assets/" + m.name + ".asset");
		AssetDatabase.SaveAssets();
				
	}
	
}

