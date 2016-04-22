using UnityEngine;
using System.Collections;

public class BoidController : MonoBehaviour {


    #region Private Fields
    [SerializeField, EnumFlag]    BoidAI.Modes mode;

    BoidAI ai;
    #endregion

    //Properties
    BoidAI Ai
    {
        get
        {
            if (ai == null)
            {
                ai = GetComponentInChildren<BoidAI>();
            }
            return ai;
        }
        
    }


    #region Unity Methods
    void Awake()
	{
        //ai = GetComponentInChildren<BoidAI>();
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

    void OnValidate()
    {

        GetComponentInChildren<BoidAI>().SetMode(mode);
    }
	
	//Methods
	

}
