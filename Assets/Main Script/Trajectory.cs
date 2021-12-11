using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
	[SerializeField] protected Transform dotsParent;   
	[SerializeField] protected Transform dotPrefab;    
     
	[SerializeField] protected int dotsNumber;        
	[SerializeField] protected float dotSpacing;
	[SerializeField] [Range(0.01f, 0.5f)] protected float dotMinScale;
	[SerializeField] [Range(0.50f, 1.0f)] protected float dotMaxScale;

	private Transform[] _dotsList;      


	private void Start()
	{
		
		Hide();
		
		PrepareDots();
	}

	
	private void PrepareDots()
	{
		_dotsList = new Transform[dotsNumber];
		dotPrefab.localScale = Vector3.one * dotMaxScale;

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++)
		{
			_dotsList[i] = Instantiate(dotPrefab, null);
			_dotsList[i].parent = dotsParent.transform;
			_dotsList[i].gameObject.SetActive(true);

			_dotsList[i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
			{
				scale -= scaleFactor;
			}
		}
	}

	
	public void UpdateDots(Vector3 ballPos, Vector3 forceApplied)
	{
		float timeStamp = dotSpacing;
		bool hideDot = false;
		foreach (Transform dot in _dotsList)
		{
			Vector3 dotPos;
			
			dotPos.x = (ballPos.x + forceApplied.x * timeStamp);
			dotPos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics.gravity.magnitude * timeStamp * timeStamp) / 2f;
			dotPos.z = (ballPos.z + forceApplied.z * timeStamp);

			
			dot.position = dotPos;
			dot.LookAt(Camera.main.transform);
		
			if (!hideDot && CheckGround(dotPos))
			{
				hideDot = true;
			}
			dot.gameObject.SetActive(!hideDot);

		
			timeStamp += dotSpacing;
		}

	}

	
	private bool CheckGround(Vector3 sphereCenter)
	{
		Collider[] coll = Physics.OverlapSphere(sphereCenter, 1f);
		if (coll.Length > 0 && coll[0].transform.tag == "Ground")
		{
			
			Vector3 pos = sphereCenter;
			pos.y = coll[0].transform.position.y + coll[0].bounds.size.y / 2 + 0.01f;
	
			return true;
		}
		return false;
	}

	public void Show()
	{
		dotsParent.gameObject.SetActive(true);
	}

	public void Hide()
	{
		dotsParent.gameObject.SetActive(false);
	}
}