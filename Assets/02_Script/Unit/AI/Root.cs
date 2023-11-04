using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{

    public void Update();

}

public interface ITransition{

    public void Chack();

}
