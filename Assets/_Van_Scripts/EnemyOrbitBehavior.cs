using System.Runtime.CompilerServices;
using UnityEngine;


/*  Script applies the 'Enemies' rotation logic around a point, most likely the player, 
 *  as well as the logic to face the player and avoid contact with the player
 */
public class EnemyOrbitBehavior : MonoBehaviour
{
    // The target at which the enemy will look and and rotate around
    public Transform target;

    // Target radius
    public float targetOrbitRadius;
    public float targetOrbitSpeed;
    private float angle = 0f; // Current angle in radians

    public float orbitRadius;

    private void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y + targetOrbitRadius);
        orbitRadius = targetOrbitRadius;
        
    }

    void Update()
    {
        // Increment the angle based on time and speed
        angle += targetOrbitSpeed * Time.deltaTime;

        // Keep angle between 0 and 2π for readability (not required)
        if (angle > Mathf.PI * 2f)
            angle -= Mathf.PI * 2f;

        // Calculate new position
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;

        // Apply position relative to target
        transform.position = new Vector3(
            target.position.x + x,
            target.position.y + y
        );
    }

    // Orbit Logic (using Radians)
    private void Orbit()
    {
       
    }

    // Calculate distance between enemy and target
    private float OrbitRadius()
    {
        Vector3 diff = target.transform.position - transform.position;
        float distance = diff.magnitude;

        return distance;
    }

}
