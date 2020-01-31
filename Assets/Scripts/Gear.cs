using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    // Start is called before the first frame update

    private bool m_IsGrab = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsGrab)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Drop");
            m_IsGrab = false;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Grab");
            m_IsGrab = true;
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
