//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//
//public class SceneController : MonoBehaviour {
//
//	public Text textField;
//	public Rigidbody MeditationBall;
//	public Rigidbody AttentionBall;
//
//
//	ThinkGearController controller;
//	int PoorSignal;
//	int Attention;
//	int Meditation;
//	float AttentionSmoothed;
//	float MeditationSmoothed;
//
//	float map(float s, float a1, float a2, float b1, float b2)
//	{
//		return b1 + (s-a1)*(b2-b1)/(a2-a1);
//	}
//
//	// Use this for initialization
//	void Start () {
//		UnityThinkGear.ScanDevice();
//
//		controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();
//
//		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
//		controller.UpdateAttentionEvent += OnUpdateAttention;
//		controller.UpdateMeditationEvent += OnUpdateMeditation;
//		controller.UpdateDeviceInfoEvent += OnUpdateDeviceInfo;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		string signal = "";
//		if(PoorSignal == 0){
//			signal = "Good";
//		} else if(PoorSignal == 200){
//			signal = "Okay";
//		} else {
//			signal = "Poor";
//		}
//
//		textField.text = "Signal: " + signal + "\n"
//			+ "Attention: " + AttentionSmoothed + "\n"
//			+ "Meditation: " + MeditationSmoothed;
//
//		AttentionSmoothed = Mathf.Lerp (AttentionSmoothed, Attention, Time.deltaTime * 2.0F);
//		MeditationSmoothed = Mathf.Lerp (MeditationSmoothed, Meditation, Time.deltaTime * 2.0F);
//
//		float fAttention = map (AttentionSmoothed, 10, 60, 3, 15);
////		AttentionBall.AddForce (new Vector3 (0, fAttention, 0), ForceMode.Acceleration);
//		AttentionBall.transform.position = new Vector3 (0, 1.7f, fAttention);
//
//		float fMeditation = map (MeditationSmoothed, 10, 60, 3, 15);
////		MeditationBall.AddForce (new Vector3 (0, fMeditation, 0), ForceMode.Acceleration);
//		MeditationBall.transform.position = new Vector3 (0, 1.7f, fMeditation);
//	}
//
//
//	void OnUpdatePoorSignal(int value){
//		PoorSignal = value;
//	}
//
//	void OnUpdateAttention(int value){
//		Attention = value;
//	}
//
//	void OnUpdateMeditation(int value){
//		Meditation = value;
//	}
//
//	void OnUpdateDeviceInfo(string deviceInfo){
//		// FMGID ; name ; ConnectId
//		string mfgid = deviceInfo.Split(";"[0])[0];
//		string name = deviceInfo.Split(";"[0])[1];
//		string deviceId = deviceInfo.Split(";"[0])[2];
//		Debug.Log("OnUpdateDeviceInfo  mfgid : "+mfgid + " name: "+name+" deviceId: "+deviceId);
//
//		UnityThinkGear.ConnectDevice(deviceId);
//		UnityThinkGear.StartStream ();
//	}
//}
