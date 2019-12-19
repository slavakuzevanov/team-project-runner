using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForToggles : MonoBehaviour {
//	public Button isStandard;
//	public Button isAlt;
//	public Button isButton;
//	void start()
//	{
//		if (Global.control == 1) {
//			isStandard.isOn = true;
//			isAlt.isOn = false;
//			isButton.isOn = false;
//		}
//		else
//			if(Global.control == 2)
//				isAlt.isOn = true;
//			else
//				if(Global.control == 3)
//					isButton.isOn = true;
//
//	}
//	void update()
//	{
//		if (Global.control == 1) {
//			isStandard.isOn = true;
//			isAlt.isOn = false;
//			isButton.isOn = false;
//		}
//		else
//			if(Global.control == 2)
//				isAlt.isOn = true;
//			else
//				if(Global.control == 3)
//					isButton.isOn = true;
//			
//	}
//	public void ActiveToggle()
//	{
//		if (isStandard.isOn) 
//		{
//			Global.control = 1;
//		isStandard.isOn = true;
//isAlt.isOn = false;
//	isButton.isOn = false;
//		}
//		if (isAlt.isOn) 
//		{
//			Global.control = 2;
//
//		}
//		if (isButton.isOn) 
//		{
//			Global.control = 3;
//		}
//
//	}
		
	public void SelectControlclassic()
	{
		Global.control = 1;
	}
	public void SelectControlalt()
	{
		Global.control = 2;
	}
	public void SelectControlbuttons()
	{
		Global.control = 0;
	}
}
