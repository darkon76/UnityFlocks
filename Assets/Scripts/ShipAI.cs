using UnityEngine;
using System.Collections;

public class ShipAI : MonoBehaviour {


    #region Private Fields
    GameObject radar;
    ShipMovement shipMovement;
    Ship ship;
    CircleCollider2D detectionRange;
	#endregion
	
	//Properties
	
	#region Unity Methods
	void Awake()
	{
        ship = GetComponent<Ship>();
	}
	
	void OnEnable()
	{
	}
	
	void OnDisable()
	{
	}
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
        shipMovement.Move(Vector3.up);
	}
	#endregion

	#region Events
	
	#endregion
	
	//Methods
	

}
