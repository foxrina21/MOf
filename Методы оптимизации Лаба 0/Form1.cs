using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Math;

namespace Методы_оптимизации_Лаба_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static double f(double x)
        {
            double f;
            return f = Math.Sin(x);
        }

        public static double f(double x0, double x1)
        {
            double f;
            //return f = (x0 + 2 * x1 - 7) * (x0 + 2 * x1 - 7) + (2 * x0 + x1 - 5) * (2 * x0 + x1 - 5);
            //return f = Math.Sin(x0 + x1) + (x0 - x1) * (x0 - x1) - 1.5 * x0 + 2.5 * x1 + 1;
            return f = x1 * x1 + x0 * x0;
            //return f = 100.0 * (x1 - x0 * x0) * (x1 - x0 * x0) + (1.0 - x0) * (1.0 - x0);
        }

        public static double ObjectiveFunction(double[,] data, int n, int m)
        {
            double result = 0;
            result = f(data[m, n], data[m, n]);
            return result;
        }

        public static void Research1(double[,] data, double step, int n)
        {
            int j;
            for (j = 0; j < n - 1; j++) 
            {
                data[1, j] = data[0, j] + step;
                if (ObjectiveFunction(data, j, 1) < ObjectiveFunction(data, j, 0)) continue;
                else 
                {
                    data[1, j] = data[0, j] - step;
                    if (ObjectiveFunction(data, j, 1) < ObjectiveFunction(data, j, 0)) continue;
                    else
                    {
                        data[1, j] = data[0, j];
                        step *= 0.5;
                        j--;
                    }
                }
            }
        }

        public static void Research2(double[,] data, double step, int n)
        {
            int j;
            for (j = 0; j < n - 1; j++)
            {
                data[1, j] = data[0, j] + step;
                if (ObjectiveFunction(data, j, 1) < ObjectiveFunction(data, j, 0)) continue;
                else
                {
                    data[1, j] = data[0, j] - step;
                    if (ObjectiveFunction(data, j, 1) < ObjectiveFunction(data, j, 0)) continue;
                    else
                    {
                        data[1, j] = data[0, j];
                        
                    }
                }
            }
        }

        int Fib (int n)
        {
	        int f1 = 1, f2 = 1, F = 1;
	        for (int i = 3; i <= n; i++)
	        {
		        F = f1 + f2;
		        f1 = f2;
		        f2 = F;
	        }
	        return F;
        }
        
        int search_N (double F)//домножить на корень пяти
            {
	            double g1 = (1 + Math.Sqrt(5))*0.5;
	            double g2 = (1 - Math.Sqrt(5))*0.5;
	            int n = 3;
	            while (F > (Math.Pow(g1, n) - Math.Pow(g2, n)))
		            n++;
	            return n-2;
            }
        
        public double dih()
        {
            double f1, f2, x, a = 2, b = 4, c = 1, tolerance = 0.001;
            do
            {
                x = (a + b) / 2;
                f1 = f(x - tolerance);
                f2 = f(x + tolerance);
                if (c * f1 < c * f2)
                    b = x;
                else
                    a = x;
            }
            while (Math.Abs(b - a) > tolerance);

            x = (b + a) / 2;
            return x;
        }

        public double sech()
        {
            double f1, f2, x1, x2, x, a = 2, b = 4, c = 1, tolerance = 0.001;
            double fi = (1 + Math.Sqrt(5)) / 2;
            double zs;

            do
            {
                zs = (b - a) / fi;
                x1 = b - zs;
                x2 = a + zs;
                f1 = f(x1);
                f2 = f(x2);

                if (c * f1 >= c * f2)
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + zs;
                }
                else
                {
                    b = x2;
                    x2 = x1;
                    x1 = b - zs;
                }
            }
            while (Math.Abs(b - a) > tolerance);

            x = (b + a) / 2;
            return x;
        }

        public double fib()
        {
            double a = 2, b = 4, eps = 0.001;
            int N, n = 0, cf = 0;
            int count = search_N((b - a) * Math.Sqrt(5) / eps) - 1;
            double x1, x2, dx = b - a, Fn, Fn1, Fn2, f1, f2;
            n++;
            N = search_N((b - a) * Math.Sqrt(5) / eps);
            Fn = Fib(N);
            Fn1 = Fib(N + 1);
            Fn2 = Fib(N + 2);
            x1 = a + Fn * (b - a) / Fn2;
            x2 = a + Fn1 * (b - a) / Fn2;
            f1 = f(x1); f2 = f(x2);
            cf += 2;
            if (f1 > f2)
            {
                a = x1;
                f1 = f2;
                f2 = 0;
            }
            else
            {
                b = x2;
                f2 = f1;
                f1 = 0;
            }
            do
            {
                n++;
                N = search_N((b - a) * Math.Sqrt(5) / eps);
                Fn = Fib(N);
                Fn1 = Fib(N + 1);
                Fn2 = Fib(N + 2);
                x1 = a + Fn * (b - a) / Fn2;
                x2 = a + Fn1 * (b - a) / Fn2;
                if (f1 == 0)
                {
                    f1 = f(x1);
                    cf++;
                }
                else
                {
                    f2 = f(x2);
                    cf++;
                }
                if (f1 > f2)
                {
                    a = x1;
                    f1 = f2;
                    f2 = 0;
                }
                else
                {
                    b = x2;
                    f2 = f1;
                    f1 = 0;
                }
                dx = b - a;
            } while (count > n);
            return x1;
        }

        /*
         * Автор Рина
         * Поиск экстремума на интервале [a,b]
         * Метод дихотомии
         * Выходные данные - точка экстремума
         */
        private void методДихотомииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double x = dih();
            //вывод результата
            label1.Text = "По методу дихотомии экстремум равен:" + x + ". Минимум функции:" + f(x);
        }

        private void методЗолотогоСеченияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double x = sech();
            //вывод результата
            label1.Text = "По методу золотого сечения экстремум равен:" + x + ". Минимум функции:" +  f(x);
        }

        private void методФибоначчиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double x = fib();
            //вывод результата
    label1.Text = "По методу Фибоначчи экстремум равен:" + x + ". Минимум функции:" + f(x);
        }

        private void методКвадратичнойИнтерполяцииметодПараболToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void алгоритмПоискаИнтервалаСодержащегоМинимумФункцииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методХукаИДживсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
              
    int n = 2; // One cell for value of function   
 
    double[,] data = new double[3, n];
    int i, j;
    //Введите координаты точки:
    for (j = 0; j < n - 1; j++) {
        data[0, j] = 1;
        data[1, j] = data[0, j];
    }
    //Введите шаг
    double step = 1;
    //Введите коэффициент уменьшение шага
    double contraction = 0.5;
    //Введите коэффициент растяжения
    double expansion = 2;
    //Введите точность
    double precision = 0.01;
    for (i = 0; step > precision; i++) 
    {
        Research1(data, step, n);
        if (data[0, n - 1] <= data[1, n - 1]) step = step * contraction;
        else {
            while (true) {
                for (j = 0; j < n; j++) {
                    data[2, j] = data[1, j];
                    data[0, j] = data[0, j] + expansion * (data[1, j] - data[0, j]);
                }
 
                Research2(data, step, n);
                if (data[2, n - 1] <= data[1, n - 1]) {
                    for (j = 0; j < n - 1; j++) {
                        data[0, j] = data[2, j];
                    }
                    break;
                }
            }
        }
    }
            label1.Text = "Количество итераций:" + i;
            for (j = 0; j < n - 1; j++)
                label1.Text += " \nРешение? " + data[0, j];
            label1.Text += " \nЗначение функции:" + data[0, n - 1];
    //Console.WriteLine("\nРешение\nКоличество итераций: {0}", i);
    //for (j = 0; j < n - 1; j++)
        //Console.Write("\nКоордината {0}: {1}", j, data[0, j]);
    //Console.WriteLine("\nЗначение функции: {0}", data[0, n - 1]);
    //Console.ReadKey();
        }

        private void методРозенброкавращающихсяКоординатToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методПауэллаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методДеформируемогоМногогранникаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методНаискорейшегоСпускаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методСопряженныхГрадиентовИЕгоМодификацииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методНьютонаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методыПеременнойМетрикиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методШтрафныхФункцийToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void методБарьерныхФункцийToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
/*
              int np = 10;
             double[] x = new double[np];
             double[] dx = new double[np];
             double fmin; 
             double[] x0 = new double[np];
             double[] x1 = new double[np];
             double[] x2 = new double[np];
             double[] x3 = new double[np];
             double f0, f1, f2, f3, nor_dx, epsilon = 0.0001, err;
             int n, i;
             //unsigned jch = 0U; 
             //x0x1x2x3
             //if (x0 == null || x1 == null || x2 == null || x3 == null)
             n = 2; x0[0] = -1.2; x0[1] = 1.0;
             dx[0] = 0.8; dx[1] = 0.8;
             n = np;
             for (i = 0; i < n; i++) x0[i] = x[i];
             err = f(x0[0], x0[1]);
             if (err > 0)
             {
                 err = search_N(n, dx, x0, f0, x1, f1);

             }
            
             */