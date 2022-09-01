using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdGroundCheck : MonoBehaviour
{
    /* To ground check we could use another collider set as trigger on empty object as player child. 
     * Will work the same as second ground check method, but we can easly modified shape of additional collider.
     * Only downside is need of another game object.
     */


    [Header("What is ground - Layer")]
    [SerializeField] LayerMask layer;

    bool isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
       EventManager.IsOnGroundFunction(isGrounded = (collision != null && (((1 << collision.gameObject.layer) & layer) != 0)));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EventManager.IsOnGroundFunction(isGrounded = false);
    }
}
