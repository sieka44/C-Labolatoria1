using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labki3
{
    class SquareMatrix<T> : Matrix<T> where T : struct
    {
        public SquareMatrix(int sizeX, int sizeY, List<List<T>> list) : base(sizeX, sizeY, list)
        {
        }

        public bool IsDiagonal(Func<T,T,T> add)
        {
            if (SizeX != SizeY || SizeX<1 || SizeY<1) return false;

            T sum1 = List[0][0];
            T sum2 = List[0][0];
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    sum1 = add(sum1, List[i][j]);
                }
            }
            for(int i = 0;i < SizeX; i++)
            {
                sum2 = add(sum2, List[i][i]);
            }
            return EqualityComparer<T>.Default.Equals(sum1, sum2);
        }
    }
}
