namespace Shapes
{
    public abstract class Shapes
    {
        // fields
        protected int width;
        protected int height;

        // constructor
        public Shapes(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        // abstract method
        public abstract int CalculateSurface();

    }
}
