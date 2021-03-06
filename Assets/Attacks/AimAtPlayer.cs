﻿using UnityEngine;
using System.Collections;

public class AimAtPlayer: MonoBehaviour 
{
	
	GameObject parent;
    
	GameObject playerObject;
	Orbit parentOrbit;
	public bool showLine=false;
	
	public int maxFrames=250;
	int frameCount = 0;
	
	public bool predictPosition=true;
	// Use this for initialization
	void Start () 
	{
		//playerObject = GameObject.Find("Player");
		//parent=this.GetComponent<AttachGun>().parent;
		//parentOrbit=parent.GetComponent<Orbit>();    
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerObject == null) 
		{
			playerObject = GameObject.Find("Player");
			if (playerObject == null) 
			{
				return;
			}
		}

		if (!playerObject.activeSelf)
			return;
			
		transform.LookAt(playerObject.transform, new Vector3(0,1,0));

		Vector3 direction = playerObject.transform.position - this.transform.position;
		direction.Normalize();
		
		if (frameCount == maxFrames) 
		{
			if (predictPosition)
			{
			
				direction = (playerObject.GetComponent<Orbit>().TargetPositions[10]) - this.transform.position;
				direction.Normalize();

				/*if(GameObject.Find("Player") != null)
				{
					Orbit playerOrbit=playerObject.GetComponent<Orbit>();
					Vector3 playerPos, PlayerVel;
					playerPos=playerObject.transform.position;
					PlayerVel=playerObject.rigidbody.velocity;
					int i;
					for (i=0;i<20; i++)
					{
						//Vector3[] newPosandVel=playerOrbit.getNextPosAndVel(playerPos,PlayerVel);
						//Vector3 newPosandVel = ;
						playerPos=Vector3.zero;
						PlayerVel=Vector3.zero;			
					}
					
					direction = (playerPos) - this.transform.position;
					direction.Normalize();
				}*/

			}
			this.GetComponent<Attack>().shoot (direction);
			frameCount = 0;
		} 
		else 
		{
			frameCount++;
			
		}
	}
}
