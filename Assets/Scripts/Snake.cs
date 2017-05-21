using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public bool ShowGizmos = true;
    public float InitialSpeed = 1f;
    public int NumberOfBalls = 10;
    public List<Vector3> Path;

    private List<GameObject> figures;
    private System.Random _random;

	// Use this for initialization
	void Awake () {

	    if (Path == null || Path.Count <2)
	    {
	        return;
	    }
	    _random = new System.Random();
	    figures = new List<GameObject>();

	    CreateObject();
	}

    private void CreateObject()
    {
        var type = _random.Next(2);
        var resource = ((FigureType) type).GetFigureResourceName();
        var sphere = Resources.Load(resource) as GameObject;
        var obj = Instantiate(sphere);

        obj.name = "Figure";
        obj.transform.localPosition = Path.First();
        obj.AddComponent<Figure>();
        var script = obj.GetComponent<Figure>();
        script.CurrentTarget += Path[1];
        script.Speed = InitialSpeed;
        script.TargetAchieved = fig =>
        {
            var next = Path.SkipWhile(i => i != fig.CurrentTarget).Skip(1).FirstOrDefault();
            if (next == null)
            {
                return;
            }

            fig.CurrentTarget = next;
        };

        figures.Add(obj);
    }

    // Update is called once per frame
	void Update () {
	  
	}

    void OnDrawGizmos()
    {
        if (!ShowGizmos || Path==null)
        {
            return;
        }
        Gizmos.color = Color.green;
        
        for (var i = 0; i < Path.Count-1; i++)
        {
            Gizmos.DrawLine(Path[i], Path[i+1]);
        }
    }
}
