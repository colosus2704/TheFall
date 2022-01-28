using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public float skinWidth = 0.1f;

    public bool isGrounded;

    CapsuleCollider2D capsule;


    Vector2 capsuleCast1;
    Vector2 capsuleCast2;
    float capsuleCastRad;
    
    const int GroundLayer = 8;

    // Start is called before the first frame update
    void Start()
    {
        capsule = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        capsuleCastRad = capsule.size.x / 2;
        Vector2 position = (Vector2)transform.position + capsule.offset;
        capsuleCast1 = position + Vector2.up * (capsule.size.y / 2 - capsuleCastRad);
        capsuleCast2 = position - Vector2.up * (capsule.size.y / 2 - capsuleCastRad);

        isGrounded = Physics2D.CapsuleCast(position, capsule.size, capsule.direction, 0, Vector2.down, skinWidth, (1 << GroundLayer));
    }
    //private void OnDrawGizmos()
    //{
    //    Vector3 p1 = capsuleCast1;
    //    Vector3 p2 = capsuleCast2;
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(p1, capsuleCastRad);
    //    Gizmos.DrawWireSphere(p2, capsuleCastRad);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(p1, capsuleCastRad + skinWidth);
    //    Gizmos.DrawWireSphere(p2, capsuleCastRad + skinWidth);
    //}
}
