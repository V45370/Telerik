using System.Collections.Generic;

namespace ParticleSystem
{
	public interface IParticleOperator
	{
		IEnumerable<Particle> OperateOn(Particle p);

		void TickEnded();
	}
}