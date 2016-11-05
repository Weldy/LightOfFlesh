using UnityEngine;
using System.Collections;
public enum ItemType { Obstacle, Trap, Bonus, Door, Key};
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

       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
