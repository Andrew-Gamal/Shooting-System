using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public GameObject obj;  
    public float childScale;
    public int counter = 5;
    // Start is called before the first frame update
    void Start()
    {

        counter--;
      

        if (counter > 0)
        {
            var newCube = GameObject.Instantiate(obj.gameObject);
            var newCube1 = GameObject.Instantiate(obj.gameObject);
            var newCube2 = GameObject.Instantiate(obj.gameObject);
            var newCube3 = GameObject.Instantiate(obj.gameObject);
            var newCube4 = GameObject.Instantiate(obj.gameObject);
            var newCube5 = GameObject.Instantiate(obj.gameObject);

            newCube.GetComponent<Cubes>().counter = counter;
            newCube1.GetComponent<Cubes>().counter = counter;
            newCube2.GetComponent<Cubes>().counter = counter;
            newCube3.GetComponent<Cubes>().counter = counter;
            newCube4.GetComponent<Cubes>().counter = counter;
            newCube5.GetComponent<Cubes>().counter = counter;

            newCube.transform.position = this.transform.position + Vector3.up;
            newCube1.transform.position = this.transform.position + Vector3.right;
            newCube2.transform.position = this.transform.position + Vector3.left;
            newCube3.transform.position = this.transform.position + Vector3.forward;
            newCube4.transform.position = this.transform.position + Vector3.back;
            newCube5.transform.position = this.transform.position + Vector3.down;

            newCube.transform.parent = this.transform;
            newCube.transform.localScale = Vector3.one * childScale;
            newCube.transform.localPosition = Vector3.up * (0.5f + 0.5f * childScale);

            newCube1.transform.parent = this.transform;
            newCube1.transform.localScale = Vector3.one * childScale;
            newCube1.transform.localPosition = Vector3.right * (0.5f + 0.5f * childScale);

            newCube2.transform.parent = this.transform;
            newCube2.transform.localScale = Vector3.one * childScale;
            newCube2.transform.localPosition = Vector3.left * (0.5f + 0.5f * childScale);

            newCube3.transform.parent = this.transform;
            newCube3.transform.localScale = Vector3.one * childScale;
            newCube3.transform.localPosition = Vector3.forward * (0.5f + 0.5f * childScale);

            newCube4.transform.parent = this.transform;
            newCube4.transform.localScale = Vector3.one * childScale;
            newCube4.transform.localPosition = Vector3.back * (0.5f + 0.5f * childScale);

            newCube5.transform.parent = this.transform;
            newCube5.transform.localScale = Vector3.one * childScale;
            newCube5.transform.localPosition = Vector3.down * (0.5f + 0.5f * childScale);

            counter--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
