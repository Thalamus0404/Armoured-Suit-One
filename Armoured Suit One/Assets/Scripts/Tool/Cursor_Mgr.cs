using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Mgr : MonoBehaviour
{
    RectTransform cursorPos;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        cursorPos = GetComponent<RectTransform>();
        cursorPos.anchoredPosition = Vector2.zero;
    }

        void Update()
    {
        Vector2 mousePos= Input.mousePosition;
        cursorPos.anchoredPosition = mousePos;
    }
}
