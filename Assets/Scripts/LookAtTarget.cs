using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {


    #region Private Fields
    [SerializeField]    float rotationSpeed;
    [SerializeField]    Transform target;
    [SerializeField]    bool debug = false;
    [SerializeField]    Color debugColor;
    #endregion

    //Properties

    #region Unity Methods

    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }



	// Update is called once per frame
	void Update () 
	{
        if (target)
        {
            Vector2 diff = target.position - transform.position;
            diff.Normalize();
            float totalRotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.z = Mathf.LerpAngle(rotation.z, totalRotation, Time.deltaTime * rotationSpeed);
            transform.eulerAngles = rotation;
            if (debug)
            {
                Debug.DrawLine(transform.position, target.position, debugColor);
            }
        }

    }
	#endregion


}
