namespace ConsoleRPG
{
    public class ProgramMain
    {
        public static void Main()
        {
            var keyboard = new Keyboard();

            var renderer = new ConsoleRendererDecorator(Constants.WINDOW_HEIGHT, Constants.WINDOW_WIDTH);

            var engine = new GameEngine(keyboard,renderer,20);

            engine.Run();
        }
    }
}