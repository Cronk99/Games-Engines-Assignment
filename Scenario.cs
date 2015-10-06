using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace BGE.Scenarios
{
    public abstract class Scenario
    {
        System.Random random = new System.Random(DateTime.Now.Millisecond);

        public GameObject leaderPrefab = SteeringManager.Instance.leaderPrefab;
        public GameObject boidPrefab = SteeringManager.Instance.boidPrefab;
		public GameObject AlliancePrefab = SteeringManager.Instance.AlliancePrefab;
		
        public abstract string Description();
        public abstract void Start();
	
        public GameObject leader;
		public GameObject alliance;


		//this is added so to allow reaver ship movement and reference in the code

		public GameObject fleet_Obs1;
		public GameObject fleet_Obs2;
		public GameObject fleet_Obs3;
		public GameObject fleet_Obs4;
		public GameObject fleet_Obs5;
		public GameObject fleet_Obs6;
		public GameObject fleet_Obs7;
		public GameObject fleet_Obs8;

		//Fleet on right side
		public GameObject fleetR1;
		public GameObject fleetR2;
		public GameObject fleetR3;
		public GameObject fleetR4;

		//Fleet on left Side
		public GameObject fleetL1;
		public GameObject fleetL2;
		public GameObject fleetL3;
		public GameObject fleetL4;

		//Fleet Up above
		public GameObject fleetU1;
		public GameObject fleetU2;
		public GameObject fleetU3;
		public GameObject fleetU4;

		//Fleet Down below
		public GameObject fleetD1;
		public GameObject fleetD2;
		public GameObject fleetD3;
		public GameObject fleetD4;


		//public GameObject[] fleets = new GameObject[10];
		public Vector3 reavers_forward = new Vector3(0,0,800);

		public void Roll(float angle)
		{
			Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
			leader.transform.rotation = rot * leader.transform.rotation;
		}

        public virtual void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject camera = (GameObject)GameObject.FindGameObjectWithTag("MainCamera");
                Vector3 newTargetPos = camera.transform.position + camera.transform.forward * 200.0f;
                leader.GetComponent<SteeringBehaviours>().seekTargetPos = newTargetPos;
            }

            if (Input.GetMouseButtonDown(1))
            {
                GameObject camera = (GameObject)GameObject.FindGameObjectWithTag("MainCamera");
                Vector3 newTargetPos = camera.transform.position;
                leader.GetComponent<SteeringBehaviours>().seekTargetPos = newTargetPos;
            }

			if(leader.transform.position.z > 910 && leader.transform.position.z < 930)
			{
				Roll(Time.deltaTime * 140.0f);
			}

			if(leader.transform.position.z > 1155 && leader.transform.position.z < 1185)
			{
				Roll(Time.deltaTime * 180.0f);
			}
			if(leader.transform.position.z > 1300 && leader.transform.position.z < 1315)
			{
				Roll(Time.deltaTime * 300.0f);
			}

			//assignment stuff******************************************************************************
			if(leader.transform.position.z >= 370 && leader.transform.position.z < 450)
			{


				fleet_Obs1.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs1.transform.position + reavers_forward;
				fleet_Obs2.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs2.transform.position + reavers_forward;
				fleet_Obs3.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs3.transform.position + reavers_forward;
				fleet_Obs4.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs4.transform.position + reavers_forward;
				fleet_Obs5.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs5.transform.position + reavers_forward;
				fleet_Obs6.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs6.transform.position + reavers_forward;
				fleet_Obs7.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs7.transform.position + reavers_forward;
				fleet_Obs8.GetComponent<SteeringBehaviours>().seekTargetPos = fleet_Obs8.transform.position + reavers_forward;

				//Fleet right
				fleetR1.GetComponent<SteeringBehaviours>().seekTargetPos = fleetR1.transform.position + reavers_forward;
				fleetR2.GetComponent<SteeringBehaviours>().seekTargetPos = fleetR2.transform.position + reavers_forward;
				fleetR3.GetComponent<SteeringBehaviours>().seekTargetPos = fleetR3.transform.position + reavers_forward;
				fleetR4.GetComponent<SteeringBehaviours>().seekTargetPos = fleetR4.transform.position + reavers_forward;

				//Fleet Left
				fleetL1.GetComponent<SteeringBehaviours>().seekTargetPos = fleetL1.transform.position + reavers_forward;
				fleetL2.GetComponent<SteeringBehaviours>().seekTargetPos = fleetL2.transform.position + reavers_forward;
				fleetL3.GetComponent<SteeringBehaviours>().seekTargetPos = fleetL3.transform.position + reavers_forward;
				fleetL4.GetComponent<SteeringBehaviours>().seekTargetPos = fleetL4.transform.position + reavers_forward;

				//Fleet Up
				fleetU1.GetComponent<SteeringBehaviours>().seekTargetPos = fleetU1.transform.position + reavers_forward;
				fleetU2.GetComponent<SteeringBehaviours>().seekTargetPos = fleetU2.transform.position + reavers_forward;
				fleetU3.GetComponent<SteeringBehaviours>().seekTargetPos = fleetU3.transform.position + reavers_forward;
				fleetU4.GetComponent<SteeringBehaviours>().seekTargetPos = fleetU4.transform.position + reavers_forward;

				//Fleet Down
				fleetD1.GetComponent<SteeringBehaviours>().seekTargetPos = fleetD1.transform.position + reavers_forward;
				fleetD2.GetComponent<SteeringBehaviours>().seekTargetPos = fleetD2.transform.position + reavers_forward;
				fleetD3.GetComponent<SteeringBehaviours>().seekTargetPos = fleetD3.transform.position + reavers_forward;
				fleetD4.GetComponent<SteeringBehaviours>().seekTargetPos = fleetD4.transform.position + reavers_forward;

				//*******************************************************************************
				fleet_Obs1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleet_Obs2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleet_Obs3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleet_Obs4.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleet_Obs5.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleet_Obs6.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleet_Obs7.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleet_Obs8.GetComponent<SteeringBehaviours>().ArriveEnabled = true;


				fleetR1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetR2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetR3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetR4.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				//**********************************************
				fleetL1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetL2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetL3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetL4.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				//**********************************************
				fleetU1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetU2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetU3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetU4.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				//**********************************************
				fleetD1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetD2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetD3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
				fleetD4.GetComponent<SteeringBehaviours>().ArriveEnabled = true;


			}



        }

        public void DestroyObjectsWithTag(string tag)
        {
            GameObject[] o = GameObject.FindGameObjectsWithTag(tag);
            for (int i = 0; i < o.Length; i++)
            {
                GameObject.Destroy(o[i]);
            }
        }

        public GameObject CreateObstacle(Vector3 position, float radius)
        {
            GameObject o;

            o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.tag = "obstacle";
            o.GetComponent<Renderer>().material.color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
            o.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
            o.transform.position = position;
            return o;

        }

        public GameObject CreateBoid(Vector3 position, GameObject prefab)
        {
            GameObject boid;

            boid = (GameObject)GameObject.Instantiate(prefab);
            boid.tag = "boid";
            boid.AddComponent<SteeringBehaviours>();
            boid.transform.position = position;

            return boid;
        }

        public GameObject CreateCamFollower(GameObject leader, Vector3 offset)
        {
            GameObject camFollower = new GameObject();
            camFollower.tag = "camFollower";
            camFollower.AddComponent<SteeringBehaviours>();
            camFollower.GetComponent<SteeringBehaviours>().leader = leader;
            camFollower.GetComponent<SteeringBehaviours>().offset = offset;
            camFollower.transform.position = leader.transform.TransformPoint(offset);
            camFollower.GetComponent<SteeringBehaviours>().OffsetPursuitEnabled = true;
            //camFighter.GetComponent<SteeringBehaviours>().PlaneAvoidanceEnabled = true;
            camFollower.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
            SteeringManager.Instance.camFighter = camFollower;
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = camFollower.transform.position;

            return camFollower;
        }

        public virtual void TearDown()
        {
            DestroyObjectsWithTag("obstacle");
            DestroyObjectsWithTag("boid");
            DestroyObjectsWithTag("camFollower");
        }

        public void GroundEnabled(bool enabled)
        {
            GameObject.FindGameObjectWithTag("ground").GetComponent<Renderer>().enabled = enabled;
        }
    }
}