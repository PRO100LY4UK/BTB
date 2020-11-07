using UnityEngine;

public class Casting : MonoBehaviour
{   
    [Header("Raycast shoot from this Object")]
    [SerializeField] private GameObject rayCastPoint;

    [Header("Raycast Range")]
    [SerializeField] private float rayCastRange = 3f;
    
    
    public static float distanceFromTarget { get; set; }
    public static GameObject target { get; set; }
    public static GameObject previousTarget { get; set; }
    public static bool IsNewTarget => target != previousTarget;

    [SerializeField] private GameObject Target;
    
    private void Start()
    {
        if (!rayCastPoint)
            rayCastPoint = gameObject;
    }

    private void Update()
    {
        ClosestRaycast();
        DebugRaycast();
    }

    /*
     * Get Closest GameObject infront of this.GameObject
     */
    private void ClosestRaycast()
    {
       //Create a new RAYCAST variable (have many informations inside)
        RaycastHit hit;
        
        //Shoot the Raycast FROM -> rayCastPoint.transform.position , in DIRECTION FORWARD, store information in HIT variable, set raycast LENGTH to rayCastRange
        if (Physics.Raycast(rayCastPoint.transform.position, rayCastPoint.transform.forward, out hit, rayCastRange))
        {
            /*
             * HERE YOU DO THINGS IF YOU HIT SOMETHING
             */
            
            //save distance from object HIT in distanceFromTarget
            distanceFromTarget = hit.distance;
        }
        //if we dont hit anything
        else
        {
            /*
             * HERE YOU DO THINGS IF YOU DONT HIT ANYTHING
             */
            target = null;
            previousTarget = target;
        }
        
        /*
         * if(hit.distance <= rayCastRange) {
         *    if(hit.transform.gameObject != null) {
         *        target = hit.transform.gameObject;
         *     }else {
         *        target = null;
         *     }
         * }
         */
        //Get new target IF is in RANGE
        
        target = hit.distance <= rayCastRange ? hit.transform?.gameObject : null;
        Target = target;
    }

    //DEBUG raycast
    private void DebugRaycast()
    {
        Vector3 forward = transform.forward * rayCastRange;
        Debug.DrawRay(rayCastPoint.transform.position, forward, Color.green);
    }
}
