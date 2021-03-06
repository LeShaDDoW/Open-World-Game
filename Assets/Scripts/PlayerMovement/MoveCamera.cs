using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Basic Camera Stuffz")]
    [Tooltip("The Head of the player where the camera gets placed!")] public Transform player;
    [Tooltip("The Main Camera Object!")] public Transform mainCamera;

    [Header("F5 Mode Stuffz")]
    [Tooltip("If F5 changes view!")] public bool switchableView;
    [Tooltip("How far the camera away is in third person!")] public float distance;

    [Space(10)]

    [Tooltip("Just disable the Player!")] public LayerMask thirdPersonLayerMask;
    [Tooltip("The 'Person' 3D Model Object Under The Player!")] public Transform personModel;
    [Tooltip("The Disabled 'Body' Object Under the Person Object!")] public GameObject bodyModel;
    [Tooltip("The 'First Person HUD' Object Under the Main Camera!")] public GameObject firstPersonHUD;

    bool firstPerson = true;

    void Update()
    {
        if(switchableView == true && firstPerson == true && Input.GetKeyDown(KeyCode.F5))
        {
            firstPerson = false;
            bodyModel.SetActive(true);
            firstPersonHUD.SetActive(false);
        } else if (switchableView == true && firstPerson == false && Input.GetKeyDown(KeyCode.F5))
        {
            firstPerson = true;
            bodyModel.SetActive(false);
            firstPersonHUD.SetActive(true);
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

            float difference = personModel.rotation.y - transform.rotation.y;

            personModel.RotateAround(Vector3.up, difference);
        }
    }
}
