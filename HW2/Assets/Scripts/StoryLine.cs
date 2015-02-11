using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryLine : MonoBehaviour
{
		private string curRoom = "entrance";
		private Sprite background_img;
		private GameObject background;
		private bool examine = false, left = false, right = false, barrel = false,
				hasKey = false, keyPressed = false, puzzleSolved = false, quit = false;
				
		private GameObject key;
		private string order = "";
		private int numQuit = 0;

		void Start ()
		{
				key = new GameObject ();
				key.AddComponent<SpriteRenderer> ().sprite = Resources.Load ("key", typeof(Sprite)) as Sprite;
				key.transform.position = new Vector3 (-10, -118, 345);
				key.transform.localScale = new Vector3 (50, 50, 50);
				key.SetActive (false);

		}
		// Update is called once per frame
		void Update ()
		{
				background = GameObject.Find ("Background");
				string textBuffer = "";

				if (curRoom == "entrance" && !examine) {
						background.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("entrance", typeof(Sprite))as Sprite;
						background.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (49, 49, 49);
						background.GetComponent<SpriteRenderer> ().transform.position = new Vector3 (0, 3, 471);
						key.SetActive (false);
						textBuffer = "You, Adol Christin, are about to explore mystery of darkness and embark on a fateful journey." +
								"\n\nPress [W] :: proceed" +
								"\nPress [E] :: examine environment" +
								"\nPress [Q] :: Quit";
								
			
						if (Input.GetKeyDown (KeyCode.W) && hasKey) {
								curRoom = "lvl1";
						} else if (Input.GetKeyDown (KeyCode.E)) {
								examine = true;
								
						} else if (Input.GetKeyDown (KeyCode.W) && !hasKey) {
								keyPressed = true;
						} else if (Input.GetKeyDown (KeyCode.Q)) {
								quit = true;
								numQuit += 1;
						}
						if (keyPressed && !hasKey) {
								textBuffer += "\n\nThe door is locked.";
						}
						if (quit) {
								textBuffer += "\n\nYou little coward, there is no way to back!";
						}

						
				} else if (curRoom == "lvl1") {
						
						background_img = Resources.Load ("lvl1", typeof(Sprite))as Sprite;
						background.GetComponent<SpriteRenderer> ().sprite = background_img;
						background.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (150, 150, 150);
						
						textBuffer = "You are now in a cage.";
						
						textBuffer += "\n\nPress [W] :: Proceed";
						textBuffer += "\nPress [E] :: examine environment";
						textBuffer += "\nPress [B] :: Go back";

						if (Input.GetKeyDown (KeyCode.B)) {
								curRoom = "entrance";
								background_img = Resources.Load ("entrance", typeof(Sprite))as Sprite;
								background.GetComponent<SpriteRenderer> ().sprite = background_img;
								background.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (49, 49, 49);
						} else if (Input.GetKeyDown (KeyCode.W)) {
								//Debug.LogWarning ("This looks strange");
								keyPressed = true;
						} else if (Input.GetKeyDown (KeyCode.E)) {
								examine = true;
								keyPressed = false;
						}
						if (examine) {
								
								textBuffer = "There are three triggers on the Wall that allows you to pull. " +
										"It seems that without correct order of pulling, you can never open that door.";
								textBuffer += "\n\nPress [A] :: pull left";
								textBuffer += "\nPress [S] :: pull middle";
								textBuffer += "\nPress [D] :: pull right";
								
								if (Input.GetKeyDown (KeyCode.A))
										order += "1";
								if (Input.GetKeyDown (KeyCode.S))
										order += "2";
								if (Input.GetKeyDown (KeyCode.D))
										order += "3";
								if (checkOrder (order)) 
										puzzleSolved = true;

								if (order.Length >= 1) {
										if (order [order.Length - 1] == '1')
												textBuffer += "\n\nLeft trigger pulled";
										if (order [order.Length - 1] == '2')
												textBuffer += "\n\nMiddle trigger pulled";
										if (order [order.Length - 1] == '3')
												textBuffer += "\n\nRight trigger pulled";
								}
						}
						if (puzzleSolved)
								textBuffer += "\n\nDoor unlocked!\nPress [W] :: Proceed";
						if (keyPressed && !puzzleSolved) {
								textBuffer += "\n\nThe door is locked.";
						} else if (keyPressed && puzzleSolved) {
								curRoom = "lvl2";
						}

				} else if (curRoom == "entrance" && examine) {
						textBuffer += "\nWhich part do you want to explore?" +
								"\n\nPress [B] :: Quit Examine" +
								"\nPress [A] :: Left" +
								"\nPress [D] :: Right";
						if (Input.GetKeyDown (KeyCode.A)) {
								left = true;
								if (key.activeSelf)
										key.SetActive (false);
						} else if (Input.GetKeyDown (KeyCode.D)) {
								left = false;
								right = true;
						} else if (Input.GetKeyDown (KeyCode.B)) {
								examine = false;
						}
						if (left == true)
								textBuffer += "\n\nA rusty chain hang on the wall with some blood stain on it.";
						else if (right == true) {
								textBuffer += "\n\nA wooden barrel. Something interesting must be in it.";
								textBuffer += "\n\nPress [E] :: examine.";
								if (Input.GetKeyDown (KeyCode.E)) {
										barrel = true;
								} 
								if (barrel) {
										textBuffer += "\nFound a round Daedric key";
										key.SetActive (true);
										hasKey = true;
								}
						}
				} else if (curRoom == "lvl2") {
						//Debug.LogWarning ("lvl2, yay!");
						background_img = Resources.Load ("lvl2", typeof(Sprite))as Sprite;
						background.GetComponent<SpriteRenderer> ().sprite = background_img;
						background.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (150, 150, 150);
						background.GetComponent<SpriteRenderer> ().transform.position = new Vector3 (0, 52, 799);

						textBuffer = "You finally out of the dungeon. There is nothing there but darkness. But, this is not the end of your journey ...";

						if (numQuit == 0) {
								textBuffer += "\n\n You, brave warrior, didn't want to quit not even once. Well done!" +
										"\n\nTimes that you want to quit: " + numQuit;
						} else if (numQuit <= 5 && numQuit >= 1) {
								textBuffer += "\n\n Well, I guess you just feel nervous. Even though you may want to quit the journey a few times, you still made it." +
										"\n\nTimes that you want to quit: " + numQuit;
						} else {
								textBuffer += "\n\nYou should feel shame to call yourself the warrior." +
										"\n\nTimes that you want to quit: " + numQuit;
						}
						
						textBuffer += "\n\n\n\nPress [C] :: see credit";
						if (Input.GetKeyDown (KeyCode.C)) {
								curRoom = "credit";
						}
				} else if (curRoom == "credit") {
						background.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("lvl3", typeof(Sprite))as Sprite;
						background.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (167, 204, 174);
						background.GetComponent<SpriteRenderer> ().transform.position = new Vector3 (4, 2, 799);
						textBuffer = "wallpoper.com/wallpaper/dungeon-demon-233158" +
								"\n\nstatic.giantbomb.com/uploads/original/0/4109/189149-dungeon.jpg" +
								"\n\ncharterforcompassion.org/sites/default/files/images/the_Forest_church_2_by_weiweihua.jpg" +
								"\n\ncoolvibe.com/wp-content/uploads/2010/06/town-bridge.jpg";

						textBuffer += "\n\n\nPress [Q] :: Quit" +
								"\nPress [R] :: Restart";

						if (Input.GetKeyDown (KeyCode.Q)) {
								Application.Quit ();
						} else if (Input.GetKeyDown (KeyCode.R)) {
								reset ();
						}
				}


				GetComponent<Text> ().text = textBuffer;
		}

		// check the correctness of pulling trigger of the second room.
		bool checkOrder (string order)
		{
				Debug.LogWarning ("order: " + order);
				if (order.Length < 3)
						return false;
				else if (order [order.Length - 1] == '3' && order [order.Length - 2] == '2' && order [order.Length - 3] == '1') {
						return true;
				} else {
						return false;
				}
		}

		void reset ()
		{
				curRoom = "entrance";
				examine = false; 
				left = false;
				right = false;
				barrel = false;
				hasKey = false;
				keyPressed = false;
				puzzleSolved = false;
				quit = false;
				order = "";
				numQuit = 0;
		}
}
