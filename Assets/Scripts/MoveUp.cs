using UnityEngine;
using System.Collections;

public class MoveUp : MonoBehaviour {


    #region Private Fields
    [SerializeField]    float speed;
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
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
	}
	#endregion

	#region Events
	
	#endregion
	
	//Methods
	

}
