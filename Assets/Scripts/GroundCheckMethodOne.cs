using UnityEngine;

public class GroundCheckMethodOne : MonoBehaviour
{

    /*
     * This metod draw raycast pointing down. This is the easiest method, but have it flaws:
     * 1. In case of slopes raycast will not reach it, and it will act like there was no floor
     * 2. In case of much widhter character it could stop on its side and ray will not detect floor as it is only simple line 
     * 3. As we make ray longer, player could really fast spam jump button to make double jump.
     */

    [Header("Collider from player")]
    [SerializeField] CapsuleCollider2D Coll;
    [Header("How far under the player our ray can reach?")]
    [SerializeField] float extraLenght;
    [Header("What is ground - Layer")]
    [SerializeField] LayerMask layer;

    bool IsGrounded()
    {
        
        //We draw a line pointing down as to check if there is ground
        RaycastHit2D raycastHit = Physics2D.Raycast(Coll.bounds.center, Vector2.down, Coll.bounds.extents.y + extraLenght, layer);

        //Draw our ray
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(Coll.bounds.center, Vector2.down * (Coll.bounds.extents.y + extraLenght), rayColor);
       
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
