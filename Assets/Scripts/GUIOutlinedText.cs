using UnityEngine;

public class GUIOutlinedText : MonoBehaviour {
	GUIText main;
	GUIText[] outline = new GUIText[4];

	public GUIOutlinedText(string name){
		GameObject mainTextObject = new GameObject(name);
		mainTextObject.transform.position = new Vector3(0.5f,0.5f,0f);
		main = (GUIText)mainTextObject.AddComponent(typeof(GUIText));
		GameObject[] outlineTextObjects = new GameObject[4];
		for(int i = 0; i < 4; i ++){
			outlineTextObjects[i] = new GameObject(name+"_outline");
			outlineTextObjects[i].transform.parent = mainTextObject.transform;
			outlineTextObjects[i].transform.position = new Vector3(0.5f,0.5f,-0.001f);
			outline[i] = (GUIText)outlineTextObjects[i].AddComponent(typeof(GUIText));
			outline[i].color = Color.black;
		}
	}

	public bool enabled 
	{
		get{
			return main.enabled;
		}
		
		set{
			main.enabled = value;
			for(int i = 0; i < 4; i ++){
				outline[i].enabled = value;
			}
		}
	}

	public TextAlignment alignment
	{
		get{
			return main.alignment;
		}

		set{
			main.alignment = value;
			for(int i = 0; i < 4; i ++){
				outline[i].alignment = value;
			}
		}
	}
	
	public TextAnchor anchor
	{
		get{
			return main.anchor;
		}
		
		set{
			main.anchor = value;
			for(int i = 0; i < 4; i ++){
				outline[i].anchor = value;
			}
		}
	}
	
	public Color color
	{
		get
		{
			return main.color;
		}
		set
		{
			main.color = value;
		}
	}
	
	public Color outlineColor
	{
		get
		{
			return outline[0].color;
		}
		set
		{
			for(int i = 0; i < 4; i ++){
				outline[i].color = value;
			}
		}
	}
	
	public Font font
	{
		get{
			return main.font;
		}
		
		set{
			main.font = value;
			for(int i = 0; i < 4; i ++){
				outline[i].font = value;
			}
		}
	}
	
	public int fontSize
	{
		get{
			return main.fontSize;
		}
		
		set{
			main.fontSize = value;
			for(int i = 0; i < 4; i ++){
				outline[i].fontSize = value;
			}
		}
	}
	
	public FontStyle fontStyle
	{
		get{
			return main.fontStyle;
		}
		
		set{
			main.fontStyle = value;
			for(int i = 0; i < 4; i ++){
				outline[i].fontStyle = value;
			}
		}
	}
	
	public float lineSpacing
	{
		get{
			return main.lineSpacing;
		}
		
		set{
			main.lineSpacing = value;
			for(int i = 0; i < 4; i ++){
				outline[i].lineSpacing = value;
			}
		}
	}
	
	public Material material
	{
		get{
			return main.material;
		}
		
		set{
			main.material = value;
		}
	}
	
	public Material outlineMaterial
	{
		get{
			return outline[0].material;
		}
		
		set{
			for(int i = 0; i < 4; i ++){
				outline[i].material = value;
			}
		}
	}
	
	public Vector2 pixelOffset
	{
		get{
			return main.pixelOffset;
		}
		
		set{
			main.pixelOffset = value;
			outline[0].pixelOffset = value + new Vector2(0f, 1f);
			outline[1].pixelOffset = value + new Vector2(1f, 0f);
			outline[2].pixelOffset = value + new Vector2(0f, -1f);
			outline[3].pixelOffset = value + new Vector2(-1f, 0f);
		}
	}
	
	public bool richText
	{
		get{
			return main.richText;
		}
		
		set{
			main.richText = value;
			for(int i = 0; i < 4; i ++){
				outline[i].richText = value;
			}
		}
	}
	
	public float tabSize
	{
		get{
			return main.tabSize;
		}
		
		set{
			main.tabSize = value;
			for(int i = 0; i < 4; i ++){
				outline[i].tabSize = value;
			}
		}
	}
	
	public string text
	{
		get{
			return main.text;
		}
		
		set{
			main.text = value;
			for(int i = 0; i < 4; i ++){
				outline[i].text = value;
			}
		}
	}

}
