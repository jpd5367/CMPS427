﻿using UnityEngine;
using System.Collections;

public class HUD_GUI : MonoBehaviour {

	// Use this for initialization
	public Texture HealthOverlay;
	public Texture HealthLiquid;
	public Texture HealthGlare;
	public Texture Ability1;
	public Texture Ability2;
	public Texture Ability3;
	public Texture Ability4;
	public Texture Ability5;
	public Texture AbilityCoolDown;

	public float Ability1CoolDownTime = .5f;
	public float Ability2CoolDownTime = .5f;
	public float Ability3CoolDownTime = .5f;
	public float Ability4CoolDownTime = .5f;
	public float Ability5CoolDownTime = .5f;

	public GUIStyle AbiltyStyle;

	public GUIStyle infoBoxStyle;

	public Rect AbilitiesOuterBox;
	public Rect AbilityOneBox;
	public Rect AbilityTwoBox;
	public Rect AbilityThreeBox;
	public Rect AbilityFourBox;
	public Rect AbilityFiveBox;

	public float slider;
	public GUIStyle Slider; 
	public GUIStyle thumb; 

	public Vector2 HealthGroupPos;
	public Vector2 HealthGroupSize;
	public Vector2 HealthOverlayPos;
	public Vector2 HealthLiquidPos;
	public Vector2 HealthOverlaySize;
	public Vector2 HealthLiquidSize;


	public float native_width;
	public float native_height;
    public Rect InfoBox1;
    public Rect InfoBox2;

    public Entity player;

	public float health = 0.0f;
	void Start () {
		native_width = Screen.width;
		native_height = Screen.height;

		AbilitiesOuterBox = new Rect(Screen.width * .251f,Screen.height * .90269f, Screen.width *.208385f, Screen.height *.09944f);
		AbilityOneBox = new Rect(Screen.width * .01f,Screen.height * .0f, Screen.width *.03695f, Screen.height *.09f);
		AbilityTwoBox = new Rect(Screen.width * .045854f,Screen.height * .00455f, Screen.width *.038f, Screen.height *.08799f);
		AbilityThreeBox = new Rect(Screen.width * .0875776f,Screen.height * .0f, Screen.width *.036f, Screen.height *.09f);
		AbilityFourBox = new Rect(Screen.width * .1264f,Screen.height * .0f, Screen.width *.03776f, Screen.height *.09f);
		AbilityFiveBox = new Rect(Screen.width * .1646f,Screen.height * .0f, Screen.width *.03776f, Screen.height *.09f);

		HealthOverlayPos.x = 0f;
		HealthOverlayPos.y = 0f;
		HealthOverlaySize.x = Screen.width * .491f;// 300f;//.491f
		HealthOverlaySize.y = Screen.height * .21834f;//100f;//.21834f

		HealthLiquidPos.x = Screen.width * .019399f;//12f;//.019399f
		HealthLiquidPos.y = Screen.height * .21834f;//100f;//.21834f
		HealthLiquidSize.x = Screen.width * .17f;//104f;//.17f
		HealthLiquidSize.y = Screen.height * .1986999f;//91f;//.1986999f

		HealthGroupPos.x = 0f;//
		HealthGroupPos.y = Screen.height * .78f;//358f;//.78f
		HealthGroupSize.x = Screen.width * .491f;//300f;//.491f
		HealthGroupSize.y = Screen.height * .21834f;//100f;//.21834f

        InfoBox1 = new Rect(Screen.width * .5f, Screen.height * .90f, Screen.width * .45f, Screen.height * .1f);
        InfoBox2 = new Rect(Screen.width * .9f, Screen.height * .90f, Screen.width * .45f, Screen.height * .1f);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
	}

