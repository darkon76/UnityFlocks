using UnityEngine;
using System.Collections;

public class ScreenTeleport : MonoBehaviour {


    #region Private Fields
    [SerializeField]    float horizontalLimit = 5f;
    [SerializeField]    float verticalLimit = 5f;

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
        Vector3 tmpPosition = transform.position;
        tmpPosition.x += horizontalLimit;
        tmpPosition.y += verticalLimit;
        tmpPosition.x %= horizontalLimit;
        tmpPosition.y %= verticalLimit;
        transform.position = tmpPosition;
	}
	#endregion

	#region Events
	
	#endregion
	
	//Methods
	

}
