using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace TrenchcoatRobots.Classes.Components.Colliders {
	class BoxCollider : Collider {
		public Vector2 Size { get; set; }
		public Vector2 Offset { get; set; }

		#region Constructors
		/// <summary>
		/// Creates a new BoxCollider
		/// </summary>
		/// <param name="parent">The GameObject of which the BoxCollider will be placed on</param>
		/// <param name="offset">How the BoxCollider should be offset from the GameObject point of origin</param>
		/// <param name="size">The dimensions of the BoxCollider</param>
		public BoxCollider (GameObject parent, Vector2 offset, Vector2 size)
			: base(parent, "BoxCollider") {
			Size = size;
			Offset = Offset;
		}
		#endregion

		#region Methods
		public bool Collide (Collider other) { //TODO: find a better way to do collsion-handling
			if (other.Type() == "BoxCollider") {
				BoxCollider o = new BoxCollider(other.Parent, new Vector2(), new Vector2());
				if ((o.LeftEdge() > this.LeftEdge() && o.RightEdge() < this.RightEdge()) || (o.TopEdge() > this.TopEdge() && o.BottomEdge() < this.BottomEdge())) {
					return true;
				} else {
					return false;
				}
			}

			return false; //REMINDER: DELETE DIS LAJN OR U WILL WANT 2 KIL URSELF LATR. IS FOR UNIPLEMETND FUNCTIUNS
		}

		#region EdgeMethods
		/// <summary>
		/// Get the left edge of the Collider in local space
		/// </summary>
		/// <returns>The X - coordinate of the left edge in local GameObject space</returns>
		internal override float LeftEdge () {
			return Offset.X - Size.X * 0.5f;
		}
		/// <summary>
		/// Get the right edge of the Collider in local space
		/// </summary>
		/// <returns>The X - coordinate of the right edge in local GameObject space</returns>
		internal override float RightEdge () {
			return Offset.X + Size.X * 0.5f;
		}
		/// <summary>
		/// Get the top edge of the Collider in local space
		/// </summary>
		/// <returns>The Y - coordinate of the top edge in local GameObject space</returns>
		internal override float TopEdge () {
			return Offset.Y - Size.Y * 0.5f;
		}
		/// <summary>
		/// Get the top edge of the Collider in local space
		/// </summary>
		/// <returns>The Y - coordinate of the top edge in local GameObject space</returns>
		internal override float BottomEdge () {
			return Offset.Y + Size.Y * 0.5f;
		}
		#endregion
		#endregion
	}
}
