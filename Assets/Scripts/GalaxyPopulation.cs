using UnityEngine;
using System.Collections;

public class GalaxyPopulation : MonoBehaviour {
	GameObject player;
	GameObject planet;
	
	GameObject startingPlanet;


	int[,] planetTypeArray = new int[5,5];
	public GameObject[,] planetGrid = new GameObject[5,5];

	// loading textures here since resource.load is costly
	Material[] planetMats = new Material[10];

	float planetDistance = 800f;
	float planetHeightVariation = 400f;


	// Use this for initialization
	void Start () {
		// Load Prefabs
		player = (GameObject)Resources.Load("Player");
		planet = (GameObject)Resources.Load("Planet");
		
		// Load Planet Textures
		planetMats[0] = Resources.Load("Material_Earth") as Material; 
		planetMats[1] = Resources.Load("Material_Trask") as Material; 
		planetMats[2] = Resources.Load("Material_CercaTrova") as Material; 
		planetMats[3] = Resources.Load("Material_Hoth") as Material; 
		planetMats[4] = Resources.Load("Material_Terminus") as Material; 
		planetMats[5] = Resources.Load("Material_Blink") as Material; 
		planetMats[6] = Resources.Load("Material_DamBaDa") as Material; 
		planetMats[7] = Resources.Load("Material_Jinx") as Material; 
		planetMats[8] = Resources.Load("Material_Telos") as Material; 
		planetMats[9] = Resources.Load("Material_Seredipity") as Material; 

		// figure out where we want to have planets
		MarkPlanetTypes();

		// CREATE PLANETS
		// Axis: Rows -- X+ ; Columns -- Z+
		for(int r = 0; r < 5; r++){
			for(int c = 0; c < 5; c++){
				if(planetTypeArray[r,c] == 0){
					// no planet, skip over
					continue;
				}
				Vector3 nextLocation = new Vector3(planetDistance * r, Random.Range(-planetHeightVariation, planetHeightVariation), planetDistance * c);
				GameObject nextPlanet = Instantiate(planet, nextLocation, Quaternion.identity) as GameObject;
				PlanetPopulation nextPlanetScript = nextPlanet.GetComponent<PlanetPopulation>();
				nextPlanetScript.planetType = planetTypeArray[r,c];
				nextPlanetScript.planetRow = r;
				nextPlanetScript.planetCol = c;
				nextPlanetScript.GenerateBase();

				// set textures
				switch(planetTypeArray[r,c]){
				case -1:
					// starting planet, earth texture
					nextPlanet.GetComponent<MeshRenderer>().material = planetMats[0];
					startingPlanet = nextPlanet;
//					nextPlanetScript.avoidTest();
					nextPlanetScript.ActivateBeam();
					nextPlanetScript.ShowBeam();
					break;
				case -2:
					// ending planet, Seredipity texture
					nextPlanet.GetComponent<MeshRenderer>().material = planetMats[9];
					nextPlanetScript.ActivateBeam();

//					// testing purposes. start at the last planet
//					startingPlanet = nextPlanet;
//					nextPlanetScript.PopulatePlanet();
					break;
				case 2:
					// friendly planet, no ships or turrets
					nextPlanetScript.ActivateBeam();
					nextPlanetScript.HideBeam();
					goto default;
				case 3:
					nextPlanet.transform.FindChild("Outline").renderer.material.SetColor("_Color", new Color(1f, 0.5f, 0f));
					goto default;
				default:
					// other planet
					nextPlanet.GetComponent<MeshRenderer>().material = planetMats[Random.Range(1,9)];
					break;
				}

				planetGrid[r,c] = nextPlanet;
			}
		}

		// CREATE PLAYER
		GameObject thePlayer = Instantiate(player, startingPlanet.transform.position + new Vector3(0f,200f,-100f), Quaternion.identity) as GameObject;
		PlayerShipController playerCtrl =  thePlayer.transform.GetComponent<PlayerShipController>();
		playerCtrl.Galaxy = this;
		playerCtrl.currentPlanet = startingPlanet;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// check all 8 accessible places on grid and return a list of planets
	public GameObject[] GetSurroundingPlanets(PlanetPopulation currentPlanet){
		GameObject[] planets = new GameObject[8];
		int currentRow = currentPlanet.planetRow;
		int currentCol = currentPlanet.planetCol;
		int next = 0;

		if(currentRow < 4){
			if(currentCol < 4){
				if(planetGrid[currentRow + 1, currentCol + 1] != null){
					planets[next] = planetGrid[currentRow + 1, currentCol + 1];
					next ++;
				}
			}
			if(planetGrid[currentRow + 1, currentCol] != null){
				planets[next] = planetGrid[currentRow + 1, currentCol];
				next ++;
			}
			if(currentCol > 0){
				if(planetGrid[currentRow + 1, currentCol - 1] != null){
					planets[next] = planetGrid[currentRow + 1, currentCol - 1];
					next ++;
				}
			}
		}
		if(currentCol > 0){
			if(planetGrid[currentRow, currentCol - 1] != null){
				planets[next] = planetGrid[currentRow, currentCol - 1];
				next ++;
			}
		}
		if(currentRow > 0){
			if(currentCol > 0){
				if(planetGrid[currentRow - 1, currentCol - 1] != null){
					planets[next] = planetGrid[currentRow - 1, currentCol - 1];
					next ++;
				}
			}
			if(planetGrid[currentRow - 1, currentCol] != null){
				planets[next] = planetGrid[currentRow - 1, currentCol];
				next ++;
			}
			if(currentCol < 4){
				if(planetGrid[currentRow - 1, currentCol + 1] != null){
					planets[next] = planetGrid[currentRow - 1, currentCol + 1];
					next ++;
				}
			}
		}
		if(currentCol < 4){
			if(planetGrid[currentRow, currentCol + 1] != null){
				planets[next] = planetGrid[currentRow, currentCol + 1];
				next ++;
			}
		}

		return planets;
	}

	void MarkPlanetTypes (){
		/* PLANET TYPES:
		 * -2: Boss Planet
		 * -1: Starting Planet
		 * 0: None
		 * 1: Hostile Planet
		 * 2: Friendly Planet (Shop)
		 * 3: 
		 */

		/* DISTRIBUTION:
		 * Row 0: 1 planet
		 * Row 1: 2-3 planets (3 unlikely)
		 * Row 2: 3-4 planets (4 unlikely)
		 * Row 3: 2-4 planets (4 unlikely)
		 * Row 4: 4-5 planets (5 unlikely)
		 */
		
		// Populate row 0 and 1
		int startCol = Random.Range(1,4);
		planetTypeArray[0,startCol] = -1; // player starting planet
		
		planetTypeArray[1,startCol - 1] = 1;
		planetTypeArray[1,startCol] = 1;
		planetTypeArray[1,startCol + 1] = 1;
		
		// remove 1 planet from row 1 ...or not
		int toRemove = Random.Range(-2,2);
		if(toRemove != -2){
			planetTypeArray[1,startCol + toRemove] = 0;
		}
		
		// Populate row 2 - 4
		for(int r = 1; r < 4; r++){
			// start from previous row
			int rowPlanetCount = 0;
			// mark all reachable spots in next row as planet
			for(int c = 0; c < 5; c++){
				if(planetTypeArray[r,c] == 1){
					// left
					if(c != 0){
						if(planetTypeArray[r+1,c-1] == 0){
							planetTypeArray[r+1,c-1] = 1;
							rowPlanetCount++;
						}
					}
					// middle
					if(planetTypeArray[r,c] == 0){
						planetTypeArray[r+1,c] = 1;
						rowPlanetCount++;
					}
					// right
					if(c != 4){
						if(planetTypeArray[r+1,c+1] == 0){
							planetTypeArray[r+1,c+1] = 1;
							rowPlanetCount++;
						}
					}
				}
			}
			// if too many planets in row, delete some
			for(int k = 0; k < (rowPlanetCount - (r + 2)); k++){
				planetTypeArray[r+1,Random.Range(0,5)] = 0;
			}
		}
		
		// Select an exit planet from last row
		bool validExit = false;
		int exit;
		do{
			exit = Random.Range(0,5);
		} while(planetTypeArray[4,exit] == 0);
		planetTypeArray[4, exit] = -2;

		
		/* SPECIFIC TYPES:
		 * 1 - Hostile: Enemies, clear to move on
		 * 2 - Friendly: Shop, free to move on
		 * 3 - Conflicting: many Enemies and few Allies, clear with at least 1 ally remaining to unlock shop
		 */
		int totalCount = 0;
		int friendlyCount = 0;
		int conflictingCount = 0;
		for(int r = 1; r < 5; r++){
			for(int c = 0; c < 5; c++){
				if(planetTypeArray[r, c] == 1){
					int specificType = Random.Range(-1,4);
					if(specificType < 1){
						if(friendlyCount == 0 && totalCount >= 6){
							// too few friendlies
							specificType = 2;
							friendlyCount ++;
						} else{
							specificType = 1;
						}
					} else if(specificType == 2){
						// friendly
						if(friendlyCount >= 2 || (friendlyCount == 1 && totalCount < 6)){
							// too many friendlies, turn into hostile
							specificType = 1;
						} else{
							friendlyCount ++;
						}
					} else{
						// conflicting
						if(conflictingCount >= 3 || (conflictingCount >= 2 && totalCount < 6)){
							// too many conflicting, turn into hostile
							specificType = 1;
						} else{
							conflictingCount ++;
						}
					}
					planetTypeArray[r, c] = specificType;
					totalCount ++;
				} // end if(planetTypeArray[r, c] == 1)
			}
		}

	}
}
