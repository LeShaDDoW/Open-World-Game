using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Tooltip("If F5 changes view!")] public bool switchableView;
    [Tooltip("The Head of the player where the camera gets placed!")] public Transform player;
    [Tooltip("How far the camera away is in third person!")] public float distance;
    [Tooltip("The Main Camera Object!")] public Transform mainCamera;
    [Tooltip("Just disable the Player!")] public LayerMask thirdPersonLayerMask;

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
            mainCamera.localPosition = new Vector3(0, 0, 0);
        }

        if (firstPerson == false)
        {
            transform.position = player.transform.position;

            RaycastHit hit;
            Physics.Raycast(transform.position, -transform.forward, out hit, distance);

            if(hit.collider == null) mainCamera.localPosition = new Vector3(0, 0, -distance);
            else mainCamera.position = new Vector3(hit.point.x + .1f, 
                hit.point.y + .1f, hit.point.z + .1f);
        }
    }
}
