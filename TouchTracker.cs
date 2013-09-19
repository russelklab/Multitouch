using UnityEngine;
using System.Collections;

public class TouchTracker
{

	public int fingerId;
	public iPhoneTouch touch;
	public bool isDirty = false;
	public float totalTime = 0.0f;
	public iPhoneTouch firstTouch; 

	private GameObject go;
	private Camera camera;

	public TouchTracker (iPhoneTouch touch)
	{
		fingerId = touch.fingerId;
		firstTouch = touch;

		Begin ();
		Update (firstTouch);
	}

	public void Update (iPhoneTouch touch) 
	{ this.touch = touch;
		isDirty = true;

        // do something with the game object
        // go.charmander()
	}

	public void Clean ()
	{
		isDirty = false;
	}

	public void Begin ()
	{
		Debug.Log ("Begin tracking finger " + fingerId);
        
        // load your prefabs here
        // set it as go
	}

	public void End ()
	{
		Debug.Log ("End tracking finger " + fingerId);
		go = null;
        // game related stuff
	}
}
