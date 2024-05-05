using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    Vector3 camOffset = new Vector3(0, 0, -30);

    void LateUpdate()
    {
        this.transform.position = player.transform.position + camOffset;
    }
}
