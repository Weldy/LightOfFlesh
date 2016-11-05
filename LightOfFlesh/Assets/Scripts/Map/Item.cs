using UnityEngine;
using System.Collections;
public enum ItemType { Obstacle, Trap, Bonus};
public  class Item : MonoBehaviour {

    [SerializeField]
    private Vector2 position;
    public Vector2 Position
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }
    public ItemType itemType;
	// Use this for initialization
	void Start () {

        //TODO truc à mettre
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
