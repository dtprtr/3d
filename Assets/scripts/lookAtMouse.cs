using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class lookAtMouse : MonoBehaviour
{

    float angle;

    
    void Update()
    {
        LAmouse();
        
    }

    private void LAmouse()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 mousePos = hitInfo.point;
            mousePos.y = transform.position.y;

            transform.forward = mousePos - transform.position;
        }

    }
}
