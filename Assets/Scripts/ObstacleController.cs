using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public float minOffsetY, maxOffsetY;
	public float speed;
	private float initX, newY;
	private Vector2 tmp;
	private Vector2 des;
	private float desX;
	private float respawnX;
	private Sprite sprite;
	private Camera cam;
	public void Awake()
	{
		sprite = GetComponent<SpriteRenderer> ().sprite;
		cam = Camera.main;
	}

	public void Start()
	{
		initX = transform.position.x;
		respawnX = cam.ScreenToWorldPoint (new Vector2 (2 * cam.pixelWidth, 0)).x - sprite.bounds.size.x;
		newY = Random.Range (minOffsetY, maxOffsetY);
		tmp.Set (transform.position.x, newY);
		transform.position = tmp;

		SetDes ();

	}

	public void Update()
	{
		if (transform.position==(Vector3)des)
			Respawn();
		else 
		{
			if (MainComponent.player.isPlaying && !MainComponent.player.isDead)
				transform.position = Vector2.MoveTowards(transform.position,des,speed*Time.deltaTime);
		}
	}

	public void Respawn()
	{
		newY = Random.Range (minOffsetY, maxOffsetY);
		tmp.Set (respawnX, newY);
		transform.position = tmp;
		SetDes ();
	}

	public void SetDes()
	{
		desX = cam.ScreenToWorldPoint (Vector2.zero).x - sprite.bounds.size.x;
		des.Set (desX, newY);
	}

	public void Init()
	{
		tmp.Set (initX, newY);
		transform.position = tmp;
	}
}
