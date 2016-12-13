using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {
	
	public float speed;
	private float alpha;
	//private Color c;
	private Image img;
	public void Start()
	{
		enabled = false;
		img = GetComponent<Image> ();
	}
	
	public void Update()
	{
		if (img.color.a==1)
		{
			enabled=false;
			
		}
		else
		{
			img.color=new Color(img.color.r,img.color.g, img.color.b, alpha);
			alpha+=speed;
			if (alpha>1)
				alpha=1;
		}
	}
	
	public void Fade()
	{
		enabled = true;
		alpha = 0;
	}
}