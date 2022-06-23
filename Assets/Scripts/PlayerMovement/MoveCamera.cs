using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Tooltip("If F5 changes view!")] public bool switchableView;
    [Tooltip("The Head of the player where the camera gets placed!")] public Transform player;
    [Tooltip("How far the camera away is in third person!")] public float distance;
    [Tooltip("The Main Camera Object!")] public Transform mainCamera;

    bool firstPerson = true;

    void Update()
    {
        if(switchableView == true && firstPerson == true && Input.GetKeyDown(KeyCode.F5))
        {
            firstPerson = false;
        } else if (switchableView == true && firstPerson == false && Input.GetKeyDown(KeyCode.F5))
        {
            firstPerson = true;
        }

        if (firstPerson == true)
        {
            transform.position = player.transform.position;
        }

        if (firstPerson == false)
        {
            transform.position = player.transform.position;

            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, distance * 0.01f);

            if(hit.collider == null) mainCamera.position = new Vector3(0, 0, -distance);
            else mainCamera.position = new Vector3(transform.position.x, 
                transform.position.y, hit.point.z);
        }
    }
}
