using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Tooltip("If F5 changes view!")] public bool switchableView;
    [Tooltip("The Head of the player where the camera gets placed!")] public Transform player;
    [Tooltip("How far the camera away is in third person!")] public float distance;

    bool firstPerson = true;

    void Update()
    {
        if(switchableView == true && firstPerson == true && Input.GetKeyDown(KeyCode.F5))
        {
            firstPerson = false;
            Debug.Log("hehehehah");
        }

        if (switchableView == true && firstPerson == false && Input.GetKeyDown(KeyCode.F5))
        {
            firstPerson = true;
        }

        if (firstPerson == true)
        {
            transform.position = player.transform.position;
        }

        if (firstPerson == false)
        {
            transform.position = new Vector3(player.position.x, player.position.y, player.position.z + distance);
        }
    }
}
