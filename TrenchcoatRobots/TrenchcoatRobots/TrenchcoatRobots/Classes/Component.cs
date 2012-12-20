using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TrenchcoatRobots.Classes {
	abstract class Component {
		internal GameObject m_parent; //Internal parent object to enable access of the parent object by inherited classes
		private bool m_single;
		public bool Single { get { return m_single; } }
		public GameObject Parent { get { return m_parent; } }
		string Type { get; set; }

		/// <summary>
		/// Creates a new Component/object
		/// </summary>
		/// <param name="parent">The GameObject of which the component will be placed on</param>
		/// <param name="type">The type of the component</param>
		public Component (GameObject parent, string type, bool single) {
			m_parent = parent;
			m_single = single;
			Type = type;
		}

		#region Methods
		public virtual void Update (GameTime gameTime) {
			return;
		}

		public virtual void Draw (SpriteBatch spriteBatch) {
			return;
		}
		#endregion
	}
}
