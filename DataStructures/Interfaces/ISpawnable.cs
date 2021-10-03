using System.Threading.Tasks;
using UnityEngine;

namespace XiCore.DataStructures.Interfaces
{
    public interface ISpawnable
    {
        Task<GameObject> Spawn(Vector3 position, Quaternion rotation, object injector);
    }
}