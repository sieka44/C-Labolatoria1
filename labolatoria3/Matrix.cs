using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labki3
{
    class Matrix<T> where T : struct    
    {
        protected int SizeX { get; }
        protected int SizeY { get; }
        protected List<List<T>> List { get; }
        public Matrix(int sizeX, int sizeY, List<List<T>> list)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.List = list;
        }

        public void Add(Func<T,T,T> add, Matrix<T> matrix)
        {
            if (this.SizeX != matrix.SizeX || this.SizeY != matrix.SizeY) { return; }
            for (int i = 0; i < SizeX; i++)
            {
                for(int j = 0; j< SizeY; j++)
                {
                    this.List[i][j] = add(this.List[i][j], matrix.List[i][j]);
                }
            }
        }

        public void Multiply(Func<T,T,T> multiply, Func<T,T,T> add,Matrix<T> matrix)
        {
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    this.List[i][j] = add(this.List[i][j], matrix.List[i][j]);
                }
            }
        }

        public void Display()
        {
            Console.WriteLine("MATRIX:");
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    Console.Write(this.List[i][j] + " | ");
                }
                Console.WriteLine();
            }
        }
    }
}
