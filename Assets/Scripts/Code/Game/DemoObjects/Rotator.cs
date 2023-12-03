using UnityEngine;
using System.Collections;
//--------------------------------------------------------------------
//Small class to rotate an object with a certain velocity. Used for moving platforms in levels.
//--------------------------------------------------------------------
public class Rotator : MonoBehaviour
{
    [SerializeField] float m_MovementSpeed = 0.0f;
    [SerializeField] Vector3 offset = Vector3.zero;
    void FixedUpdate()
    {
        transform.RotateAround(transform.position + offset, Vector3.forward, Time.fixedDeltaTime * m_MovementSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + offset, 0.1f);
    }
}