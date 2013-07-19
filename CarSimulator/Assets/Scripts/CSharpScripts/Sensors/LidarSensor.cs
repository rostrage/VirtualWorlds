using UnityEngine;
using System.Collections;

public class LidarSensor : CarSensor {

	Vector3[] spherePoints = new Vector3[180*360];
	Vector3 position;
	int j = 0;
	void Start() {
		position = transform.position;
		for(int theta=0; theta<180; theta++)
		{
			float sintheta = Mathf.Sin(theta*Mathf.Deg2Rad);
			float costheta = Mathf.Cos(theta*Mathf.Deg2Rad);
			for(int phi=0; phi<360; phi++)
			{
				float sinphi=Mathf.Sin(phi*Mathf.Deg2Rad);
				float cosphi=Mathf.Cos(phi*Mathf.Deg2Rad);
				spherePoints[theta*180+phi]=new Vector3(sintheta*cosphi, sinphi*sintheta, costheta);
			}
		}
//		Time.timeScale/=2;
	}
	// Update is called once per frame
	void Update () {
		position = transform.position;
		if(j>180)
		{
			j=0;
		}
		RaycastHit hit;
		for(int i=0; i<360; i++)
		{
			Debug.DrawRay(position, spherePoints[180*j+i]*100, Color.green);
			if(Physics.Raycast(new Ray(position, spherePoints[i]), out hit))
			{
				
			}
			else
			{
			}
		}
		j++;
	}
}
