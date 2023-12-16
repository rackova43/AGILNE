using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravity : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        // Make sure to start without gravity
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    // Function to activate gravity
    public void EnableGravity()
    {
        if (rb != null)
        {
            rb.useGravity = true;
        }
    }

    // Detect mouse click or touch on this GameObject
    void OnMouseDown()
    {
        EnableGravity();
    }
}
