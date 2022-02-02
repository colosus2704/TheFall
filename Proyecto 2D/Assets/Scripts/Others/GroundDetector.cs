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
    void Update()
    {
        capsuleCastRad = capsule.size.x / 2;
        Vector2 position = (Vector2)transform.position + capsule.offset;
        capsuleCast1 = position + Vector2.up * (capsule.size.y / 2 - capsuleCastRad);
        capsuleCast2 = position - Vector2.up * (capsule.size.y / 2 - capsuleCastRad);

        isGrounded = Physics2D.CapsuleCast(position, capsule.size, capsule.direction, 0, Vector2.down, skinWidth, (1 << GroundLayer));
    }
}
