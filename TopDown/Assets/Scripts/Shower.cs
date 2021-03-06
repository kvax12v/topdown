using UnityEngine;
using System.Collections;

public class Shower : MonoBehaviour {

	public GameObject meteorPrefab;
	public GameObject centerPlanet;
	public float smallRange;
	public float bigRange;

	public float meteorThrust = 500f;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

	}

	public void meteorShower(int side, int spawner) { //may want to have small, med, large shower sizes and condense code using loops/arrays of meteors
		GameObject meteor1 = (GameObject)Instantiate (meteorPrefab, new Vector2(this.transform.position.x + Random.Range(-smallRange, smallRange), this.transform.position.y + Random.Range(-smallRange, smallRange)), this.transform.rotation);
		GameObject meteor2 = (GameObject)Instantiate (meteorPrefab, new Vector2(this.transform.position.x + Random.Range(-smallRange, smallRange), this.transform.position.y + Random.Range(-smallRange, smallRange)), this.transform.rotation);
		GameObject meteor3 = (GameObject)Instantiate (meteorPrefab, new Vector2(this.transform.position.x + Random.Range(-smallRange, smallRange), this.transform.position.y + Random.Range(-smallRange, smallRange)), this.transform.rotation);

		//Rotating each of the asteroids to "face" the center planet
		Quaternion rotation1 = Quaternion.LookRotation(centerPlanet.transform.position - meteor1.transform.position, transform.TransformDirection(Vector3.up));
		meteor1.transform.rotation = new Quaternion (0, 0, rotation1.z, rotation1.w);
		Quaternion rotation2 = Quaternion.LookRotation(centerPlanet.transform.position - meteor2.transform.position, transform.TransformDirection(Vector3.up));
		meteor2.transform.rotation = new Quaternion (0, 0, rotation2.z, rotation2.w);
		Quaternion rotation3 = Quaternion.LookRotation(centerPlanet.transform.position - meteor3.transform.position, transform.TransformDirection(Vector3.up));
		meteor3.transform.rotation = new Quaternion (0, 0, rotation3.z, rotation3.w);

		if (side == 0) /*left side spawners*/ {
			meteor1.GetComponent<Rigidbody2D> ().AddForce (meteor1.transform.right * meteorThrust);
			meteor2.GetComponent<Rigidbody2D> ().AddForce (meteor1.transform.right * meteorThrust);
			meteor3.GetComponent<Rigidbody2D> ().AddForce (meteor1.transform.right * meteorThrust);
		}
		if (side == 1) /*right side spawners*/{
			meteor1.GetComponent<Rigidbody2D> ().AddForce (-1 * meteor1.transform.right * meteorThrust);
			meteor2.GetComponent<Rigidbody2D> ().AddForce (-1 * meteor1.transform.right * meteorThrust);
			meteor3.GetComponent<Rigidbody2D> ().AddForce (-1 * meteor1.transform.right * meteorThrust);
		}
	}

	float generateXDistanceLeft(int spawner){
		if (spawner == 0 || spawner == 3) {
			return Random.Range (-bigRange, -smallRange);
		}
		if (spawner == 1 || spawner == 2) {
			return Random.Range (-bigRange, -smallRange);
		}
		return 0;
	}

	float generateXDistanceRight(int spawner){
		if (spawner == 0 || spawner == 3) {
			return Random.Range (smallRange, bigRange);
		}
		if (spawner == 1 || spawner == 2) {
			return Random.Range (smallRange, bigRange);
		}
		return 0;
	}

	float generateYDistanceLeft(int spawner){
		if (spawner == 0 || spawner == 3) {
			return Random.Range (-bigRange, -smallRange);
		}
		if (spawner == 1 || spawner == 2) {
			return Random.Range (smallRange, bigRange);
		}
		return 0;
	}

	float generateYDistanceRight(int spawner){
		if (spawner == 0 || spawner == 3) {
			return Random.Range (smallRange, bigRange);
		}
		if (spawner == 1 || spawner == 2) {
			return Random.Range (-bigRange, -smallRange);
		}
		return 0;
	}
}