﻿using UnityEngine;
using System.Collections;

public class OleadasNivel1 : MonoBehaviour
{
	private GameObject enemy1;
	private GameObject enemy2;
	private GameObject enemy3;

	public OleadasNivel1(GameObject enemy1Prefab, GameObject enemy2Prefab, GameObject enemy3Prefab){
		enemy1 = enemy1Prefab;
		enemy2 = enemy2Prefab;
		enemy3 = enemy3Prefab;
	}

	public void primerOleada (Transform camera){
		float currentRotation = 0f;

		Instantiate(enemy1, camera.position + new Vector3(0f,						-Properties.limitY() -11f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(Properties.limitX() +4f,	-Properties.limitY() -4f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(Properties.limitX() +7f,	0,							2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(Properties.limitX() +4f,	Properties.limitY() +4f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(0f,						Properties.limitY() +11f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(-Properties.limitX() -4f,	Properties.limitY() +4f,	2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(-Properties.limitX() -7f, 0f,							2.9f), angleRotation(ref currentRotation));
		Instantiate(enemy1, camera.position + new Vector3(-Properties.limitX() -4f,	-Properties.limitY() -4f,	2.9f), angleRotation(ref currentRotation));

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	private Quaternion angleRotation(ref float currentRotation){
		Quaternion angle = Quaternion.Euler (0f, 0f, currentRotation);
		currentRotation += 45;

		return angle;
	}

	public void segundaOleada (Transform camera){
		Instantiate(enemy2, camera.position + new Vector3(Properties.limitX()-2f,Properties.limitY()-2f,2.9f),flip(camera.rotation));
		Instantiate(enemy2, camera.position + new Vector3(-Properties.limitX()+2f,Properties.limitY()-2f,2.9f),flip(camera.rotation));

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}

	private Quaternion flip(Quaternion rotation){
		return rotation * Quaternion.Euler (0f, 0f, 180f);
	}

	public void tercerOleada (Transform camera){
		float initY = -3f;
		float initX = Properties.limitX () + 4f;
		float sideCam = 1f;

		for (float y = initY; y < 9f; y += 3f) {
			for (float x = initX; x < 51f; x += 3f) {
				GameObject enemy = Instantiate (enemy3, camera.position + new Vector3 (x * sideCam, y, 2.9f),flip(camera.rotation));
				Destroy (enemy,27);
			}

			sideCam *= -1;
		}

		/*Se le suma 2.9 para que los enemigos aparescan por encima de la posicion de la camara, y para que
			esta sea 0 se le suma 2.9
		*/
	}
}

