using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labki3
{
    class Program
    {
        static void Main(string[] args)
        {
            TestComplexMatrix();
        }

        public static void TestSomething()
        {
            int[] a = { 1, 2, 3, 4 };
            ArrayList arrayList = new ArrayList();
            Queue_composition queue1 = new Queue_composition(a);
            Queue_composition queue2 = new Queue_composition(arrayList);

            Complex<double, double> complexDouble = new Complex<double, double>(10.1, 12.4);
            Complex<int, int> complexInt = new Complex<int, int>(10, 12);
            Complex<float, float> complexFloat = new Complex<float, float>(10.1F, 12.4F);
            Complex<short, short> complexShort = new Complex<short, short>(1, 1);
            Complex<short, double> complexShortDouble = new Complex<short, double>(1, 1.1);
            Console.WriteLine(complexDouble);
            Console.WriteLine(complexInt);
            Console.WriteLine(complexFloat);
            Console.WriteLine(complexShort);

        }

        public static void TestAddMatrix()
        {
            List<int> a = new List<int>
            {
                1,
                2,
                3,
                4
            };
            List<List<int>> listOfLists = new List<List<int>>
            {
                new List<int>(a),
                new List<int>(a),
                new List<int>(a),
                new List<int>(a)
            };
            List<List<int>> listToAdd = new List<List<int>>
            {
                new List<int>(a),
                new List<int>(a),
                new List<int>(a),
                new List<int>(a)
            };
            Matrix<int> matrix1 = new Matrix<int>(4, 4, listOfLists);
            Matrix<int> matrix2 = new Matrix<int>(4, 4, listToAdd);
            matrix1.Display();
            matrix2.Display();
            matrix1.Add((x,y) => x+y ,matrix2);
            matrix1.Display();
        }
        public static void TestIsDiagonalMatrix()
        {
            List<List<int>> listOfLists = new List<List<int>>
            {
                new List<int>{
                    1,0,0,0
                },
                new List<int>{
                    0,1,0,0
                },
                new List<int>{
                    0,0,1,0
                },
                new List<int>{
                    0,0,0,1
                }
            };
            SquareMatrix<int> matrix = new SquareMatrix<int>(4, 4, listOfLists);
            matrix.Display();
            if (matrix.IsDiagonal((x,y) => x+y))
            {
                Console.WriteLine("IS DIAGONAL");
            }
        }
        public static void TestComplexMatrix()
        {
            List<Complex<int, int>> a = new List<Complex<int, int>>
            {
                new Complex<int,int>(1,2),
                new Complex<int,int>(1,2),
                new Complex<int,int>(1,2),
                new Complex<int,int>(1,2)
            };
            List<List<Complex<int,int>>> listOfLists = new List<List<Complex<int, int>>>
            {
                new List<Complex<int,int>>(a),
                new List<Complex<int,int>>(a),
                new List<Complex<int,int>>(a),
                new List<Complex<int,int>>(a)
            };
            List<List<Complex<int, int>>> listToAdd = new List<List<Complex<int, int>>>
            {
                new List<Complex<int,int>>(a),
                new List<Complex<int,int>>(a),
                new List<Complex<int,int>>(a),
                new List<Complex<int,int>>(a)
            };

            SquareMatrix<Complex<int, int>> matrix = new SquareMatrix<Complex<int, int>>(4, 4, listOfLists);
            SquareMatrix<Complex<int, int>> matrixToAdd = new SquareMatrix<Complex<int, int>>(4, 4, listToAdd);

            matrix.Display();
            matrix.Add((s,t)=> new Complex<int, int>(s.Real+t.Real,t.Imag+s.Imag),matrixToAdd);
            matrix.Display();
            Console.WriteLine(matrix.IsDiagonal((s, t) => new Complex<int,int>(s.Real+t.Real,s.Imag + t.Imag)));
        }
    }
}
