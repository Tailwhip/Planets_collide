using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Vector3 delta;
    public float movingSpeed=200f;
    Vector3 startPosition;

	// Use this for initialization
	void Start ()
    {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float velocity = movingSpeed / delta.sqrMagnitude;
        float change = (Mathf.Sin(Time.timeSinceLevelLoad*velocity)+1f)/2;

        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        rigidbody.position = Vector3.Lerp(startPosition, startPosition + delta, change);
	}


#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        if(UnityEditor.Selection.activeTransform == transform)
        {
            Gizmos.color = Color.yellow;
        }

        Vector3 ghostPosition = transform.position + delta;
        Vector3 ghostSize = transform.rotation * transform.localScale * 1f;
        Gizmos.DrawWireCube(ghostPosition, ghostSize);
    }
#endif
}
