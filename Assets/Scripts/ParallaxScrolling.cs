using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {

	public float speed;
	public Camera cam;
	public bool syncWithPlayer;

	private float returnPoint;
	private float initX, initY;
	private float cloneX, cloneY;
	private Vector2 tmp;
	private Sprite sprite;
	private float leftEdge;
	public void Awake()
	{
		sprite = GetComponent<SpriteRenderer> ().sprite;
	}

	public void Start()
	{
		//nDirection = direction.normalized;
		cam = Camera.main;
		leftEdge = cam.ScreenToWorldPoint (Vector2.zero).x;
		returnPoint = leftEdge-sprite.bounds.size.x/2;

		tmp = Vector2.zero;


		initX = cam.ScreenToWorldPoint(Vector2.zero).x;
		initY = transform.position.y;
		tmp.Set (initX, initY);
		transform.position = tmp;

	}

	public void Update()
	{
		if (syncWithPlayer && MainComponent.player.isDead)
			return;
		tmp.Set (returnPoint, initY);
		transform.position= Vector2.MoveTowards(transform.position, tmp, speed*Time.deltaTime);
		if (transform.position.x<=returnPoint)
		{
			tmp.Set(initX, initY);
			transform.position=tmp;
		}
	}


}














































