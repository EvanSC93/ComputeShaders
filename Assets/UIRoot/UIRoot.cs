using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField] private Camera m_MainCamera;
    [SerializeField] private Camera m_UICamera;
    [SerializeField] private RectTransform m_CanvasRect;
    [SerializeField] private GameObject m_Obj;
    [SerializeField] private RectTransform m_TargetUIRect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = m_MainCamera.WorldToScreenPoint(m_Obj.transform.position);
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_CanvasRect, screenPos, m_UICamera, out Vector2 localPos))
        {
            m_TargetUIRect.anchoredPosition = localPos;
        }
    }
}
