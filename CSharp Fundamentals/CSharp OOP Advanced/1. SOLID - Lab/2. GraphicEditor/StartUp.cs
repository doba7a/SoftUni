public class StartUp
{
    public static void Main()
    {
        IShape circle = new Circle();
        IShape rectangle = new Rectangle();
        IShape square = new Square();
        IShape cube = new Cube();

        GraphicEditor ge = new GraphicEditor();

        ge.DrawShape(circle);
        ge.DrawShape(rectangle);
        ge.DrawShape(square);
        ge.DrawShape(cube);
    }
}

