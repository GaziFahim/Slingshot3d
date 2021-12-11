using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
	public static Swipe instance;

	[SerializeField] protected Ball ballPrefab;         
	[SerializeField] protected Trajectory trajectory;   
	[SerializeField] protected float pushForce;         
	[SerializeField] protected float maxForce;         
	[SerializeField] [Range(0f, 10f)] protected float zMultiplier;

	public Transform startfrom;
	public Transform startfromsling;
	public Transform startfromslinglast;
	
	private Vector3 mouse;
	private Vector2 startPos, endPos;
	
	private Vector3 forcevector;      
	private Ball ball;
	public bool isActive = false;

	public Slingshot slingshotString;
	private float dist;
	private bool dragging = false;
	private Vector3 offset;
	private Transform todrag;
	Vector3 v3;
	private void Awake()
    {
		instance = this;
    }
    private void Start()
	{
		
		Spawn();
	}

	private void Update()
	{
		
		ControlSwipe(); 

		float mouseRatioX = Input.mousePosition.x / Screen.width;
		float mouseRatioY = Input.mousePosition.y / Screen.height;
		mouse = new Vector3(mouseRatioX - 0.5f, mouseRatioY - 0.5f, 0f);

		Debug.Log(mouse);
		
		
	}

	private void ControlSwipe()
	{
		

			if (Input.GetMouseButtonDown(0))
			{

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ball")
                {



                    isActive = true;
                    Debug.Log(hit.transform.tag);

             



                    todrag = hit.transform;

                    dist = hit.transform.position.z - Camera.main.transform.position.z;

                    v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = todrag.position - v3;
                    dragging = true;

					//startfromsling = hit.transform;
					slingshotString.CenterPoint = todrag;
					trajectory.Show();

					startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				}



            }
            
			

		}


	   else	if (Input.GetMouseButton(0) && isActive == true)
		{

			if (isActive)
			{
				endPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);


				Vector3 direction = (startPos - endPos).normalized;
				float distance = Vector2.Distance(startPos, endPos);


                if (dragging)
                {
                    v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    todrag.position = v3 + offset;
                  
                }

                forcevector = direction * distance * pushForce;
				forcevector.z = forcevector.y * zMultiplier;
				forcevector = Vector3.ClampMagnitude(forcevector, maxForce);



				trajectory.UpdateDots(transform.position, forcevector);


			}
		  }

		    else	if (Input.GetMouseButtonUp(0) && isActive == true)
	     {

			if (isActive)
			{



				
				if (startPos.y > endPos.y)
				{
					if (ball)
					{

						ball.Push(forcevector);
						ball = null;

						Slingshot.instnce.CenterPoint = startfromsling;
						Invoke("Spawn", 0.5f);

					}
					
				}



				else
				{
					Ball.instance._rb.isKinematic = false;
					Invoke("Spawn", 0.5f);
				}
			}
           

            trajectory.Hide();
					StartCoroutine(Ball.instance.destroyobject());


				
			}
		
	}
	
	public void Spawn()
	{
        ball = Instantiate(ballPrefab, startfrom.position, Quaternion.identity);
        isActive = false;
    }



}
