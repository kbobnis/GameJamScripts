using UnityEngine;
using System.Collections;
using System;

public static class ActionExtension {

	public static bool SaveInvoke(this Action a) {
		if (a != null) {
			a();
			return true;
		}
		return false;
	}

	public static bool SaveInvoke<T>(this Action<T> a, T arg) {
		if (a != null) {
			a(arg);
			return true;
		}
		return false;
	}

}
