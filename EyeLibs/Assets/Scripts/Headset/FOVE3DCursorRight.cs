using UnityEngine;
using System.Collections;

public class FOVE3DCursorRight : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}

    // Latepdate ensures that the object doesn't lag behind the user's head motion
    void Update() {
        FoveInterface.EyeRays rays = FoveInterface.GetEyeRays();

        // TODO: calculate the convergence point in FoveInterface

        // Just hack in to use the right eye for now...
        RaycastHit hit;
        Physics.Raycast(rays.right, out hit, Mathf.Infinity);
        if (hit.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
        {
            transform.position = hit.point;
        }
        else
        {
            transform.position = rays.right.GetPoint(3.0f);
        }
	}
}
