using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrenchcoatRobots.Classes.Components {
	abstract class Collider : Component {
		String m_colliderType;

		/// <summary>
		/// Creates a new Collider
		/// </summary>
		/// <param name="gameObject">The GameObject this component belongs to</param>
		/// <param name="colliderType">The GameObject of which the component will be placed on</param>
		public Collider (GameObject parent, String colliderType)
			: base(parent, "Collider", false) {
			m_colliderType = colliderType;
		}

		#region ChildMethods
		internal virtual float LeftEdge () { return 0f; }
		internal virtual float RightEdge () { return 0f; }
		internal virtual float TopEdge () { return 0f; }
		internal virtual float BottomEdge () { return 0f; }
		#endregion

		public String Type () {
			return m_colliderType;
		}
	}
}
