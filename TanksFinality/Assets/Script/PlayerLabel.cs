using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

/// <summary>
/// This script is attached to the player and it draws the 
/// healthbar of players above them.
/// 
/// This script accesses the HealthAndDamage script for 
/// determining the healthbar length.
/// 
/// This script is accessed by the PlayerName script.
/// </summary>


public class PlayerLabel : NetworkBehaviour {
	
	//Variables Start___________________________________
	
	//The health bar texture is attached to this in the inspector.
	
	public Texture healthTex;
	
	
	//Quick references.
	
	private Camera myCamera;
	
	private Transform myTransform;
	
	//private Transform triggerTransform;
	
	private HealthAndArmor HDScript;
	
	
	//These are used in determining whether the healthbar should be drawn
	//and where on the screen.
	
	private Vector3 worldPosition  = new Vector3();
	
	private Vector3 screenPosition  = new Vector3();
	
	private Vector3 cameraRelativePosition = new Vector3();
	
	private float minimumZ = 1.5f;
	
	
	//These variables are used in defining the health bar.
	
	private int labelTop = 18;
	
	private int labelWidth = 110;
	
	private int labelHeight = 15;
	
	private int barTop = 1;
	
	private int healthBarHeight = 5;
	
	private int healthBarLeft = 110;
	
	private float healthBarLength;
	
	private float adjustment = 1;
	
	
	//Used in displaying the player's name.
	
	public string playerName;
	
	private GUIStyle myStyle = new GUIStyle();

	//Variables End_____________________________________
	
	
	void Awake ()
	{

        //���� ������ ����� �������� ������ ��� ������ ����������.
        //��� �� ����� ��� �������� ��� ������  ������ � ����� ����.

        if (!isLocalPlayer)
        {
            myTransform = transform;
			
			myCamera = Camera.main;
			
			
			//Access the HealthAndDamage script.
			
			//Transform triggerTransform = transform.FindChild("Trigger");
			
			HDScript = GetComponent<HealthAndArmor>();			
			
			
			//The font colour of the GUIStyle depends on which team the 
			//player is on.
			
			if(myTransform.tag == "BlueTeam")
			{
				myStyle.normal.textColor = Color.blue;	
			}
			
			if(myTransform.tag == "RedTeam")
			{
				myStyle.normal.textColor = Color.red;	
			}
			
			myStyle.fontSize = 12;
			
			myStyle.fontStyle = FontStyle.Bold;
			
			
			//Allow the text to extend beyond the width of the label.
			
			myStyle.clipping = TextClipping.Overflow;

        }

        else
        {
            enabled = false;
        }
    }


        // Update is called once per frame
        void Update () 
	{
        //�������� ����� ����� ��� �� �������.

        cameraRelativePosition = myCamera.transform.InverseTransformPoint(myTransform.position);


        //Figure out how long the health bar should be and to avoid a mathematical error set
        //the health bar length to 1 if the the player's health falls below 1.

        if (HDScript.PlayerHealth < 1)
		{
			healthBarLength = 1;	
		}
		
		if(HDScript.PlayerHealth >= 1)
		{
			healthBarLength = (HDScript.PlayerHealth / HDScript.maxPlayerHealth) * 100;	
		}
	}
	
	
	void OnGUI ()
	{
        //Only display the player's name if they are in front of the camera and also the 
        //player should be in front of the camera by at least minimumZ.

        if (cameraRelativePosition.z > minimumZ)
        {
            //Set the world position to be just a bit above the player.

            worldPosition = new Vector3(myTransform.position.x, myTransform.position.y + adjustment,
			                            myTransform.position.z);
			
			//Convert the world position to a point on the screen.
			
			screenPosition = myCamera.WorldToScreenPoint(worldPosition);
			
			
			//Draw the health bar and the grey bar behind it.
			
			GUI.Box(new Rect(screenPosition.x - healthBarLeft / 2, 
			                 Screen.height - screenPosition.y - barTop,
			                 100, healthBarHeight), "");

			GUI.DrawTexture(new Rect(screenPosition.x - healthBarLeft / 2,
			                         Screen.height - screenPosition.y - barTop,
			                         healthBarLength, healthBarHeight), healthTex);		
			
			
			//Draw the player's name above them.
			
			GUI.Label(new Rect(screenPosition.x - labelWidth / 2,
			                   Screen.height - screenPosition.y - labelTop,
			                   labelWidth, labelHeight), playerName, myStyle);

		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
