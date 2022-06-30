using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathmate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }

        //Класс для создания типовых задач по геометрии
        //И отображения их в PictureBox
        private class Geometry
        {
            //Массив точек для сотображения Прямоугольного треугольника
            private Point[] ArrayPoint_Geometry;

            //Массив точек для отображения Прямого угла
            private Point[] Arraypoint_Corner;

            //Массив в котором хранятся значения количества заданий
            private int[] ValueTask;

            //Массив, в котором хранятся значения типов заданий
            private int[] Flag;

            //Счётчик для массива Flag, последовательно вытаскивает значения типа задания
            private int CounterFlag = 0;

            //Счётчик для массива ValueTask, последовательно вытаскивает количество заданий для выбранного типа
            private int CounterValueTask = 0;

            ////Переменная, 
            //private bool Sign = false;

            ////Точки, содержащие координаты для значений сторон Прямоугольного треугольника
            //private PointF StrHypothesis;
            //private PointF StrCathet_2;
            //private PointF StrCathet_1;

            //Массив, содеражщий координаты точек для значений сторон фигур
            private PointF[] DataStr;

            //Массив, содержащий координаты точек для буквенных обозначений углов Прямоугольного треугольника
            private PointF[] ABC;
            
            //Счётчик для текущего значений 
            private int CurrentValueTask = 0;

            //Координаты точек для многоугольников
            private int X1 = 0;
            private int X2 = 0;
            private int X3 = 0;
            private int Y1 = 0;
            private int Y2 = 0;
            private int Y3 = 0;

            // Координаты точки для отображения ответа
            private float PointAnswer_X = 15;
            private float PointAnswer_Y = 300;

            //Коэффициент отступа для всех фигур
            private int MAIN_X = 15;
            private int MAIN_Y = 45;

            public Geometry()
            {
                ValueTask = Enumerable.Repeat(1, 25).ToArray();
                Flag = Enumerable.Repeat(0, 25).ToArray();
                Arraypoint_Corner = new Point[4];
            }

            // Метод, обнуляющий массивы ValueTask и Flag
            public void DATACLEAR()
            {
                ValueTask = Enumerable.Repeat(1, 25).ToArray();
                Flag = Enumerable.Repeat(0, 25).ToArray();
            }

            //Метод, обнуляющий счётчик текущего значения
            public void ResetCurrentValue()
            {
                CurrentValueTask = 0;
            }

            //Метод-инкремент для счётчика текущеего значения
            public void IncremetCurrentValue()
            {
                CurrentValueTask++;
            }

            //public void SetCurrentValue(int value)
            //{
            //    CurrentValueTask = value;
            //}

            //Метод возращающий значение счётчика текущего значения
            public int GetCurrentValue()
            {
                return CurrentValueTask;
            }

            //Метод, возращающий длину массива ValueTask
            public int LenghtValueTask()
            {
                return ValueTask.Length;
            }

            //public bool GetSign()
            //{
            //    return Sign;
            //}
            //public void SetSignTrue()
            //{
            //    Sign = true;
            //}
            //public void SetSignFalse()
            //{
            //    Sign = false;
            //    ValueTask = Enumerable.Repeat(1, 25).ToArray();
            //    Flag = Enumerable.Repeat(0, 25).ToArray();
            //}

            //Метод, возращающий значение счётчика для массива ValueTask
            public int GetCounterOfArrayVT()
            {
                return CounterValueTask;
            }

            //Метод, обнуляющий счётчики массивов ValueTask и Flag
            public void ResetCounters()
            {
                CounterValueTask = 0;
                CounterFlag = 0;
            }

            //Метод-инкремент для счётчиков массивов ValueTask и Flag
            public void CounterIncrement()
            {
                CounterFlag++;
                CounterValueTask++;
            }

            //Метод, возращающий значение элемента массива ValueTask по вводимому индексу
            public int GetValueTask(int number)
            {
                return ValueTask[number];
            }

            // Метод, возращающий значение элемента массива ValueTask по индексу счётчика
            public int GetValueTask()
            {
                return ValueTask[CounterValueTask];
            }

            //Метод, присваивающий элементу массива ValueTask по индексу счётчика вводимое число
            public void SetValueTask(int number)
            { 
                ValueTask[CounterValueTask] = number;
            }

            //Метод, возращающи  элемент массива Flag по вводимому индексу
            public int GetFlag(int number)
            {
                return Flag[number];
            }

            //Метод, возращающий элемент массива Flag по индексу счётчика
            public int GetFlag()
            {
                return Flag[CounterFlag] - 1;
            }

            //Метод, присваивающий элементу массива Flag под индексом счётчика вводимое число
            public void SetComboBox(int tmp)
            {
                Flag[CounterFlag] = tmp;
            }    

            //Метод, создающий массив точек для отображения Прямого угла 
            public Point[] Corner()
            {
                //34;121
                Arraypoint_Corner[0].X = 150; Arraypoint_Corner[0].Y = 45;
                Arraypoint_Corner[1].X = 133; Arraypoint_Corner[1].Y = 56;
                Arraypoint_Corner[2].X = 141; Arraypoint_Corner[2].Y = 71;
                Arraypoint_Corner[3].X = 160; Arraypoint_Corner[3].Y = 61;

                return Arraypoint_Corner; 
            }
            //Метод, создающий массив с координатами точек для Трапеции
            public Point[] Trapezoid()
            {
                ArrayPoint_Geometry = new Point [4];

                //Точка А
                ArrayPoint_Geometry[0].X = 45; ArrayPoint_Geometry[0].Y = 150;
                //Точка В
                ArrayPoint_Geometry[1].X = 100; ArrayPoint_Geometry[1].Y = 50;
                //Точка С
                ArrayPoint_Geometry[2].X = 215; ArrayPoint_Geometry[2].Y = 50;
                //Точка D
                ArrayPoint_Geometry[3].X = 245; ArrayPoint_Geometry[3].Y = 150;

                return ArrayPoint_Geometry;
            }

            // Метод, возращающий точку их массива PointHeight для отображения высоты в фигуре в зависимости от задания
            public Point[] GetHeight(int choice)
            {
                // Объявление массива
                ArrayPoint_Geometry = new Point[2];

                switch (choice)
                {
                    //Высота для задания Площадь трапеции
                    case 0:
                        // Объявление координат
                        ArrayPoint_Geometry[0].X = 100; ArrayPoint_Geometry[0].Y = 50;
                        ArrayPoint_Geometry[1].X = 100; ArrayPoint_Geometry[1].Y = 150;

                        return ArrayPoint_Geometry;
                    default:

                        return ArrayPoint_Geometry;
                }
                
            }
            //Метод, создающий массив точек для отображения Прямоугольного треугольника
            public Point[] RightTrangles()
            {
                ArrayPoint_Geometry = new Point[3];

                //Координата точки А = MAIN_X + габариты прошлой фигры(Size_Point_X и Size_Point_Y)
                // К точке Y прибавлена высота треугольника (85)
                //Координата точки B = MAIN_X + габариты прошлой фигры(Size_Point_X и Size_Point_Y)
                // К точке Y прибавлена высота треугольника
                // К точке Х прибавлена длина гипетенузы (189)
                //Координата точки B = MAIN_X + габариты прошлой фигры(Size_Point_X и Size_Point_Y)
                // К точке Х прибавлена длина проекции катета АВ на гипотенузу (135)
                //АB = 189   АC = 160   ВС = 100

                //Point A
                X1 = MAIN_X;//15
                Y1 = MAIN_Y + 85;//130

                //Point B
                X2 = MAIN_X + 189;//204
                Y2 = MAIN_Y + 85;//130

                //Point C
                X3 = MAIN_X + 135;//150
                Y3 = MAIN_Y;//45
                //AC =160

                //Присваивание координат массиву ArrayPoint_Geometry
                ArrayPoint_Geometry[0].X = X1; ArrayPoint_Geometry[0].Y = Y1;
                ArrayPoint_Geometry[1].X = X2; ArrayPoint_Geometry[1].Y = Y2;
                ArrayPoint_Geometry[2].X = X3; ArrayPoint_Geometry[2].Y = Y3;

                //DataStr[0].X = StrHypothesis.X = (X1 + X2) / 2; DataStr[0].Y = StrHypothesis.Y = (Y1 + Y2) / 2;
                //DataStr[1].X = StrCathet_1.X = ((X1 + X3) / 2) - 20; DataStr[1].Y = StrCathet_1.Y = ((Y1 + Y3) / 2) - 32;
                //DataStr[2].X = StrCathet_2.X = ((X2 + X3) / 2) + 10; DataStr[2].Y = StrCathet_2.Y = ((Y2 + Y3) / 2) - 10;


                //Иницилизация массива точек для отображения значений сторон
                DataStr = new PointF[3];

                //Присваивание массиву DataStr координаты точек
                DataStr[0].X = ((X1 + X2) / 2); DataStr[0].Y = ((Y1 + Y2) / 2);
                DataStr[1].X = (((X1 + X3) / 2) - 20); DataStr[1].Y = (((Y1 + Y3) / 2) - 32);
                DataStr[2].X = (((X2 + X3) / 2) + 10); DataStr[2].Y = (((Y2 + Y3) / 2) - 10);

                //Инициализация массива точек для отображения буквенных обозначений сторон
                ABC = new PointF[3];

                //Присваивание массиву ABC координат точек
                ABC[0].X = 5.0F; ABC[0].Y = 132.0F;
                ABC[1].X = 195.0F; ABC[1].Y = 132.0F;
                ABC[2].X = 138.0F; ABC[2].Y = 16.0F;

                return ArrayPoint_Geometry;
            }

            
            // Метод, возращающий точку из массива ABC по вводимому индексу для отображения буквенных обозначений сторон
            public PointF GetABC(int choice, int number)
            {
                switch (choice)
                {
                    // Площадь прямоугольника
                    case 0:
                        
                        ABC = new PointF[4];

                        //ABC[0].X = 20.0F; ABC[0].Y = 30.0F;
                        //ABC[1].X = 247.0F; ABC[1].Y = 30.0F;
                        //ABC[2].X = 247.0F; ABC[2].Y = 146.0F;
                        //ABC[3].X = 20.0F; ABC[3].Y = 146.0F;

                        ABC[0].X = 20.0F; ABC[0].Y = 146.0F;
                        ABC[1].X = 20.0F; ABC[1].Y = 30.0F;
                        ABC[2].X = 247.0F; ABC[2].Y = 30.0F;
                        ABC[3].X = 247.0F; ABC[3].Y = 146.0F;

                        return ABC[number];
                    // Теорема Пифагора
                    case 1:
                        //Инициализация массива точек для отображения буквенных обозначений сторон
                        ABC = new PointF[3];

                        //Присваивание массиву ABC координат точек
                        ABC[0].X = 5.0F; ABC[0].Y = 132.0F;
                        ABC[1].X = 195.0F; ABC[1].Y = 132.0F;
                        ABC[2].X = 138.0F; ABC[2].Y = 16.0F;

                        return ABC[number];
                    case 2:
                        //Объявление массива координат для букв
                        ABC = new PointF[5];

                        //Инициализация координат точек
                        ABC[0].X = 22.0F; ABC[0].Y = 150.0F;
                        ABC[1].X = 75.0F; ABC[1].Y = 30.0F;
                        ABC[2].X = 220.0F; ABC[2].Y = 30.0F;
                        ABC[3].X = 248.0F; ABC[3].Y = 150.0F;
                        ABC[4].X = 100.0F; ABC[4].Y = 150.0F;


                        return ABC[number];
                    default:
                        return PointF.Empty;
                }
            }

            //Метод, возращающий точку по вводимому индексу (number) для отображения значений сторон фигуры, которую хочет выбрать пользователь (choice)
            public PointF GetDataStr(int choice, int number)
            {
                switch (choice)
                {
                    //Теорема Пифагора
                    case 1:

                        return DataStr[number];

                    //Площадь прямоугольника
                    case 0:
                        //Объявление массива с координатами
                        DataStr = new PointF[2];

                        //Объвление координат
                        DataStr[0].X = 130; DataStr[0].Y = 23;
                        DataStr[1].X = 10; DataStr[1].Y = 80;

                        //Возращаем точку по заданному индексу
                        return DataStr[number];
                        //Координаты расположение численных значений сторон в задаче Площадь Трапеции
                    case 2:
                        DataStr = new PointF[3];

                        //Объвление координат
                        DataStr[0].X = 140; DataStr[0].Y = 23;
                        DataStr[1].X = 145; DataStr[1].Y = 152;
                        DataStr[2].X = 100; DataStr[2].Y = 90;

                        return DataStr[number];
                    default:
                        return PointF.Empty;
                }
            }

            //Метод, возращающий координату по Х для отображения ответа 
            public float AnswerPointX()
            {
                return PointAnswer_X;
            }

            // Метод, возращающий координату по У для отображения ответа
            public float AnswerPointY()
            {
                return PointAnswer_Y;
            }
        }
        //Класс выводит  значения  для задач, возможно текст задачи или решение, ответ?????????????????????????
        //
        private class Data
        {
            //Задание Площадь прямоугольнка
            //Массив массивов с значениями длин сторон прямоугольника
            private int[][] DataSides = new int[2][];



            //Задание Теорема Пифагора.
            //Массивы с значениями катетов и гипотенузы
            private int[] Hypothesis = { 5, 10, 13, 15, 17, 20, 25, 25, 26, 29, 30, 34, 37, 53, 61, 65, 89, 113, 149, 181 };
            private int[] Cathet_1 = { 3, 6, 5, 9, 8, 12, 15, 7, 10, 20, 18, 16, 12, 28, 11, 33, 39, 15, 51, 19 };
            private int[] Cathet_2 = { 4, 8, 12, 12, 15, 16, 20, 24, 24, 21, 24, 30, 35, 45, 60, 56, 80, 112, 140, 180 };

            //Массив для вывода значений на экран ( длины сторон ) + ответ
            private int[] Array_Result;
            private float[] Array_ResultF;

            //Переменная , содержащая ответ (Ответ можно записывать в последний элемент массива Array_Result) !!!!!!!!!!!!!!!!!!!!!!!!
            private int Answer = 0;

            //Переменные содержащие случайные индексы и другие рандомные переменные
            private int Sign_1 = 0;
            private int Sign_2 = 0;

            //Рандомная переменная для индексов 
            private Random rand = new Random();

            //Рандомная переменная для генерации индекса неизвестной стороны
            private Random choice = new Random();

            public void Create_Trapezoid()
            {
                //Объявление массива значений сторон для задачи Площадь Трапеции
                Array_ResultF = new float[3];

                //Присваиваем значение меньшему основанию
                Array_ResultF[0] = rand.Next(1, 90);

                //Если меньшее основание чётное
                if (Array_ResultF[0] % 2 == 0) 
                {
                    //Объявляем большее основание
                    Array_ResultF[1] = rand.Next(Convert.ToInt32 (Array_ResultF[1]) + 2, 98);

                    //Если большее основание чётное, то и значение высоты должно быть любым
                    if (Array_ResultF[1] % 2 == 0)
                    {
                      Array_ResultF[2] = rand.Next(2, 30);
                    }
                    //Если же большее основание нечётное, то и значение высоты должно быть чётным
                    else
                    {
                        do
                        {
                            Array_ResultF[2] = rand.Next(2, 30);

                        } while (Array_ResultF[2] % 2 == 1);
                    }
                }
                //Если же меньшее основание нечётное
                else
                {
                    // Присваиваем значение большему основанию 
                    Array_ResultF[1] = rand.Next(Convert.ToInt32( Array_ResultF[0]) + 2, 98);

                    //Если большее основание чётное, то значение высоты должно быть чётным
                    if (Array_ResultF[1] % 2 == 0)
                    {
                        do
                        {
                            Array_ResultF[2] = rand.Next(2, 30);

                        } while (Array_ResultF[2] % 2 == 1);
                    }
                    //Если большее основание нечётное, то значение высоты должно быть любым
                    else
                    {
                            Array_ResultF[2] = rand.Next(2, 30);
                    }
                }

                Answer = Convert.ToInt32((Array_ResultF[0] + Array_ResultF[1]) / 2 * Array_ResultF[2]);
            }
            //Метод, создающий стороны прямоугольнка
            public void Create_Rectangle()
            {
                //Массив, содеражщий значения меньшей стороны прямоугольника
                DataSides[0] = Enumerable.Range(4, 15).ToArray();
                //Массив, содержащий значения большей стороны прямоугольника
                DataSides[1] = Enumerable.Range(6, 16).ToArray();

                //Иницилизируем массив для вывода
                Array_Result = new int[2];

                //задаем случайные индексы для значений сторон прямоугольника
                Sign_1 = rand.Next(0, 15);
                Sign_2 = rand.Next(Sign_1, 16);

                //В массив результата добавляем значения сторон прямоугольника
                Array_Result[0] = DataSides[0][Sign_1];
                Array_Result[1] = DataSides[1][Sign_2];
                //Ответ ( всегда находится под индексом 2 )
                Answer = DataSides[0][Sign_1] * DataSides[1][Sign_2];
            }
            public int GetSides(int number)
            {
                return Convert.ToInt32 (Array_ResultF[number]);
            }
            //Метод создает массив из трёх элементов, значение -1 - это та сторона, которую надо вычислить
            //Две другие стороны выбираются случайно при помощи типа Random
            public void Create_Pythogor()
            {
                // Создание массива для значений длин сторон прямоугольного треугольника
                Array_Result = new int[3];

                //Генерация случайного значения индекса для массивов сторон 
                Sign_1 =  rand.Next(0, 19);
                //Генерация случайного индекса для стороны, которую надо будет искать ( один из катетов или гипотенуза )
                Sign_2 =  choice.Next(0, 2);

                // В зависимости от индекса для искомой стороны в Array_Result записываются стороны, а искомой стороне задаётся значение -1
                //В переменную Answer записывается значение искомой сторонв
                if (Sign_2 == 0)
                {
                    Array_Result[0] = -1;
                    Answer = Hypothesis[Sign_1];
                    Array_Result[1] = Cathet_1[Sign_1];
                    Array_Result[2] = Cathet_2[Sign_1];
                }
                else if(Sign_2 == 1)
                {
                    Array_Result[0] = Hypothesis[Sign_1];
                    Array_Result[1] = -1;
                    Answer = Cathet_1[Sign_1];
                    Array_Result[2] = Cathet_2[Sign_1];
                }
                else if (Sign_2 == 2)
                {
                    Array_Result[0] = Hypothesis[Sign_1];
                    Array_Result[1] = Cathet_1[Sign_1];
                    Array_Result[2] = -1;
                    Answer = Cathet_2[Sign_1];
                }
            }
            //Метод, возращающий правильный ответ
            public int GetAnswer()
            {
                return Answer;
            }
            // Метод, возращающий значение сторон по индексу
            public int Get_Pythogor(int number)
            {
                return Array_Result[number];
            }
        }

        Data objData = new Data();

        // Нужен для отображения в ListBox
        string[] Array_Str =
        {
            //15 задание ОГЭ
            "Площадь прямоугольника", 
            "Теорема Пифагора",
            "Площадь трапеции",
          
        };

        //Создаем холс и объект рисования
        Bitmap map = new Bitmap(100,100);
        Graphics graphics;
        Font font = new Font("Areal", 14);
        Brush brush = new SolidBrush(Color.Black);

        Geometry objGeo = new Geometry();

        Pen pen = new Pen(Color.Black, 3f);
        //Plase of data entry
        //..............................................................................

        

        //Класс для сбора точек на PictureBox при работе с мышкой
        //Создает массив точек и считывает коардинаты при движении мышки по экрану
        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;

            public ArrayPoints(int size)
            {
                if (size <= 0)
                { size = 2; }
                points = new Point[size];
            }

            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }

            public void ResetPoints()
            {
                //points[0].X = 0; points[0].Y = 0;
                index = 0;
            }

            public int GetCountPoints()
            {
                return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }

        }

        private bool isMouse = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);



        private void SetSize()
        {
            Rectangle rectagle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectagle.Width, rectagle.Height);
            graphics = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        //Mouse action
        //.....................................................................................
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
            arrayPoints.SetPoint(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse)
            {
                return;
            }

            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 0 )
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox1.Image = map;
            }
        }


        // Button
        //...............................................................//
        private void buttonClean_Click(object sender, EventArgs e)
        {
            //Очищаем холст
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;
        }

        private void buttonClose2_Click(object sender, EventArgs e)
        {
            Close();
        }
        //When the buttonStart is pressing, ArrayFlag and ArrayValueTask are being filled in
        //And Task and Number Task are being displayed in ListBox
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonMakeTask.Enabled = true;
            buttonClearList.Enabled = true;
            //Записывает значения в массивы ValueTask и Flag
            //Включаем возможность отобразить вариант
            //objGeo.SetSignTrue();

            // Собираем данные о количестве заданий
            objGeo.SetValueTask(Convert.ToInt32(counter.Value));

            //Собираем данные о типе заданий
            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    objGeo.SetComboBox(1);
                    break;
                case 1:
                    objGeo.SetComboBox(2);
                    break;
                case 2:
                    objGeo.SetComboBox(3);
                    break;
                default:
                    break;
            }

            //Отображаем задание в ListBox
            listBox1.Items.Add(Convert.ToString(objGeo.GetValueTask()) + "x" + Array_Str[objGeo.GetFlag()]);
            objGeo.CounterIncrement();
           
            //Переводим значение counter на 1
            counter.Value = 1;
            objGeo.SetValueTask(1);
        }

        private void buttonClearList_Click(object sender, EventArgs e)
        {
            //ВЫключаем возможность отобразить вариант
            //objGeo.SetSignFalse();

            // Значение счетчиков флага и количества заданий сносим на 0
            objGeo.ResetCounters();

            //Очищение listbox
            listBox1.Items.Clear();

        }
        

        //отображение геометрического чертежа сразу после состалвения варианта
        private void buttonMakeTask_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            timer2.Interval = 1000;
            timer2.Start();

            objGeo.ResetCounters();

            label2.Text = $"{objGeo.GetCurrentValue() + 1} из {objGeo.GetValueTask(objGeo.GetCounterOfArrayVT())}";

            switch (objGeo.GetFlag(objGeo.GetCounterOfArrayVT()))
            {
                // "Площадь прямоугольника"
                case 1:
                    objData.Create_Rectangle();

                    graphics.DrawRectangle(pen, 45, 50, 200, 100);

                    graphics.DrawString("A", font, brush, objGeo.GetABC(0, 0));
                    graphics.DrawString("B", font, brush, objGeo.GetABC(0, 1));
                    graphics.DrawString("C", font, brush, objGeo.GetABC(0, 2));
                    graphics.DrawString("D", font, brush, objGeo.GetABC(0, 3));

                    for (int flag = 0; flag < 2; flag++)
                    {
                        graphics.DrawString(Convert.ToString(objData.GetSides (flag) ), font, brush, objGeo.GetDataStr(0, flag) );
                    }

                    pictureBox1.Image = map;
                    break;
                    //Теорема Пифагора
                case 2:
                    objData.Create_Pythogor();

                    //graphics.DrawPolygon(pen, objGeo.Corner());

                    graphics.DrawPolygon(pen, objGeo.RightTrangles());

                    //graphics.DrawLine(pen, objGeo.GetHeightTriangle(0), objGeo.GetHeightTriangle(1));


                    //Создаёт прямой угол у точки С
                    graphics.DrawPolygon(pen, objGeo.Corner());

                    graphics.DrawString("A", font, brush, objGeo.GetABC(1,0));
                    graphics.DrawString("B", font, brush, objGeo.GetABC(1,1));
                    graphics.DrawString("C", font, brush, objGeo.GetABC(1,2));

                    for (int flag = 0; flag < 3; flag++)
                    {
                        if (objData.Get_Pythogor(flag) == -1)
                        {
                            graphics.DrawString(Convert.ToString("?"), font, brush, objGeo.GetDataStr(1, flag));
                            continue;
                        }
                        else
                            graphics.DrawString(Convert.ToString(objData.Get_Pythogor(flag)), font, brush, objGeo.GetDataStr(1, flag));
                    }
                    pictureBox1.Image = map;
                    break;
                case 3:
                    //Генерация значений для оснований трапеции и высоты
                    objData.Create_Trapezoid();

                    //Отображение трапеции
                    graphics.DrawPolygon(pen, objGeo.Trapezoid());

                    //Отображение высоты трапеции
                    graphics.DrawPolygon(pen, objGeo.GetHeight(0));

                    //Отображение букв углов трапеции
                    graphics.DrawString("A", font, brush, objGeo.GetABC(2, 0));
                    graphics.DrawString("B", font, brush, objGeo.GetABC(2, 1));
                    graphics.DrawString("C", font, brush, objGeo.GetABC(2, 2));
                    graphics.DrawString("D", font, brush, objGeo.GetABC(2, 3));
                    graphics.DrawString("H", font, brush, objGeo.GetABC(2, 4));

                    for (int flag = 0; flag < 3; flag++)
                    {
                        graphics.DrawString(Convert.ToString(objData.GetSides(flag)), font, brush, objGeo.GetDataStr(2, flag));
                    }

                    pictureBox1.Image = map;
                    break;
                case 4:
                    break;
                default:
                    break;
            }
            buttonAnswer.Enabled = true;

            buttonClearList.Enabled = false;
            buttonStart.Enabled = false;
            buttonMakeTask.Enabled = false;

            objGeo.IncremetCurrentValue();
            label2.Text = $"{objGeo.GetCurrentValue()} из {objGeo.GetValueTask(objGeo.GetCounterOfArrayVT())}";
        }

        
        // Кнопка "ответ"
        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            //Сравнивает введённый ответ с правильным
            if ( numericUpDown1.Value == objData.GetAnswer() )
            {
                //Если TRUE

                //Очищает холст
                graphics.Clear(pictureBox1.BackColor);
                pictureBox1.Image = map;

                //Если все задания из данного блока закончились, то берутся следующие задания следующего типа
                if (objGeo.GetCurrentValue() == objGeo.GetValueTask(objGeo.GetCounterOfArrayVT()))
                {
                    //Обнуление счётчика количества текущих заданий
                    objGeo.ResetCurrentValue();

                    //инкремент для типа задания и количества заданий текущего типа
                    objGeo.CounterIncrement();
                }

                //Проверка на то, есть ли ещё задания
                if ((objGeo.GetCounterOfArrayVT() <= objGeo.LenghtValueTask()) && ( objGeo.GetFlag(objGeo.GetCounterOfArrayVT() ) != 0) )
                    {
                    //Если TRUE

                    //Закрытие кнопки Правильный ответ и обнуление секундомера для неё
                    buttonShowAnswer.Enabled = false;
                    TimeForReflection = 0;

                    //Отображение геометрического чертежа в зависимости от типа задания
                    switch (objGeo.GetFlag(objGeo.GetCounterOfArrayVT()))
                        {
                                //Площадь прямоугольника
                                case 1:
                                    objData.Create_Rectangle();

                                    graphics.DrawRectangle(pen, 45, 50, 200, 100);

                                    graphics.DrawString("A", font, brush, objGeo.GetABC(0, 0));
                                    graphics.DrawString("B", font, brush, objGeo.GetABC(0, 1));
                                    graphics.DrawString("C", font, brush, objGeo.GetABC(0, 2));
                                    graphics.DrawString("D", font, brush, objGeo.GetABC(0, 3));

                                    for (int flag = 0; flag < 2; flag++)
                                        {
                                            graphics.DrawString(Convert.ToString(objData.GetSides(flag)), font, brush, objGeo.GetDataStr(0, flag));
                                        }

                                    pictureBox1.Image = map;

                                    break;
                                //Теорема Пифагора
                                case 2:
                                    objData.Create_Pythogor();
                                    graphics.DrawPolygon(pen, objGeo.Corner());
                                    graphics.DrawPolygon(pen, objGeo.RightTrangles());

                                    graphics.DrawString("A", font, brush, objGeo.GetABC(1, 0));
                                    graphics.DrawString("B", font, brush, objGeo.GetABC(1, 1));
                                    graphics.DrawString("C", font, brush, objGeo.GetABC(1, 2));

                                    for (int flag = 0; flag < 3; flag++)
                                            {
                                         if (objData.Get_Pythogor(flag) == -1)
                                        {
                                            graphics.DrawString(Convert.ToString("?"), font, brush, objGeo.GetDataStr(1, flag));
                                            continue;
                                        }
                                        else
                                            graphics.DrawString(Convert.ToString(objData.Get_Pythogor(flag)), font, brush, objGeo.GetDataStr(1, flag));
                                    }
                                    pictureBox1.Image = map;
                                    break;
                                //Площадь трапеции
                                case 3:
                                    //Генерация значений для оснований трапеции и высоты
                                    objData.Create_Trapezoid();

                                    //Отображение трапеции
                                    graphics.DrawPolygon(pen, objGeo.Trapezoid());

                                    //Отображение высоты трапеции
                                    graphics.DrawPolygon(pen, objGeo.GetHeight(0));

                                    //Отображение букв углов трапеции
                                    graphics.DrawString("A", font, brush, objGeo.GetABC(2, 0));
                                    graphics.DrawString("B", font, brush, objGeo.GetABC(2, 1));
                                    graphics.DrawString("C", font, brush, objGeo.GetABC(2, 2));
                                    graphics.DrawString("D", font, brush, objGeo.GetABC(2, 3));
                                    graphics.DrawString("H", font, brush, objGeo.GetABC(2, 4));

                                    for (int flag = 0; flag < 3; flag++)
                                    {
                                        graphics.DrawString(Convert.ToString(objData.GetSides(flag)), font, brush, objGeo.GetDataStr(2, flag));
                                    }

                                    pictureBox1.Image = map;
                                    break;
                                case 4:
                                    break;
                                default:
                                  break;
                         }
                    //Инкремент для счётчика количества заданий в текущем блоке
                    objGeo.IncremetCurrentValue();
                    //Уведечение выполненных заданий в label
                    label2.Text = $"{objGeo.GetCurrentValue()} из {objGeo.GetValueTask(objGeo.GetCounterOfArrayVT())}";
                    }
                else
                {
                    //Если задания закончились (FALSE)

                    //Остановка секундомера 
                    timer1.Stop();
                    second = 0;
                    minute = 0;

                    //Остановка секундомера для кнопки ПРавильный ответ
                    timer2.Stop();
                    buttonShowAnswer.Enabled = false;
                    TimeForReflection = 0;

                    //Поздравление
                    MessageBox.Show("Поздравляю! Вы решили все задания!", "Конец");

                    //Действия с кнопками, чтобы можно было заново составить вариант
                    buttonStart.Enabled = true;

                    buttonAnswer.Enabled = false;
                    buttonShowAnswer.Enabled = false;

                    //Обнуляем весь интерфейс

                    counter.Value = 1;
                    label2.Text = "0 из 0";
                    label3.Text = "00:00";
                    listBox1.Items.Clear();

                    //обнуляем все счётчики и массивы

                    objGeo.ResetCurrentValue();
                    objGeo.ResetCounters();

                    objGeo.DATACLEAR();
                }
            }
            else
            {
                //Если ответ неправильный (FALSE)

                // Звук ошибки
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream stream = assembly.GetManifestResourceStream(@"Mathmate.mistake.wav");
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(stream);
                player.Play();
            }

            //if( objGeo.GetFlag (objGeo.GetCounterOfArrayVT() ) == 0)
            //{
            //    timer1.Stop();

            //    MessageBox.Show("Поздравляю! Вы решили все задания!", "Конец");
            //    buttonClearList.Enabled = true;
            //    buttonStart.Enabled = true;
            //    buttonMakeTask.Enabled = true;

            //    buttonAnswer.Enabled = false;
            //    buttonShowAnswer.Enabled = false;

            //    label3.Text = "00:00";
            //}
        }

        private void buttonShowAnswer_Click(object sender, EventArgs e)
        {
            graphics.DrawString(Convert.ToString("Ответ:" + objData.GetAnswer()), font, brush, objGeo.AnswerPointX(), objGeo.AnswerPointY());
            pictureBox1.Image = map;
        }
        int second = 0;
        int minute = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ( (second < 10) && (minute <10) )
            {
                label3.Text = $"0{minute}:0{second}";
            }
            if ((second < 10) && (minute >= 10))
            {
                label3.Text = $"{minute}:0{second}";
            }
            if ((second >= 10) && (minute < 10))
            {
                label3.Text = $"0{minute}:{second}";
            }

            second++;
            if(second == 60)
            {
                minute++;
                second = 0;
            }
        }

        int TimeForReflection = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeForReflection++;
            if (TimeForReflection == 3)
            {
                buttonShowAnswer.Enabled = true;
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str1 = Convert.ToString(e.X);
            string str2 = Convert.ToString(e.Y);
            listBox1.Items.Add(str1 + ";" + str2);
        }
    }
}
