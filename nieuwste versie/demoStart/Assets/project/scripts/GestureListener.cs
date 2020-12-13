using UnityEngine;
using System.Collections;
using System;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public UnityEngine.UI.Text GestureInfo;
	
	private bool jump;
	private bool swipeRight;
    private bool swipeLeft;
    private bool push;
    private bool tpose;
    public float user;

    public bool IsPush()
    {
        if (push)
        {
            push = false;
            return true;
        }

        return false;
    }

    public bool IsTpose()
    {
        if (tpose)
        {
            tpose = false;
            return true;
        }

        return false;
    }

    public bool IsJump()
	{
		if(jump)
		{
			jump = false;
			return true;
		}
		
		return false;
	}
	
	public bool IsSwipeRight()
	{
		if(swipeRight)
		{
			swipeRight = false;
			return true;
		}
		
		return false;
	}

    public bool IsSwipeLeft()
    {
        if (swipeLeft)
        {
            swipeLeft = false;
            return true;
        }

        return false;
    }


    public void UserDetected(uint userId, int userIndex)
	{
		// detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

        manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
        manager.DetectGesture(userId, KinectGestures.Gestures.Push);
        manager.DetectGesture(userId, KinectGestures.Gestures.Squat);
        manager.DetectGesture(userId, KinectGestures.Gestures.Tpose);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);

		if(GestureInfo != null)
		{
			GestureInfo.text = "Swipe left or right to change the slides.";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		// don't do anything here
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		if(GestureInfo != null)
		{
			GestureInfo.text = sGestureText;
		}

        //Debug.Log(userId); // altijd random nummers
        //Debug.Log(userIndex); // altijd 1 of 0
        user = userIndex;

        if (gesture == KinectGestures.Gestures.Push) //SwipeLeft
            push = true;
        else if(gesture == KinectGestures.Gestures.Jump) //SwipeLeft
			jump = true; 
		else if(gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;
        else if (gesture == KinectGestures.Gestures.SwipeLeft)
            swipeLeft = true;
        else if (gesture == KinectGestures.Gestures.Tpose)
            tpose = true;

        return true;

	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		// don't do anything here, just reset the gesture state
		return true;
	}
	
}
