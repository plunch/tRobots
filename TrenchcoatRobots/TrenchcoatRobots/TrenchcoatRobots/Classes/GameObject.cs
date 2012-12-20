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

namespace TrenchcoatRobots.Classes {
	class GameObject {
		#region Properties
		public Vector2 Position { get; set; }
		public float Angle { get; set; }
		public bool Active { get; set; }
		public List<Classes.Component> Components { get; set; }
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new GameObject with position and Angle.
		/// </summary>
		/// <param name="position">Position of the GameObject</param>
		/// <param name="Angle">Angle of the GameObject</param>
		public GameObject (Vector2 position, float Angle) {
			this.Position = position;
			this.Angle = Angle;
			this.Active = true;
		}
		/// <summary>
		/// Creates a new GameObject with Angle. Position will be 0,0.
		/// </summary>
		/// <param name="Angle">The Angle of the GameObject</param>
		public GameObject (float Angle) {
			this.Position = new Vector2();
			this.Angle = Angle;
			this.Active = true;
		}
		/// <summary>
		/// Creates a new GameObject with position. Angle will be 0.
		/// </summary>
		/// <param name="position">Position of the GameObject</param>
		public GameObject (Vector2 position) {
			this.Position = position;
			this.Angle = 0;
			this.Active = true;
		}
		/// <summary>
		/// Creates a new GameObject. Position will be 0,0 and Angle will be 0
		/// </summary>
		public GameObject () {
			this.Position = new Vector2();
			this.Angle = 0;
			this.Active = true;
		}
		#endregion

		#region Methods
		public virtual void Update (GameTime gameTime) {
			foreach (Classes.Component comp in Components) {
				comp.Update(gameTime);
			}
		}

		#region Component Altering
		/// <summary>
		/// Adds a component to the GameObject
		/// </summary>
		/// <param name="component">The component to add.</param>
		public void AddComponent (Classes.Component component) {
			if (component.Single) {
				foreach (Classes.Component comp in Components) {
					if (component.GetType() == comp.GetType()) {
						Debug.Print("ERROR: Only one component of type " + component.ToString() + " is allowed per GameObject.");
						break;
					}
				}
			}
			Components.Add(component);
		}

		/// <summary>
		/// Replaces an already existing component. The component must be of a limited type.
		/// </summary>
		/// <param name="component">The object to use as an replacement.</param>
		public void ReplaceComponent (Classes.Component component) {
			if (component.Single) {
				int index = -1;
				for (int i = 0; i < Components.Count; i++) {
					if (component.GetType() == Components[i].GetType()) {
						index = i;
						break;
					}
				}
				if (index != -1)
					Components.RemoveAt(index);
				Components.Add(component);
			} else {
				Debug.Print("ERROR: Specified component is not of a limited type.");
			}
		}
		#endregion

		public virtual void Draw (SpriteBatch spriteBatch) {
			foreach (Classes.Component comp in Components) {
				comp.Draw(spriteBatch);
			}
		}
		#endregion
	}
}
