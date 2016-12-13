using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeight;
	public float gravity;
	public AudioSource jumpSound;
	public AudioSource hitSound;
	public AudioSource fallSound;
	public AudioSource scoreSound;
	public Flash flash;

	private float initX, initY;

	[System.NonSerialized]
	public bool isPlaying=false, isDead=false;
	private Vector2 tmp;
	private float dy;

	private Animator anim;
	private CircleCollider2D col;
	public void Awake()
	{
		anim = GetComponent<Animator> ();
		col = GetComponent<CircleCollider2D> ();
	}

	public void Start()
	{
		tmp = transform.position;
		initX = tmp.x;
		initY = tmp.y;
	}

	public void Update()
	{
		if (isPlaying)
		{
			dy-=gravity;
			tmp.Set(transform.position.x, transform.position.y+dy*Time.deltaTime);
			transform.position=tmp;
		}
		if (Input.touchCount>0 || Input.GetButtonDown("Fire1"))
		{
			if (!isPlaying)
			{
				isPlaying=true;
				MainComponent.logoFadeOut.Fade();
			}
			else if (isPlaying && !isDead)
				Jump();
			else if (isDead)
				Respawn();
		}
		Input.ResetInputAxes ();

	}

	public void Jump()
	{
		dy = jumpHeight;
		jumpSound.Play ();
	}

	public void Die()
	{
		isDead = true;
		anim.SetBool ("Die", true);
		hitSound.Play ();
		fallSound.PlayDelayed (0.4f);
		//Debug.LogError ("Die");
	}

	public void Respawn()
	{
		tmp.Set (initX, initY);
		transform.position=tmp;
		isPlaying=false;
		isDead=false;
		dy = 0;
		anim.SetBool ("Die", false);
		col.enabled = true;

		foreach (ObstacleController ob in MainComponent.obstacle)
			ob.Init();

		MainComponent.score.Reset ();
		MainComponent.logoFadeIn.Fade ();
	}

	public void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag=="Scorer")
		{
			MainComponent.score.Add();
			scoreSound.Play();
		}
		else
		{
		col.enabled = false;
		flash.FlashOnce ();
		Jump ();
		Die ();
		}
	}

}
