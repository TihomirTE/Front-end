namespace Task2_If_Statement.Task2._2
{
    using System;

    public class RefactorIfCondition
    {
        public const int MIN_X = int.MinValue;
        public const int MAX_X = int.MaxValue;
        public const int MIN_Y = int.MinValue;
        public const int MAX_Y = int.MaxValue;

        public void IsPointInRange()
        {
            int pointXCoordinate = 10;
            int pointYCoordinate = 5;
            bool shouldVisitCell = true;

            bool isXCoordinateInRange = MIN_X <= pointXCoordinate && pointXCoordinate <= MAX_X;
            bool isYCoordinateInRange = MIN_Y <= pointYCoordinate && pointYCoordinate <= MAX_Y;
            bool isPointInRange = isXCoordinateInRange && isYCoordinateInRange;

            if (isPointInRange && shouldVisitCell)
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }
    }
}
