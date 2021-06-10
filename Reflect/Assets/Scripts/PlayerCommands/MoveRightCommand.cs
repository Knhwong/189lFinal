using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MoveRightCommand : ScriptableObject, IPlayerCommand
    {
        public void Execute(GameObject gameObject, float detail)
        {
            gameObject.transform.position += new Vector3(detail, 0.0f, 0.0f);
        }
    }
}