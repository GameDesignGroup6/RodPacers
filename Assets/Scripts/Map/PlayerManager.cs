﻿using UnityEngine;
using System.Collections;

public static class PlayerManager {
	public static int playerCount;
	public static int[] podSkins;

	static PlayerManager(){
		podSkins = new int[4];
	}
}