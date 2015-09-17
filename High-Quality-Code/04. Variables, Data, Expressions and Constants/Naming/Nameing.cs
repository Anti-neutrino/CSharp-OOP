namespace Naming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class sets the size of figure and rotate its sides.
    /// </summary>
    public class Size
    {
        private double width;
        private double height;

        /// <summary>
        /// <see cref="Size" />(width,height)
        /// </summary>
        /// <param name="width">This is width.</param>
        /// <param name="height">This is height.</param>
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Get rotated sides.
        /// </summary>
        /// <param name="figure">This is size of the figure.</param>
        /// <param name="angleOfRotation">This is angle of rotation.</param>
        /// <returns>Size</returns>
        public static Size GetRotatedSize(Size figure, double angleOfRotation)
        {
            double sinOfAngle = Math.Sin(angleOfRotation);
            double absSinOfAngle = Math.Abs(sinOfAngle);
            double cosOfAngle = Math.Cos(angleOfRotation);
            double absCosOfAngle = Math.Abs(cosOfAngle);
            double figureWidth = figure.width;
            double figureHeigth = figure.height;

            // Formulas for rotation.
            double rotatedWidth = absCosOfAngle * figureWidth + absSinOfAngle * figureHeigth;
            double rotatedHeigth = absSinOfAngle * figureWidth + absCosOfAngle * figureHeigth;

            Size newSize = new Size(rotatedWidth, rotatedHeigth);

            return newSize;
        }
    }
}
