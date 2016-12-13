using UnityEngine;
using System.Collections;

public class MainComponent : MonoBehaviour {

	public static PlayerController player;
	public static ObstacleController[] obstacle;
	public static ScoreManager score;
	public static FadeOut logoFadeOut;
	public static FadeIn logoFadeIn;
	public void Awake()
	{
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		obstacle = GameObject.FindObjectsOfType(typeof(ObstacleController)) as ObstacleController[];
		score = GetComponent<ScoreManager> ();
		logoFadeOut = GameObject.Find ("Logo").GetComponent<FadeOut>();
		logoFadeIn = GameObject.Find ("Logo").GetComponent<FadeIn>();
	}
}
