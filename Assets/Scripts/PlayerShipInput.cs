using UnityEngine;
using System.Collections;

public class PlayerShipInput : MonoBehaviour {


    #region Private Fields
    [SerializeField]    float turnSpeed;
	#endregion
	
	//Properties
	
	#region Unity Methods
	void Awake()
	{
	}

	// Update is called once per frame
	void Update () 
	{
      //  float input = 

        transform.Rotate(Vector3.forward * -Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
	}
	#endregion

	#region Events
	
	#endregion
	
	//Methods
	

}
