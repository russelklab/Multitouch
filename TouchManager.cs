using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	private ArrayList trackers = new ArrayList();
	private Hashtable trackerLookup = new Hashtable();

	void Update () 
	{
		foreach (TouchTracker tracker in trackers) {
			tracker.Clean();
		}

		foreach (iPhoneTouch touch in iPhoneInput.touches)
		{
			TouchTracker tracker = trackerLookup[touch.fingerId] as TouchTracker;

			if (tracker != null) {
				tracker.Update(touch);
			} else {
				tracker = BeginTracking(touch);
			}
		}

		ArrayList ended = new ArrayList();
		foreach (TouchTracker tracker in trackers) {
			if (!tracker.isDirty) {
				ended.Add(tracker);
			}
		}

		foreach (TouchTracker tracker in ended) {
			EndTracking(tracker);
		}
	}

	public TouchTracker BeginTracking (iPhoneTouch touch)
	{
		TouchTracker tracker = new TouchTracker(touch);
		trackers.Add(tracker);
		trackerLookup[touch.fingerId] = tracker;

		return tracker;
	}

	void EndTracking (TouchTracker tracker)
	{
		tracker.End();
		trackers.Remove(tracker);
		trackerLookup[tracker.fingerId] = null;
	}
}
