using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {


    #region Private Fields
    [SerializeField]    eTeams team;
	#endregion
	
	//Properties
    public eTeams Team
    {
        get { return team; }
    }
	
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
	

}
