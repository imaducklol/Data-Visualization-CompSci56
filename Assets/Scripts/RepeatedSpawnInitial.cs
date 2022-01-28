using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RepeatedSpawnInitial : MonoBehaviour
{
    [SerializeField]
    GameObject agentPrefab;
    
    public Transform endzone0;
    public Transform endzone1;
    public Transform endzone2;
    public Transform endzone3;
    public Transform endzone4;
    public Transform endzone5;

    GameObject[] agents;

    public int agentCount = 1000;
    
    //[System.NonSerialized]
    public int agentsSpawned = 0;
    
    private float percentageIndudstry       = 19.6f;
    private float percentageElectricity     = 18f;
    private float percentageAgriculture     = 15f;
    private float percentageRoadTransport   = 10f;
    private float percentageLandUse         = 9f;
    private float percentageOther           = 28.2f;
    private int toSpawnIndudstry          = 0;
    private int toSpawnElectricity        = 0;
    private int toSpawnAgriculture        = 0;
    private int toSpawnRoadTransport      = 0;
    private int toSpawnLandUse            = 0;
    private int toSpawnOther              = 0;
    private int SpawnedIndudstry            = 0;
    private int SpawnedElectricity          = 0;
    private int SpawnedAgriculture          = 0;
    private int SpawnedRoadTransport        = 0;
    private int SpawnedLandUse              = 0;
    private int SpawnedOther                = 0;

    List<string> potentialSpawn = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        // fill the list
        agents = new GameObject[agentCount];
        
        // calculate agents needed per item
        toSpawnIndudstry     = (int)(agentCount * (percentageIndudstry / 100)); 
        toSpawnElectricity   = (int)(agentCount * (percentageElectricity / 100)); 
        toSpawnAgriculture   = (int)(agentCount * (percentageAgriculture / 100)); 
        toSpawnRoadTransport = (int)(agentCount * (percentageRoadTransport / 100)); 
        toSpawnLandUse       = (int)(agentCount * (percentageLandUse / 100)); 
        toSpawnOther         = (int)(agentCount * (percentageOther / 100)); 
        
        // make sure rounding worked alright
        while (true) {
            if (toSpawnIndudstry + toSpawnElectricity + toSpawnAgriculture + 
            toSpawnRoadTransport + toSpawnLandUse + toSpawnOther < agentCount) {
                toSpawnOther++;
            }
            if (toSpawnIndudstry + toSpawnElectricity + toSpawnAgriculture + 
            toSpawnRoadTransport + toSpawnLandUse + toSpawnOther > agentCount) {
                toSpawnOther--;
            }
            if (toSpawnIndudstry + toSpawnElectricity + toSpawnAgriculture + 
            toSpawnRoadTransport + toSpawnLandUse + toSpawnOther == agentCount) {
                break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int more = 0; more < 5; more++) {
        
        // initialize the gameobjects
        if (agentsSpawned < agents.Length) {
			GameObject agent;
			agent = Instantiate(agentPrefab);
			agent.transform.SetParent(transform, false);
			agents[agentsSpawned] = agent;

            // set its destination
            potentialSpawn.Clear();
            if (SpawnedIndudstry     < toSpawnIndudstry)     {potentialSpawn.Add("Indudstry");}
            if (SpawnedElectricity   < toSpawnElectricity)   {potentialSpawn.Add("Electricity");}
            if (SpawnedAgriculture   < toSpawnAgriculture)   {potentialSpawn.Add("Agriculture");}
            if (SpawnedRoadTransport < toSpawnRoadTransport) {potentialSpawn.Add("RoadTransport");}
            if (SpawnedLandUse       < toSpawnLandUse)       {potentialSpawn.Add("LandUse");}
            if (SpawnedOther         < toSpawnOther)         {potentialSpawn.Add("Other");}
            
            switch(potentialSpawn[Random.Range(0, potentialSpawn.Count)]) {
                case "Indudstry":
                    agents[agentsSpawned].GetComponent<NavMeshAgent>().SetDestination(new Vector3(endzone0.position.x, endzone0.position.y, endzone0.position.z+Random.Range(-2f, 2f)));
                    agents[agentsSpawned].GetComponent<MeshRenderer>().material.color = Color.red;
                    SpawnedIndudstry++;
                    break;
                case "Electricity":
                    agents[agentsSpawned].GetComponent<NavMeshAgent>().SetDestination(new Vector3(endzone1.position.x, endzone1.position.y, endzone1.position.z+Random.Range(-2f, 2f)));
                    agents[agentsSpawned].GetComponent<MeshRenderer>().material.color = Color.blue;
                    SpawnedElectricity++;
                    break;
                case "Agriculture":
                    agents[agentsSpawned].GetComponent<NavMeshAgent>().SetDestination(new Vector3(endzone2.position.x, endzone2.position.y, endzone2.position.z+Random.Range(-2f, 2f)));
                    agents[agentsSpawned].GetComponent<MeshRenderer>().material.color = Color.cyan;
                    SpawnedAgriculture++;
                    break;
                case "RoadTransport":
                    agents[agentsSpawned].GetComponent<NavMeshAgent>().SetDestination(new Vector3(endzone3.position.x, endzone3.position.y, endzone3.position.z+Random.Range(-2f, 2f)));
                    agents[agentsSpawned].GetComponent<MeshRenderer>().material.color = Color.green;
                    SpawnedRoadTransport++;
                    break;
                case "LandUse":
                    agents[agentsSpawned].GetComponent<NavMeshAgent>().SetDestination(new Vector3(endzone4.position.x, endzone4.position.y, endzone4.position.z+Random.Range(-2f, 2f)));
                    agents[agentsSpawned].GetComponent<MeshRenderer>().material.color = Color.magenta;
                    SpawnedLandUse++;
                    break;
                case "Other":
                    agents[agentsSpawned].GetComponent<NavMeshAgent>().SetDestination(new Vector3(endzone5.position.x, endzone5.position.y, endzone5.position.z+Random.Range(-2f, 2f)));
                    agents[agentsSpawned].GetComponent<MeshRenderer>().material.color = Color.yellow;
                    SpawnedOther++;
                    break;
            }
            agentsSpawned++;
		}
        }
    }
}
/*
        // set their destinations
        int destinationCase;
        for (int i = 0; i < agents.Length; i++) {
    		destinationCase = Random.Range(0,100);
            if (destinationCase >= 0  && destinationCase < 20) {
                agents[i].GetComponent<NavMeshAgent>().SetDestination(new Vector3(endzone0.position.x+Random.Range(-2f,2f), endzone0.position.y, endzone0.position.z+Random.Range(-2f, 2f)));
                //agents[i].GetComponent<Material>().SetColor("_Color", Color.red);
                agents[i].GetComponent<MeshRenderer>().material.color = Color.red;
            }
            if (destinationCase >= 20 && destinationCase < 40) {
                agents[i].GetComponent<NavMeshAgent>().SetDestination(endzone1.position);
                agents[i].GetComponent<MeshRenderer>().material.color = Color.green;

            }
            if (destinationCase >= 40 && destinationCase < 60) {
                agents[i].GetComponent<NavMeshAgent>().SetDestination(endzone2.position);
                agents[i].GetComponent<MeshRenderer>().material.color = Color.blue;

            }
            if (destinationCase >= 60 && destinationCase < 100) {
                agents[i].GetComponent<NavMeshAgent>().SetDestination(endzone3.position);
                agents[i].GetComponent<MeshRenderer>().material.color = Color.magenta;

            }
        }
    }
   
    void spawn() 
    {

    }
}
public class AgentControl : MonoBehaviour
{
    public Transform home;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(home.position);
    }

}*/
