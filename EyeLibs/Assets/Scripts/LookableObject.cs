using UnityEngine;
using System.Collections;

public class LookableObject : MonoBehaviour {

	Collider my_collider;
    private Material m;

	private int viewCount = 0;

    // Use this for initialization
    void Start() {
        my_collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (FoveInterface.IsEyeTrackingCalibrated() && FoveInterface.IsLookingAtCollider(my_collider))
        {
			viewCount++;
			//Debug.Log ("Looking at " + this.name);
        }
	}

	public int getViewCount() {
		return viewCount;
	}

	public void resetViews() {
		viewCount = 0;
	}
}
