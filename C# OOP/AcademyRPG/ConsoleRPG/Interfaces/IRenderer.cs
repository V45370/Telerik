namespace ConsoleRPG.Interfaces
{
    using ConsoleRPG.GameObjects.MapObjects;

    public interface IRenderer
    {
        void Render(IRenderable item);

        void DeleteObject(IRenderable item);

        int WindowHeight { get; }

        int WindowWidth { get; }

        void InitializeMap(Map map);

        void RenderBackground();
    }
}