	void OnGUI(){

		float rx = Screen.width / native_width;
		float ry = Screen.height / native_height;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0f,0f,0f), Quaternion.identity,new Vector3(rx,ry,1));


		//health = GUI.VerticalSlider(new Rect(10f,10f,20f,50f),health,1f,0f);
        health = (player.currentHP / player.maxHP);

		if(health <0)health = 0f;
		if(health >1)health = 1f;

		GUI.BeginGroup(AbilitiesOuterBox);{//161.9 436, 134.2,48.3
			GUI.DrawTexture(AbilityOneBox,Ability1);//6.44,.03,23.8,43.7

			GUI.DrawTextureWithTexCoords(new Rect(AbilityOneBox.x,//0,
			                                      AbilityOneBox.y + (AbilityOneBox.height * (1f-Ability1CoolDownTime)),//100-(100*health),// this sinks images clipping the bottom
			                                      AbilityOneBox.width,//100f,
			                                      AbilityOneBox.height),//100f),
			                             AbilityCoolDown, // texture
			                             new Rect(0f,
			         Ability1CoolDownTime, // this adjust image to keep stationary
			         1f,
			         1f
			         ));

			GUI.DrawTexture(AbilityTwoBox,Ability2);//29.53,2.2,24.5,42.5

			GUI.DrawTextureWithTexCoords(new Rect(AbilityTwoBox.x,//0,
			                                      AbilityTwoBox.y + (AbilityTwoBox.height * (1f-Ability2CoolDownTime)),//100-(100*health),// this sinks images clipping the bottom
			                                      AbilityTwoBox.width,//100f,
			                                      AbilityTwoBox.height),//100f),
			                             AbilityCoolDown, // texture
			                             new Rect(0f,
			         Ability2CoolDownTime, // this adjust image to keep stationary
			         1f,
			         1f
			         ));

			GUI.DrawTexture(AbilityThreeBox,Ability3);//56.4,0,23.3,43.7

			GUI.DrawTextureWithTexCoords(new Rect(AbilityThreeBox.x,//0,
			                                      AbilityThreeBox.y + (AbilityThreeBox.height * (1f-Ability3CoolDownTime)),//100-(100*health),// this sinks images clipping the bottom
			                                      AbilityThreeBox.width,//100f,
			                                      AbilityThreeBox.height),//100f),
			                             AbilityCoolDown, // texture
			                             new Rect(0f,
			         Ability3CoolDownTime, // this adjust image to keep stationary
			         1f,
			         1f
			         ));


			GUI.DrawTexture(AbilityFourBox,Ability4);//81.4,0,24.32,43.7

			GUI.DrawTextureWithTexCoords(new Rect(AbilityFourBox.x,//0,
			                                      AbilityFourBox.y + (AbilityFourBox.height * (1f-Ability4CoolDownTime)),//100-(100*health),// this sinks images clipping the bottom
			                                      AbilityFourBox.width,//100f,
			                                      AbilityFourBox.height),//100f),
			                             AbilityCoolDown, // texture
			                             new Rect(0f,
			         Ability4CoolDownTime, // this adjust image to keep stationary
			         1f,
			         1f
			         ));


			GUI.DrawTexture(AbilityFiveBox,Ability5);//106,0,26.4,44
			
			GUI.DrawTextureWithTexCoords(new Rect(AbilityFiveBox.x,//0,
			                                      AbilityFiveBox.y + (AbilityFiveBox.height * (1f-Ability5CoolDownTime)),//100-(100*health),// this sinks images clipping the bottom
			                                      AbilityFiveBox.width,//100f,
			                                      AbilityFiveBox.height),//100f),
			                             AbilityCoolDown, // texture
			                             new Rect(0f,
			         Ability5CoolDownTime, // this adjust image to keep stationary
			         1f,
			         1f
			         ));

			
			
		}GUI.EndGroup();



		GUI.BeginGroup(new Rect(HealthGroupPos.x,//100,
		                        HealthGroupPos.y,//100,
		                        HealthGroupSize.x,//100,
		                        HealthGroupSize.y//100
		                        ));{
			GUI.DrawTextureWithTexCoords(new Rect(HealthLiquidPos.x,//0,
			                                      HealthLiquidPos.y - (HealthLiquidSize.y * health),//100-(100*health),// this sinks images clipping the bottom
			                                      HealthLiquidSize.x,//100f,
			                                      HealthLiquidSize.y),//100f),
			                             		  HealthLiquid, // texture
			                            new Rect(0f,
			                                     health, // this adjust image to keep stationary
			                                     1f,
			                                     1f
			         ));

		

			GUI.DrawTexture(new Rect(HealthOverlayPos.x,//0f,
			                         HealthOverlayPos.y,//0f
			                         HealthOverlaySize.x,//200f,
			                         HealthOverlaySize.y),//100f),
			                 		 HealthOverlay);// texture





			GUI.DrawTexture(new Rect(HealthOverlayPos.x,//0f,
			                         HealthOverlayPos.y,//0f
			                         HealthOverlaySize.x,//200f,
			                         HealthOverlaySize.y),//100f),
			                HealthGlare);// texture

		
		
		}GUI.EndGroup();
		GUI.backgroundColor = Color.green;
        //GUI.color = Color.white;
        infoBoxStyle.normal.textColor = Color.white;
        string attackList = "Q = Cleave \n"
                          + "W = Fud Ro Dah \n"
                          + "E = Hadouken \n"
                          + "R = Deathgrip \n";

        string version = "Week5v1";

        GUI.Label(InfoBox1, attackList, infoBoxStyle);
        GUI.Label(InfoBox2, version, infoBoxStyle);

	}
}
