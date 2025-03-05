using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliationRoom.Services
{
    class SharedGeometryMethods
    {
        public static double GetAngle(Autodesk.Revit.DB.Transform transform)
        {
            double angleRadian = 0;
            double basisXx = 0;
            double basisXy = 0;

            // Удаление лишних экстремумов
            if (transform.BasisX.X > 1) basisXx = 1;
            else if (transform.BasisX.X < -1) basisXx = -1;
            else basisXx = transform.BasisX.X;

            if (transform.BasisX.Y > 1) basisXy = 1;
            else if (transform.BasisX.Y < -1) basisXy = -1;
            else basisXy = transform.BasisX.Y;


            if (basisXy >= 0) // Верхний полукруг
            {
                if (basisXx == 1) angleRadian = 0;
                else if (basisXx >= 0) angleRadian = Math.Acos(basisXx) + Math.PI * 2 / 4 * 0; // Четверть 1
                else angleRadian = Math.Acos(basisXx) + Math.PI * 2 / 4 * 0; // Четверть 2
            }
            else // Нижний полукруг
            {
                if (basisXx == -1) angleRadian = Math.PI * 2 / 4 * 2;
                else if (basisXx <= 0) angleRadian = Math.PI * 2 / 4 * 2 - Math.Acos(basisXx) + Math.PI * 2 / 4 * 2; // Четверть 3
                else angleRadian = Math.PI * 2 / 4 - Math.Acos(basisXx) + Math.PI * 2 / 4 * 3; // Четверть 4
            }

            return angleRadian;
        }
    }
}
