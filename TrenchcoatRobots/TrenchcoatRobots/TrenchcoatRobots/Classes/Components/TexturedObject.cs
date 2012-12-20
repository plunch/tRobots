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

namespace TrenchcoatRobots.Classes.Components {
	class TextureRenderer : Component {
		public Texture2D Texture { get; set; }

		#region Constructors
		/// <summary>
		/// Creates a new TexturedObject at 0,0 with the rotation 0.
		/// </summary>
		/// <param name="gameObject">The GameObject to which the Rigidbody will belong.</param>
		/// <param name="texture">Texture for the TexturedObject</param>
		public TextureRenderer (GameObject gameObject, Texture2D texture)
			: base(gameObject, "TextureRenderer", false) {
			this.Texture = texture;
		}
		#endregion

		public override void Draw (SpriteBatch spriteBatch) {
			spriteBatch.Begin();
			spriteBatch.Draw(
				Texture,
				Parent.Position,
				null,
				Color.White,
				(float)(Parent.Angle * Math.PI) / 180f,
				new Vector2(Texture.Width * 0.5f, Texture.Height * 0.5f),
				1.0f, SpriteEffects.None,
				0f
				);
			spriteBatch.End();
		}
	}
}
