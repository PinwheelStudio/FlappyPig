using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Text text;

	private int score=0;

	public void Start()
	{
		text.text = "0";
	}

	public void Add()
	{
		text.text = (++score).ToString ();
	}
	public void Reset()
	{
		score = 0;
		text.text = "0";
	}
}
