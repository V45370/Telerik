using System;
using System.Collections.Generic;

namespace ParticleSystem
{
	public class ChaoticParticle : Particle
	{
		public static readonly char[,] ChaoticParticleImage = { { 'H' } };

		protected Random randomChaoticGenerator;
		private const int maxSpeedDeviation = 3;

		public ChaoticParticle(MatrixCoords pos, MatrixCoords speed, Random generator)
			: base(pos, speed)
		{
			this.randomChaoticGenerator = generator;
		}

		public override IEnumerable<Particle> Update()
		{
			this.Accelerate(new MatrixCoords(this.Speed.Row * -1, this.Speed.Col * -1));
			this.Accelerate(GetRandomSpeed());
			return base.Update();
		}

		public override char[,] GetImage()
		{
			return ChaoticParticle.ChaoticParticleImage;
		}

		protected virtual MatrixCoords GetRandomSpeed()
		{
			return new MatrixCoords(this.randomChaoticGenerator.Next(-maxSpeedDeviation, maxSpeedDeviation + 1),
				this.randomChaoticGenerator.Next(-maxSpeedDeviation, maxSpeedDeviation + 1));
		}
	}
}