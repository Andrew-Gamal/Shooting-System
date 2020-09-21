using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("HI HI HI");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

    }
    // in the loop of physics
    private void FixedUpdate()
    {
        Debug.Log("Fixed");

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");

    }

    private void LateUpdate()
    {
        Debug.Log("late" +gameObject.name);

    }
}
