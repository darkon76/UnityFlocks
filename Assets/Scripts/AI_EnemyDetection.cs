using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_EnemyDetection : MonoBehaviour {


    #region Private Fields

    [SerializeField]
    float radarSize = 5;
    Ship ship;
    LookAtTarget lookAtTarget;
    List<Ship> enemies = new List<Ship>();

    Transform defaultTarget;


	#endregion
	
	//Properties
	
	#region Unity Methods
	void Awake()
	{
        ship = transform.parent.GetComponent<Ship>();
        lookAtTarget = transform.parent.GetComponent<LookAtTarget>();
        defaultTarget = lookAtTarget.Target;
	}

    IEnumerator CheckTarget()
    {
        if(lookAtTarget.Target == null)
        {
            lookAtTarget.Target = defaultTarget;
        }
        yield return null;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            Ship otherShip = other.GetComponent<Ship>();
            if (otherShip)
            {

                if (otherShip.Team != ship.Team && !enemies.Contains(otherShip))
                {
                    enemies.Add(otherShip);
                    if (lookAtTarget.Target == defaultTarget || lookAtTarget.Target == null)
                    {
                        lookAtTarget.Target = otherShip.transform;
                    }
                }

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            Ship otherShip = other.GetComponent<Ship>();
            if (otherShip)
            {
                if (otherShip.Team != ship.Team)
                {
                    enemies.Remove(otherShip);
                }
                if(lookAtTarget.Target == otherShip.transform)
                {
                    SearchNewTarget();
                }
            }
        }
    }
    #endregion

    #region Events

    #endregion

    //Methods
    void SearchNewTarget()
    {
        while(enemies.Count > 0)
        {
            int index = Random.Range(0, enemies.Count);
            lookAtTarget.Target = enemies[index].transform;
            if(lookAtTarget.Target == null)
            {
                enemies.RemoveAt(index);
            }
            else
            {
                return;
            }
        }

        lookAtTarget.Target = defaultTarget;
    }

    void OnValidate()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = radarSize;
    }

}
