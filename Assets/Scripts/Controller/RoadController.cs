using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadController : MonoBehaviour, IResponsibility
{
    public GameObject roadParent;

    public bool startedRoad { get; set; }

    public IResponsibility NextIResponsibility { get; set; }

    void Start()
    {
        SetNextResponsibility(FindObjectOfType<CarFactory>());
    }

    public void HandleResponse()
    {
        startedRoad = false;

        if (NextIResponsibility != null)
        {
            NextIResponsibility.HandleResponse();
        }
    }

    public void SetNextResponsibility(IResponsibility nextResponse)
    {
        NextIResponsibility = nextResponse;
    }

    private void Update()
    {
        if (startedRoad == true)
        {
            roadParent.transform.position += new Vector3(0, -0.1f, 0);

            List<Transform> roadsOfParent = roadParent.GetComponentsInChildren<Transform>().ToList();

            roadsOfParent.ForEach(delegate (Transform road)
            {
                if (road.transform.localPosition.y < -12.5f)
                {
                    road.transform.position = roadParent.transform.position += new Vector3(0, 12, 0);
                }
            });
        }
    }
}
