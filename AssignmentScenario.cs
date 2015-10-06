using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.Scenarios
{
	public class AssignmentScenario : Scenario 
	{
		public override string Description()
        {
            return "Assignment Demo";
        }
        static Vector3 initialPos = Vector3.zero;

		public Vector3 reavers_forward = new Vector3(0,0,1000);

        public override void Start()
        {
            Params.Load("default.txt");

            leader = CreateBoid(new Vector3(0,0,0), leaderPrefab);
			leader.tag = "leader";

            if (initialPos == Vector3.zero)
            {
                initialPos = leader.transform.position;
            }
            Path path = leader.GetComponent<SteeringBehaviours>().path;
            leader.GetComponent<SteeringBehaviours>().path.Waypoints.Add(initialPos);
            path.Waypoints.Add(initialPos + new Vector3(0, 0, 100));
            path.Waypoints.Add(initialPos + new Vector3(0, 0, 180));
			path.Waypoints.Add(initialPos + new Vector3(0, 2, 200));
			path.Waypoints.Add(initialPos + new Vector3(0, 0, 210));
			path.Waypoints.Add(initialPos + new Vector3(8, 0, 220));
			path.Waypoints.Add(initialPos + new Vector3(0, -5, 235));
			path.Waypoints.Add(initialPos + new Vector3(0, 0, 250));
			path.Waypoints.Add(initialPos + new Vector3(5, 0, 260));
			path.Waypoints.Add(initialPos + new Vector3(0, 0, 280));
			//past the mist
			path.Waypoints.Add(initialPos + new Vector3(0, 0, 900));
			path.Waypoints.Add(initialPos + new Vector3(0, -7, 910));
			path.Waypoints.Add(initialPos + new Vector3(0, -10, 950));
			path.Waypoints.Add(initialPos + new Vector3(0, -6, 1000));
			path.Waypoints.Add(initialPos + new Vector3(0, 0, 1050));
			path.Waypoints.Add(initialPos + new Vector3(-5, -15, 1075));
			path.Waypoints.Add(initialPos + new Vector3(0, -18, 1100));
			path.Waypoints.Add(initialPos + new Vector3(0, -18, 1175));
			path.Waypoints.Add(initialPos + new Vector3(0, 10, 1185));
			//loop
			path.Waypoints.Add(initialPos + new Vector3(0, 20, 1175));
			path.Waypoints.Add(initialPos + new Vector3(0, 15, 1155));
			path.Waypoints.Add(initialPos + new Vector3(0, 10, 1160));
			path.Waypoints.Add(initialPos + new Vector3(0, 15, 1185));
			//end loop
			path.Waypoints.Add(initialPos + new Vector3(0, 15, 1400));

            

            path.Looped = false;
            path.draw = true;
            leader.GetComponent<SteeringBehaviours>().TurnOffAll();
            leader.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
            leader.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = false;


			//obstacle ships
			fleet_Obs1 = CreateBoid(new Vector3(-62,25,246), boidPrefab);
			fleet_Obs2 = CreateBoid(new Vector3(-44,29,218), boidPrefab);
			fleet_Obs3 = CreateBoid(new Vector3(-60,24,198), boidPrefab);
			fleet_Obs4 = CreateBoid(new Vector3(13,-1,278), boidPrefab);
			fleet_Obs5 = CreateBoid(new Vector3(-12,11,239), boidPrefab);
			fleet_Obs6 = CreateBoid(new Vector3(20,-3,243), boidPrefab);
			fleet_Obs7 = CreateBoid(new Vector3(-3,10,278), boidPrefab);
			fleet_Obs8 = CreateBoid(new Vector3(-1, -4, 188), boidPrefab);

			//scale the obstacle ships up
			fleet_Obs1.transform.localScale = new Vector3(1,1,1);
			fleet_Obs2.transform.localScale = new Vector3(1,1,1);
			fleet_Obs3.transform.localScale = new Vector3(1,1,1);
			fleet_Obs4.transform.localScale = new Vector3(1,1,1);
			fleet_Obs5.transform.localScale = new Vector3(1,1,1);
			fleet_Obs6.transform.localScale = new Vector3(1,1,1);
			fleet_Obs7.transform.localScale = new Vector3(1,1,1);
			fleet_Obs8.transform.localScale = new Vector3(1,1,1);



			//Fleet right creation
			fleetR1 = CreateBoid(new Vector3(UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(50,-50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetR2 = CreateBoid(new Vector3(UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(50,-50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetR3 = CreateBoid(new Vector3(UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(50,-50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetR4 = CreateBoid(new Vector3(UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(50,-50),UnityEngine.Random.Range(150,300)), boidPrefab);

			//Fleet left creation
			fleetL1 = CreateBoid(new Vector3(UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetL2 = CreateBoid(new Vector3(UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetL3 = CreateBoid(new Vector3(UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetL4 = CreateBoid(new Vector3(UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(150,300)), boidPrefab);

			//Fleet Up creation
			fleetU1 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetU2 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetU3 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetU4 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(150,300)), boidPrefab);

			//Fleet Down creation
			fleetD1 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetD2 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetD3 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(150,300)), boidPrefab);
			fleetD4 = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(150,300)), boidPrefab);


			for(int i = 0; i < 1; i++)
			{
				for(int j =0; j< 2; j++)
				{
					alliance = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(900,1200)), AlliancePrefab);
				}

				for(int j =0; j< 2; j++)
				{
					alliance = CreateBoid(new Vector3(UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(900,1200)), AlliancePrefab);
				}
				for(int j =0; j< 2; j++)
				{
					alliance = CreateBoid(new Vector3(UnityEngine.Random.Range(-20,-50),UnityEngine.Random.Range(-50,50),UnityEngine.Random.Range(900,1200)), AlliancePrefab);
				}
				for(int j =0; j< 2; j++)
				{
					alliance = CreateBoid(new Vector3(UnityEngine.Random.Range(20,50),UnityEngine.Random.Range(50,-50),UnityEngine.Random.Range(900,1200)), AlliancePrefab);
				}
	
			}


            CreateCamFollower(leader, new Vector3(0, 5, -10));

            GroundEnabled(true);

        }

		/*public virtual void Update()
		{
			if(leader.transform.position.z >= 100)
			{
				//Application.LoadLevel("Scene2");

				fleet.GetComponent<SteeringBehaviours>().SeekEnabled = true;
				//fleet.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
				fleet.GetComponent<SteeringBehaviours>().seekTargetPos = fleet.transform.position + reavers_forward;

			}
		}*/
	}
}
