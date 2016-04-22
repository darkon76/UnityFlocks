using UnityEngine;
using System.Collections;

public class CucarAvoidance : MonoBehaviour {


    #region Private Fields
    [SerializeField]    Transform leftRaycaster;
    [SerializeField]    Transform middleRaycaster;
    [SerializeField]    Transform rightRaycaster;
    [Space]
    [SerializeField]    float avoidAngle;
    [SerializeField]    float rayDistance;

    [SerializeField]    LayerMask mask;

    [SerializeField]
    bool debug = false;
	#endregion
	
	//Properties
	
	#region Unity Methods
	// Update is called once per frame
	void Update () 
	{
        float left = Raycast(leftRaycaster);
        float right = Raycast(rightRaycaster);
        RotateToAvoid(transform.parent ?? transform, left>right? -left :right);
	}
	#endregion

	#region Events
	
	#endregion
	
	//Methods
	
    float Raycast(Transform caster)
    {
        if (caster == null)
            return 0;

        float force = 0;

        

        RaycastHit2D hit = Physics2D.Raycast(caster.position, caster.up,rayDistance, mask);
        if(hit)
        {
            force = rayDistance - hit.distance;
        }

        if (debug)
        {
            Debug.DrawRay(caster.position, caster.up * rayDistance, hit?Color.red:Color.white);
        }

        return force;
    }

    void RotateToAvoid(Transform trans, float direction)
    {
        if(direction != 0)
        {
            trans.Rotate(Vector3.forward, direction * avoidAngle * Time.deltaTime);
        }
       
    }

}
