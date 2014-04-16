using UnityEngine;
using System.Collections;

public class GalaxyPopulation : MonoBehaviour {
	/* PLANET TYPES:
	 * -3: Row Move Room that's also a starting room
	 * -2: Exit Room
	 * -1: Starting Room
	 * 0: None
	 * 1: Normal Room. Connects to rooms in the same row, and type 2,3 rooms in the previous row
	 * 2: Row Move Room. Connects to next row
	 */

	// Use this for initialization
	void Start () {
		// mark places to generate a room as 1
		int[,] planetTypeArray = new int[4,4];
		int row = 0;
		int col = Random.Range(0,4);
		int rooms;
		
		planetTypeArray[row,col] = -1; // player starting room
		while(row < 4){
			if(planetTypeArray[row,col] == 0){
				planetTypeArray[row,col] = 1;
			}
			int rnd = Random.Range(0,5);
			switch(rnd){
			case 0:
			case 1:
				// go left
				if(col > 0){
					col--;
				}
				break;
			case 2:
			case 3:
				// go right
				if(col < 3){
					col++;
				}
				break;
			case 4:
				// go down
				if(planetTypeArray[row,col] == -1){
					planetTypeArray[row,col] = -3;
				} else{
					planetTypeArray[row,col] = 2;
				}
				row++;
				break;
			}
			if (row == 4){
				// exit
				planetTypeArray[row-1,col] = -2;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
