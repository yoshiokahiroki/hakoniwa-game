/*!************************************************
*
*	@file	CreatePanel.cs
*	@brief	上向きの2ポリゴンのパネルを作成
*	@auther	神田 美月(d.hatena.ne.jp/nakamura001様より)
*
***************************************************/
//!< Assets内のEditorフォルダから動かさないでください！
//!< パネルを生成するとAssets内にassetファイルが自動で保存されます
using UnityEditor;
using UnityEngine;
using System.Collections;

public class CreatePanel : MonoBehaviour
{
	/*!************************************************
	*
	*	@brief	パネル生成【ツールバーCreate ObjectからPanelを選択】
	*	@param	なし
	*	@return なし
	*
	***************************************************/
	[MenuItem ("GameObject/Create Other/Panel")]
	static void Create ()
	{
		GameObject newGameobject = new GameObject ("CustomPanel");
		
		MeshRenderer meshRenderer = newGameobject.AddComponent<MeshRenderer> ();
		meshRenderer.material = new Material (Shader.Find ("Diffuse"));
		
		MeshFilter meshFilter = newGameobject.AddComponent<MeshFilter> ();
		
		meshFilter.mesh = new Mesh ();
		Mesh mesh = meshFilter.sharedMesh;
		mesh.name = "CustomPanel";
		
		mesh.vertices = new Vector3[]{
			new Vector3 ( -0.5f , 0.0f ,  0.5f ) ,
			new Vector3 (  0.5f , 0.0f ,  0.5f ) ,
			new Vector3 (  0.5f , 0.0f , -0.5f ) ,
			new Vector3 ( -0.5f , 0.0f , -0.5f )
		};
		mesh.triangles = new int[]{
			0, 1, 2,
			2, 3, 0
		};
		mesh.uv = new Vector2[]{
			new Vector2 (0.0f, 1.0f),
			new Vector2 (1.0f, 1.0f),
			new Vector2 (1.0f, 0.0f),
			new Vector2 (0.0f, 0.0f)
		};
		
		mesh.RecalculateNormals ();	// 法線の再計算
		mesh.RecalculateBounds ();	// バウンディングボリュームの再計算
		mesh.Optimize ();
		
		AssetDatabase.CreateAsset (mesh, "Assets/" + mesh.name + ".asset");
		AssetDatabase.SaveAssets ();
	}
}