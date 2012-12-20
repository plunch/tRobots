using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TrenchcoatRobots.Datatypes {
	class Animation {
		List<Rectangle> m_frames;
		float m_sampleRate;

		public Animation (List<Rectangle> frames,float sampleRate) {
			m_frames = frames;
			m_sampleRate = sampleRate;
		}

		public void AddFrame (Rectangle frame) {
			m_frames.Add(frame);
		}
		public void AddFrame (Vector2 size, Vector2 offset) {
			m_frames.Add(new Rectangle(
				(int)Math.Floor(offset.X),
				(int)Math.Floor(offset.Y),
				(int)Math.Floor(size.X),
				(int)Math.Floor(size.Y)
				));
		}
	}
}
