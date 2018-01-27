using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CreatureBuff {

	void attach (PlayerControllerScript player);
	void detach (PlayerControllerScript player);
	void action (PlayerControllerScript player);
}
