using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode1 : MonoBehaviour {
 
    ParticleSystem ps;
    List<Vector2> lst = new List<Vector2>() {Vector2.zero,Vector2.down,Vector2.left,Vector2.right };
	// Use this for initialization
	void Start () {
        lst = new List<Vector2>() { Vector2.zero, Vector2.down, Vector2.left, Vector2.right,Vector2.up };
        //ps = gameObject.GetComponent<ParticleSystem>();
        //ParticleSystem.MainModule mmo = ps.main;
        //mmo.startColor = Color.green;
        //mmo.playOnAwake = false;
      
        //Student s1 = new Student();
        //Family f1 = s1.Mfamily;
        //f1.Member = "688686";
        Vector2 vector = new Vector2(0,1);
        Vector2 v2 = lst.Find(x=>x.x==0 && x.y==1);
        Debug.Log(v2);
        if (lst.Contains(vector))
        {
            Debug.Log("bbb");
        }
	}
}
public class Student
{
    private Family mfamily;
    public Student()
    {
        mfamily = new Family() { Member = "first" };
    }
    public Family Mfamily { get { return mfamily; } }

}
public struct Family
{
    public string Member { get; set; }
}