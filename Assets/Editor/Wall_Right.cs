using UnityEditor;//Edit
using UnityEngine;
using System.Collections;

public class Wall_Right : MonoBehaviour {

	[MenuItem("GameObject/Create Other/Wall_Right")]
	// Use this for initialization
	static void Create ()
	{
		GameObject obj = new GameObject("Wall_Right");
		MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
		meshRenderer.material = new Material (Shader.Find ("Diffuse"));
		
		MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
		
		meshFilter.mesh = new Mesh ();
		Mesh m = meshFilter.sharedMesh;
		m.name = "Wall_Right";
		
		Vector3[] vertices = new Vector3[]
		{
			//Zgata
			/*new Vector3(-0.5f,  0.0f, 0.0f),
			new Vector3( 0.5f,  0.6f, 0.0f),
			new Vector3(-0.5f, -0.6f, 0.0f),
			new Vector3( 0.5f,  0.0f, 0.0f)
			*/
			
			//GyakuZgata

			new Vector3(-0.25f,  0.0f, 0.0f),
			new Vector3( 0.25f, -0.3f, 0.0f),
			new Vector3(-0.25f,  0.3f, 0.0f),
			new Vector3( 0.25f,  0.0f, 0.0f),
						
		};
		int[] triangles = new int[]
		{
			//Zgata
			/*0, 1, 2,
			3, 2, 1*/
			
			//GyakuZgata
			0,2,1,
			2,3,1
		};
		Vector2[] uv = new Vector2[]
		{
			//Z
			/*new Vector2 (1.0f, 1.0f),
			new Vector2 (1.0f, 0.0f),
			new Vector2 (0.0f, 1.0f),
			new Vector2 (0.0f, 0.0f)*/
			
			//GyakuZ
			new Vector2 (0.0f, 0.0f),
			new Vector2 (1.0f, 0.0f),
			new Vector2 (0.0f, 1.0f),
			new Vector2 (1.0f, 1.0f),
			
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
