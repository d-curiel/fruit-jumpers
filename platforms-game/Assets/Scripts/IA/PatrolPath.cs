using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _PatrolPoints = new List<Transform>();
    public int _PatrolLength  { get => _PatrolPoints.Count; }


    public struct PathPoint
    {
        public int Index;
        public Vector2 Position;
    }

    public PathPoint GetClosestPathPosition(Vector2 patrolerPosition)
    {
        var minDistance = float.MaxValue;
        var index = -1;
        for(int i = 0; i < _PatrolPoints.Count; i++)
        {
            var tempDistance = Vector2.Distance(patrolerPosition, _PatrolPoints[i].position);
            if(tempDistance < minDistance)
            {
                minDistance = tempDistance;
                index = i;
            }
        }
        return new PathPoint { Index = index, Position = _PatrolPoints[index].position };
    }

    public PathPoint GetNextPathPoint(int index)
    {
        var newIndex = index + 1 >= _PatrolPoints.Count ? 0 : index + 1;
        return new PathPoint { Index = newIndex, Position = _PatrolPoints[newIndex].position };
    }
}
