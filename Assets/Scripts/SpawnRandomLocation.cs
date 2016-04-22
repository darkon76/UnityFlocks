using UnityEngine;
using System.Collections;

public class SpawnRandomLocation : MonoBehaviour {


    #region Private Fields
    [SerializeField]    GameObject prefab;
    [SerializeField]    int number = 20;
    [SerializeField]    Vector2 limits;
	#endregion
	
	//Properties
	
	#region Unity Methods
	void Awake()
	{
        if(prefab)
        {
            for (int i = 0; i < number; ++i)
            {
                Vector3 randomPos = new Vector3(Random.Range(0f, limits.x), Random.Range(0f, limits.y), 0f);
                GameObject go = Instantiate(prefab) as GameObject;
                go.transform.position = randomPos;
                go.transform.eulerAngles = new Vector3(0,0, Random.Range(0, 360));

            }
        }

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
