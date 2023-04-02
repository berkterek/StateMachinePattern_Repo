using UnityEngine;

public interface IMover
{
    void SetDestination(Transform transform);
    void Stop();
}