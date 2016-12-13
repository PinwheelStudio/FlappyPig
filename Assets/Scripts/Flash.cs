using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flash : MonoBehaviour {

	private Image img;
	private bool flashing = false;
	public byte flashSpeed;
	private byte alpha;

	public void Awake()
	{
		img = GetComponent<Image> ();
		alpha = 0;
	}

	public void Update()
	{
		if (flashing)
		{
			alpha-=flashSpeed;
			if (alpha<=0)
				alpha=0;
			img.color=new Color(img.color.r, img.color.g, img.color.b, 1.0f*alpha/255);

			if (alpha==0)
				flashing=false;
		}
	}

	public void FlashOnce()
	{
		alpha = 255;
		flashing=true;
	}



}
