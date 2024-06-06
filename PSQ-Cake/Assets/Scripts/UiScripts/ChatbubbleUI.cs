using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatbubbleUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;    // The GameObject to follow
    public Vector3 offset;      // Offset from the target's position

    private void LateUpdate()
    {
        // Update the position of the text
        transform.position = target.position + offset;

        // Reset the rotation to zero to prevent flipping
        transform.rotation = Quaternion.identity;
    }

}

