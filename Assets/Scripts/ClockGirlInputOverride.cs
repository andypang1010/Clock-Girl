using UnityEngine;
using System.Collections;

public class ClockGirlInputOverride : MonoBehaviour
{
    [SerializeField] PlayerInput m_PlayerInput = null;
    [SerializeField] string m_InputOverrideName = "";
    [SerializeField]
    Vector2 m_Direction = Vector2.zero;
    void Start()
    {
        m_PlayerInput.GetDirectionInput(m_InputOverrideName).SetOverride(true, m_Direction);
    }
}
