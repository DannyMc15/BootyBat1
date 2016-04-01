﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonState{
	public bool value;
	public float holdTime = 0;
}

public enum Directions{
	Right = 1,
	Left = -1
}

public class PlayerScore{
	public int playerScore = 0;
}

public class InputState : MonoBehaviour {

	public Directions direction = Directions.Right;

	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();

	public void SetButtonValue(Buttons key, bool value){
        if (!buttonStates.ContainsKey(key))
            buttonStates.Add(key, new ButtonState());//revisit tutorial and check ai controller vs. player controller

		var state = buttonStates [key];

		if (state.value && !value) {
			state.holdTime = 0;
		} else if (state.value && value) {
			state.holdTime += Time.deltaTime;
		}

		state.value = value;
	}

	public bool GetButtonValue(Buttons key){
		if (buttonStates.ContainsKey (key))
			return buttonStates [key].value;
		else
			return false;
	}

    public float GetButtonHoldTime(Buttons key)
    {
        if (buttonStates.ContainsKey(key))
            return buttonStates[key].holdTime;
        else
            return 0;
    }
}