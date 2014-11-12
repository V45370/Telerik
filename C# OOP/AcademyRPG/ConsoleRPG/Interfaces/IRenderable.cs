namespace ConsoleRPG.Interfaces
{
    using ConsoleRPG.Enums;

    public interface IRenderable
    {
        string[] GetImage();

        Coordinates TopLeftCoordinates {get;}

        RenderColorType GetRenderColorType();

    }
}