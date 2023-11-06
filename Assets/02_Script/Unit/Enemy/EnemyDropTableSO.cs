using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/DropTable")]
public class EnemyDropTableSO : ScriptableObject
{

    public List<ItemObject> dropItems = new();

}
