using System.Collections.Generic;

namespace ParticleSystem
{
	public interface IParticle
	{
		MatrixCoords Position
		{
			get;
		}

		IEnumerable<IParticle> Update();

		bool Exists
		{
			get;
		}
	}
}