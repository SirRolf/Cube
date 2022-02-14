using UnityEngine;

namespace Flor.Behaviours.Player.Movement
{
	public class PlayerMovementBehaviour : MonoBehaviour
	{
		private void Update()
		{
			const string horizontal = "Horizontal";
			Debug.Log(Input.GetAxis(horizontal));
		}
	}
}
