using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {


    #region Private Fields
    [SerializeField]    float movementSpeed;
    [SerializeField]    float rotationSpeed;
	#endregion
	
	//Properties
	
	#region Unity Methods
	void Awake()
	{
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
	}
	#endregion

	#region Events
	
	#endregion
	
	//Methods
	public void Move(Vector3 direction)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

}
