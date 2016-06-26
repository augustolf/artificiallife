using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {

    public GameObject grass;
    public LayerMask layer;

    private float nextActionTime = 0.0f;
    public float period = 1f;
    public int energy = 0;

    void Start() {
        energy = 0;
        InvokeRepeating("AbsorbingEnergy", 1, 1F);
        Debug.DrawLine(transform.position, Vector3.forward, Color.red, 5, false);
        //Debug.DrawLine(transform.position, Vector3.back * 2, Color.red, 10, false);
        //Debug.DrawLine(transform.position, Vector3.left * 2, Color.red, 10, false);
       // Debug.DrawLine(transform.position, Vector3.right * 2, Color.red, 10, false);
    }

    void AbsorbingEnergy() {
        if (energy < 5) {
            energy += 1;
            print("Energy: " + energy);
        } else if (energy == 5) {
            //CloneGrass();
            //energy = 0;
            CheckEmptySpot();
            energy = 0;
        }
    }

    void CheckEmptySpot() {   


        if (Physics.Raycast(transform.position, Vector3.forward, 1f, layer)) {
            print("forward");
            CloneGrass(Vector3.forward);
        } else if (Physics.Raycast(transform.position, Vector3.back, 1f, layer)) {
            print("back");
            CloneGrass(Vector3.back);
        } else if (Physics.Raycast(transform.position, Vector3.left, 1f, layer)) {
            print("left");
            CloneGrass(Vector3.left);
        } else if (Physics.Raycast(transform.position, Vector3.left, 1f, layer)) {
            print("right");
            CloneGrass(Vector3.right);
        }
    }

    void CloneGrass(Vector3 direction) {
        grass = Instantiate(grass);
        // grass.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1);
        grass.transform.position = transform.TransformDirection(direction);
        Debug.DrawLine(transform.position, direction, Color.red, 5, false);
    }
	
	// Update is called once per frame
	void Update () {

        //if (Time.time > nextActionTime) {
        //    nextActionTime += period;
        //    print("Energy: " + energy);
        //}

    }
}
