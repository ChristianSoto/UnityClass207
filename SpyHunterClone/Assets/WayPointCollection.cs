using UnityEngine;
using System.Collections;

public class WayPointCollection : MonoBehaviour {
		ArrayList WayPointList = new ArrayList();		

	// Use this for initialization
	void Start () {
		int cnt = 1;
		ArrayList wPointList = new ArrayList();
		WayPoint wPoint = new WayPoint();
		bool LoadingChildren = true;	
		float distance;
		float dist2;
		
		// Create a list of waypoints.
		foreach (WayPoint wPoint2 in GetComponentsInChildren<WayPoint>())
			{
				wPointList.Add (wPoint2);
				wPoint.Number = wPointList.Count;				
			}
		
		distance = float.MaxValue;
		// Walk all of the waypoints
		WayPoint wpStart = new WayPoint();
		wpStart.Position = new Vector3(295, 102, 282); // starting point 		
		for (int i = 0; i <= this.GetComponentsInChildren<WayPoint>().Length - 1; i++)				
		{						
			int loc = 0;			
			//Debug.Log("------------- ITERATION " + i + " -----------------");
			// Walks the waypoints in the list.
			for (int i2 = 0; i2 <= wPointList.Count - 1; i2++)			
			{
				dist2 = Vector3.Distance(wpStart.Position, (wPointList[i2] as WayPoint).Position);				
				
				if (dist2 <= distance)
				{						
					wPoint = wPointList[i2] as WayPoint;										
					distance = Vector3.Distance(wpStart.Position, (wPointList[i2] as WayPoint).Position);
					loc = i2;
					//Debug.Log ("wPoint = " + wPoint.name);
				}			
			}			
			
			//Debug.Log ("Removing waypoint " + (wPointList[loc] as WayPoint).name );
			distance = float.MaxValue;
			wPointList.RemoveAt (loc);			
			wPoint.Number = cnt;
			cnt++;		
			//Debug.Log ("Adding waypoint " + wPoint.name);
			WayPointList.Add (wPoint);	
			wpStart = wPoint;
			
		}		
		
		
		foreach (WayPoint wp in WayPointList)
		{
			Debug.Log (wp.Number);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public WayPoint GetNearestWayPoint(Vector3 position, ArrayList wpl)
	{
		WayPoint wp = new WayPoint();
		float distance = float.MaxValue;
		foreach (WayPoint wPoint in WayPointList)
		{
			if (!wpl.Contains (wPoint))
			{
				if (Vector3.Distance (wPoint.Position, position) <= distance)
				{
					wp = wPoint;
					distance = Vector3.Distance (wPoint.Position, position);
				}
			}
		}
		
		return wp;
	}
	
	public WayPoint GetNextWaypoint(WayPoint wp)
	{
		if (WayPointList.Count == 0)
			return new WayPoint();
		
		int num = wp.Number + 1;
		if ((num) > WayPointList.Count -1)
		{
			return WayPointList[WayPointList.Count] as WayPoint;
		}
		
		return (WayPointList[num] ) as WayPoint;
	}
	
}
