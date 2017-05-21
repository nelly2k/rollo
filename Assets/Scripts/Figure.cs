using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{

    public Vector3 CurrentTarget;
    public float Speed;

    public Action<Figure> TargetAchieved;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (CurrentTarget == null)
	    {
	        return;
        }
        
        var step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, step);

	    if (transform.position == CurrentTarget && TargetAchieved!=null)
	    {
	        TargetAchieved.Invoke(this);
        }
    }


}
