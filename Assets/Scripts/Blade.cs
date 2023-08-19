using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = .1f;
    private Rigidbody2D rigidbody;

    private Vector3 lastMousePos;
    private Vector3 mouseVelo;
    private Collider2D collider;
    // Awake is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collider.enabled = IsMouseMoving();
        SetBladeToMouse();
    }
    private void SetBladeToMouse(){
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rigidbody.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMoving(){
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;
        if(traveled > minVelo)
            return true;
        return false;
    }
}
