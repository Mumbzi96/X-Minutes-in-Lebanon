using UnityEngine;

[System.Serializable]
public class PlayerData{
	// MainGame
	public float time;
	public int mainp1Points;
	public int mainp2Points;
	public string mainWinner;
	// Last MiniGame
	public int lastp1Points;
	public int lastp2Points;
	public string lastWinner;
	// Player Related
	public LastPosition lastPosition;
	// public float p1X,p1Y,p1Z;
	// public float p2X,p2Y,p2Z;
	
}

[System.Serializable]
public class LastPosition{
	public float pX,pY,pZ;

	public LastPosition(float x, float y, float z){
		pX=x;
		pY=y;
		pZ=z;
	}
}

