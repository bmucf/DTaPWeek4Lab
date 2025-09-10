using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


/*  Script applies the 'Enemies' rotation logic around a point, most likely the player, 
 *  as well as the logic to face the player and avoid contact with the player
 */
public class EnemyOrbitBehavior : MonoBehaviour
{
    // The target at which the enemy will look and and rotate around
    public Transform target;
    private Vector3 tempTarget;

    // Target radius
    public float targetOrbitRadius;
    public float targetOrbitSpeed;
    private float angle = 0f; // Current angle in radians


    private float temp;

    private void Start()
    {   
        tempTarget = target.position;
        transform.position = new Vector3(tempTarget.x, tempTarget.y + targetOrbitRadius);
        temp = targetOrbitSpeed;
    }

    void Update()
    {
        // Increment the angle based on time and speed
        angle += targetOrbitSpeed * Time.deltaTime;

        // Keep angle between 0 and 2π for readability (not required)
        if (angle > Mathf.PI * 2f)
            angle -= Mathf.PI * 2f;

        // Calculate new position
        float x = Mathf.Cos(angle) * targetOrbitRadius;
        float y = Mathf.Sin(angle) * targetOrbitRadius;

        // Apply position relative to target
        transform.position = new Vector3(
            tempTarget.x + x,
            tempTarget.y + y
        );

        if (OrbitRadius() < 2f)
        {

            targetOrbitSpeed *= 3;
        }
        else
            targetOrbitSpeed = temp;


        if (OrbitRadius() < 2.5f)
        {
            tempTarget = Vector3.Lerp(tempTarget, target.position, Time.deltaTime * targetOrbitSpeed);

        }

    }


    // Calculate distance between enemy and target
    private float OrbitRadius()
    {
        Vector3 diff = target.transform.position - transform.position;
        float distance = diff.magnitude;

        return distance;
    }

}
