using UnityEngine;


/**
 * This Script makes an object very similar to a GUITexure, except that it can be rotated
 */
[ExecuteInEditMode()]
public class RotatableGuiItem : MonoBehaviour {
	public Camera cameraToRenderTo;
	public Texture2D texture = null;
	public float angle = 0;
	public Vector2 size = new Vector2(128, 128);
	Vector2 pos = new Vector2(0, 0);
	Rect rect;
	Vector2 pivot;
	public Color color;
	
	void Start() {
		UpdateSettings();
	}
	/**
	 * Updates the settings
	 */
	public void publicUpdateSettings(){
		UpdateSettings ();
	}

	void UpdateSettings() {
		pos = new Vector2(transform.position.x*Screen.width, transform.position.y*Screen.height);
		rect = new Rect(pos.x - size.x * 0.5f, pos.y - size.y * 0.5f, size.x, size.y);
		pivot = new Vector2(rect.xMin + rect.width * 0.5f, rect.yMin + rect.height * 0.5f);
//		render();
	}
	public void render(){
//		Debug.Log(Camera.current);
//		if(cameraToRenderTo!=null && Camera.current!=cameraToRenderTo)return;
		Matrix4x4 matrixBackup = GUI.matrix;
		Color restore = GUI.color;
		GUI.color = color;
		GUIUtility.RotateAroundPivot(angle, pivot);
		GUI.DrawTexture(rect, texture);
		GUI.matrix = matrixBackup;
		GUI.color = restore;
	}
	
	void OnGUI() {
		if (Application.isEditor) { UpdateSettings();}

	}
}
