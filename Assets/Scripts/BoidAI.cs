using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BoidAI : MonoBehaviour {

    
    public enum Modes
    {
        Aligment = 1<< 0,
        Cohesion = 1 << 1,
        Separation = 1 << 2
    }


    #region Private Fields


    [SerializeField, EnumFlag]
    Modes currentMode;

    [SerializeField]    float rotationSpeed;
    [SerializeField]    float cohesionSpeed;
    [SerializeField]    float separationSpeed;
    [SerializeField]    float sweatPoint;
    [Space]
    [SerializeField]    float detectionRange;
    [Header("Debug")]
    [SerializeField]    List<BoidAI> neighbor = new List<BoidAI>();

    CircleCollider2D detectionCollider = null;
    eTeams team;

    Transform parent;

    public Vector3 Position
    {
        get { return transform.parent.transform.position; }
        set { transform.parent.transform.position = value; }
    }

    public Vector3 Euler
    {
        get { return transform.parent.transform.eulerAngles; }
        set { transform.parent.transform.eulerAngles = value; }
    }
    
	#endregion
	
	//Properties
    public eTeams Team
    {
        get { return team; }
    }

    public void SetMode(Modes mode )
    {
        currentMode = mode;
    }
	
	#region Unity Methods
	void Awake()
	{
        detectionCollider = gameObject.AddComponent<CircleCollider2D>();
        detectionCollider.radius = detectionRange;
        detectionCollider.isTrigger = true;
        Ship ship = transform.parent.GetComponent<Ship>();
        team = ship.Team;
        parent = transform.parent;
	}
	
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if((currentMode & Modes.Aligment) !=0)
        {
            Alignment();
        }
        if ((currentMode & Modes.Cohesion) != 0)
        {
            Cohesion();
        }
        if ((currentMode & Modes.Separation) != 0)
        {
            Separation();
        }
           



    }

    void OnValidate()
    {
        if(detectionCollider)
        {
            detectionCollider.radius = detectionRange;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == gameObject.tag)
        {
            BoidAI otherBoid = other.GetComponentInChildren<BoidAI>();
            if(CanFlock(otherBoid))
            {
                neighbor.Add(otherBoid);
            }
        }
    }

    bool CanFlock(BoidAI other)
    {
        if(other)
        {
            if (other.Team == team && !neighbor.Contains(other))
            {
                return true;
            }
        }

        return false;
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            BoidAI otherBoid = other.GetComponentInChildren<BoidAI>();
            if (otherBoid)
            {
                neighbor.Remove(otherBoid);
            }
        }
    }

    public void OnDestroy()
    {
        foreach (BoidAI com in neighbor)
        {
            if (com)
            {
                com.OnNeighborDestroy(this);
            }
        }
    }
    #endregion

    #region Events

    #endregion

    //Methods

    public void OnNeighborDestroy(BoidAI boid)
    {
        neighbor.Remove(boid);
    }

    


    void Alignment()
    {
        if(neighbor.Count > 0)
        {
            float totalRotation = 0;

            for (int i = 0; i < neighbor.Count; ++i)
            {
                totalRotation += neighbor[i].Euler.z;
            }

            totalRotation /= neighbor.Count;
            Vector3 rotation = Euler;
            rotation.z = Mathf.LerpAngle(rotation.z, totalRotation, Time.deltaTime * rotationSpeed);
            Euler = rotation;
           

        }

    }

    void Cohesion()
    {
        if (neighbor.Count > 0)
        {
            Vector2 cohesionPoint = Vector2.zero;
            for (int i = 0; i < neighbor.Count; ++i)
            {
                cohesionPoint.x += neighbor[i].Position.x;
                cohesionPoint.y += neighbor[i].Position.y;
            }
            cohesionPoint /= neighbor.Count;
          //  float sweatPoint = Vector3.Distance(Position, cohesionPoint) / detectionRange;
         //   float tmp = Mathf.Lerp(0, cohesionSpeed, sweatPoint);
            //  float sweatPoint = detectionRange - Vector3.Distance(Position, cohesionPoint);
            Position = Vector3.MoveTowards(Position, cohesionPoint, Time.deltaTime * cohesionSpeed);
        }


    }

    void Separation()
    {
        if (neighbor.Count > 0)
        {
            Vector3 closetPosition= Vector3.zero;
            float closestDistance = float.MaxValue;
            Vector3 separationPoint = Vector3.zero;
            
            for (int i = 0; i < neighbor.Count; ++i)
            {
                separationPoint.x += Position.x - neighbor[i].Position.x;
                separationPoint.y += Position.y - neighbor[i].Position.y;
                float distance = Vector3.Distance(Position, neighbor[i].Position);
                if(distance< closestDistance)
                {
                    closestDistance = distance;
                    closetPosition= neighbor[i].Position;
                }
            }
            separationPoint /= neighbor.Count;

            separationPoint += Position;
           // separationPoint -= closetPosition;
            sweatPoint = Vector3.Distance(Position, separationPoint) / detectionRange;
            sweatPoint = Mathf.Lerp(separationSpeed, 0, sweatPoint);
            Position = Vector3.MoveTowards(Position, separationPoint, Time.deltaTime * sweatPoint);

        }

    }



}
