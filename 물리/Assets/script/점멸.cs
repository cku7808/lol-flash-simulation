using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 점멸 : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera camera;
    public float MaxDistance = 50.0f;

    // Update is called once per frame
    void Awake()
    {
        camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            teleport();
        }
    }
    private void Move(Vector3 dest)
    {
        transform.position = dest;
    }
    void teleport(){
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1.0f);
        if (Physics.Raycast(ray, out hit, MaxDistance))
        {
            if ((hit.point - transform.position).magnitude <= 10)
            {
                Move(new Vector3(hit.point.x, hit.point.y, -1.5f));
                print(hit.point);
            }
            else
            {
                Vector3 tmp = transform.position;
                Vector3 pos = (hit.point - transform.position).normalized;
                Vector3 target = transform.position + pos * 10;
                Move(transform.position + pos * 10);
                print((tmp - target).magnitude);
            }
        }
    }
}
