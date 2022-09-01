using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckSecondMethod : MonoBehaviour
{
    /* This metod, harder that the last one, is better as it get rid off all downsides 
     * of the first one.
     * Slides or platform end are no scary at all now :)
     */

    [Header("Collider from player")]
    [SerializeField] CapsuleCollider2D coll;
    [Header("How far under the player our ray can reach?")]
    [SerializeField] float extraLenght;
    [Header("What is ground - Layer")]
    [SerializeField] LayerMask layer;

    bool IsGrounded()
    {

        //We draw a box under character, that will check for ground
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraLenght, layer);

        //Draw this box
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(coll.bounds.center + new Vector3(coll.bounds.extents.x, 0), Vector2.down * (coll.bounds.extents.y + extraLenght), rayColor);
        Debug.DrawRay(coll.bounds.center - new Vector3(coll.bounds.extents.x, 0), Vector2.down * (coll.bounds.extents.y + extraLenght), rayColor);
        Debug.DrawRay(coll.bounds.center - new Vector3(coll.bounds.extents.x, coll.bounds.extents.y + extraLenght), Vector2.right * (coll.bounds.extents.x * 2), rayColor);

        return raycastHit.collider != null;
    }

    private void Update()
    {
        if (IsGrounded())
        {
            EventManager.IsOnGroundFunction(IsGrounded());
        }
    }
}
