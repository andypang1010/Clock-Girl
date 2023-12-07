using UnityEngine;
using System.Collections;
//--------------------------------------------------------------------
//Small class to rotate an object with a certain velocity. Used for moving platforms in levels.
//--------------------------------------------------------------------
public class Rotator : MonoBehaviour
{
    [SerializeField] float m_MovementSpeed = 0.0f;
    [SerializeField] Vector3 offset = Vector3.zero;

    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }

    void FixedUpdate()
    {
        transform.RotateAround(transform.position + offset, Vector3.forward, Time.fixedDeltaTime * m_MovementSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + offset, 1f);
    }
}