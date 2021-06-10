using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class JumpCommand : ScriptableObject, IPlayerCommand
    {
        public void Execute(GameObject gameObject, float jumpForce)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}