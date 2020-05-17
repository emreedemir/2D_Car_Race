using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResponsibility
{

    IResponsibility NextIResponsibility { get; set; }

    void SetNextResponsibility(IResponsibility nextResponse);

    void HandleResponse();
}
