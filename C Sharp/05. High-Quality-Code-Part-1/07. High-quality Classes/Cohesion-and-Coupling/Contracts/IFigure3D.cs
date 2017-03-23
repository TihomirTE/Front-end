namespace CohesionAndCoupling.Contracts
{
    public interface IFigure3D
    {
        double CalcVolume();

        double CalcDiagonalXYZ();

        double CalcDiagonalXY();

        double CalcDiagonalXZ();

        double CalcDiagonalYZ();
    }
}
