using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexAlternative : Index
{
    protected override void LoadPage(int page)
    {
        _sceneTransition.StartSceneTransition((page+1).ToString());
    }
}
