namespace ParticleSystem
{
	public class ParticleAttractor : Particle
	{
		public int Power { get; private set; }

		public ParticleAttractor(MatrixCoords position, MatrixCoords speed, int attractionPower) :
			base(position, speed)
		{
			this.Power = attractionPower;
		}

		public override char[,] GetImage()
		{
			return new char[,] { { '0' } };
		}
	}
}