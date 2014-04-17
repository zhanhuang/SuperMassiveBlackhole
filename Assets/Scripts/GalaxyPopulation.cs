using UnityEngine;
using System.Collections;

public class GalaxyPopulation : MonoBehaviour {
	/* PLANET TYPES:
	 * -2: Boss Planet
	 * -1: Starting Planet
	 * 0: None
	 * 1: Hostile Planet
	 * 2: Friendly Planet (Shop)
	 * 3: 
	 */

	public GameObject[,] planetGrid;

	float planetDistance = 300f;
	float planetHeightVariation = 200f;


	// Use this for initialization
	void Start () {
		/* DISTRIBUTION:
		 * Row 0: 1 planet
		 * Row 1: 2-3 planets (3 unlikely)
		 * Row 2: 3-4 planets (4 unlikely)
		 * Row 3: 2-4 planets (4 unlikely)
		 * Row 4: 4-5 planets (5 unlikely)
		 */

		// mark places on a 5x5 matrix to generate planets
		int[,] planetTypeArray = new int[5,5];

		// Populate row 0 and 1
		int startCol = Random.Range(1,4);
		planetTypeArray[0,startCol] = -1; // player starting planet

		planetTypeArray[1,startCol - 1] = 1;
		planetTypeArray[1,startCol] = 1;
		planetTypeArray[1,startCol - 1] = 1;
		
		// remove 1 planet from row 1 ...or not
		int toRemove = Random.Range(-2,2);
		if(toRemove != -2){
			planetTypeArray[1,startCol + toRemove] = 0;
		}

		// Populate row 2 - 4
		for(int r = 2; r < 5; r++){
			toRemove = Random.Range(-1,5);
			int remove2 = Random.Range(0,5);
			int remove3 = Random.Range(0,5);
			for(int c = 0; c < 5; c++){
				if(c != toRemove){
					planetTypeArray[r,c] = 1;
				}
				if(c == remove2 && r < 4){
					planetTypeArray[r,c] = 0;
				} else if(c == remove3 && r == 3){
					planetTypeArray[r,c] = 0;
				}
			}
		}

		// Select an exit planet from last row
		int exit = Random.Range(0,5);
		while(exit == toRemove){
			exit = Random.Range(0,5);
		}
		planetTypeArray[4, exit] = -2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
