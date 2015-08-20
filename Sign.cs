using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.GPU;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;



namespace DiplomProj
{
    public partial class Sign : Form
    {
        const int size_y = 30;
        const int size_x = 30;
        public int[,] W = new int[size_x, size_y];
        public Image img;
        public Image<Bgr, byte> trimg;
        private Boolean state = true;
        PictureBox pic = new PictureBox();
        private int begin_x;
        private int begin_y;
        bool resize = false;
        private int scroller_vert = -1;
        private int scroller_hor = -1;


        public Sign()
        {
            InitializeComponent();
        }

        private void Sign_Load(object sender, EventArgs e)
        {
            pic.Parent = srcImgBox;
            pic.BackColor = Color.Transparent;
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.Visible = false;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(
               int hWnd,      // handle to destination window
               uint Msg,       // message
               long wParam,  // first message parameter
               long lParam   // second message parameter
               );

        static public Bitmap Copy(Image srcBitmap, Rectangle section)
        {
            // Вырезаем выбранную область изображения
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
            }
            return bmp;//Возвращаем выбранную область изображения
        }

        private void Load_button_Click(object sender, EventArgs e) // Обработка события по нажатии кнопки "Открыть"
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes) // В случае успешного открытия диалогового окна
            {
                label2.Text = openFileDialog1.FileName; // Отображение названия файла
                img = Image.FromFile(label2.Text); // Загрузка изображения с файла
                srcImgBox.Image = img; // Отображение загруженного изображения
                Do_button.Enabled = true; // Кнопка "Распознать" становится активной
                state = true; // Исходное изображение
            }
        }

        private void Do_button_Click(object sender, EventArgs e) // Обработка события по нажатии кнопки "Распознать"
        {
            if (state) // Если отображается исходное изображение
            {
                label1.Visible = true;
                progressBar.Visible = true; // Отображение прогресса выполнения
                progressBar.Minimum = 0;                // Задание границ для
                progressBar.Maximum = img.Height;       // прогресса выполнения

                Bitmap bmp = new Bitmap(img);
                Color color;
                float[,] hue = new float[img.Height, img.Width];
                float[,] saturation = new float[img.Height, img.Width];
                float[,] value = new float[img.Height, img.Width];
                for (int y = 0; y < img.Height; y++) // проход по высоте изображения
                {
                    for (int x = 0; x < img.Width; x++) // проход по ширине изображения
                    {
                        color = bmp.GetPixel(x, y);

                        #region RGB to HSV
                        // Преобразование изображения из цветовой схемы RGB в HSV
                        float max = Math.Max(color.R, Math.Max(color.G, color.B)) / 255.0f; // Поиск преобладающего цвета
                        float min = Math.Min(color.R, Math.Min(color.G, color.B)) / 255.0f; // Поиск рецессивного цвета

                        value[y, x] = max; // Задание параметра значения цвета в HSV

                        saturation[y, x] = (value[y, x] != 0) ? (value[y, x] - min) / value[y, x] : 0; // Вычисление насыщенности цвета в HSV

                        if (max == (color.R / 255.0f)) //Преобладает красный цвет
                            hue[y, x] = 60 * (color.G / 255.0f - color.B / 255.0f) / saturation[y, x]; // Вычисление цветового тона в HSV
                        else if (max == (color.G / 255.0f))//Преобладает зелёный цвет
                            hue[y, x] = 120 + 60 * (color.B / 255.0f - color.R / 255.0f) / saturation[y, x]; // Вычисление цветового тона в HSV
                        else  //Преобладает синий цвет
                            hue[y, x] = 240 + 60 * (color.R / 255.0f - color.G / 255.0f) / saturation[y, x]; // Вычисление цветового тона в HSV
                        while (hue[y, x] < 0)
                            hue[y, x] += 360; // Корректировка цветового тона в случае отрицательных углов
                        #endregion

                        switch (Porog_pr(hue[y, x], saturation[y, x], value[y, x])) // Выполнение подпрограммы порогового преобразования
                        {
                            case "Red":
                                bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0)); // Запись красного пикселя с х,у координатами в новый рисунок
                                break;
                            case "Green":
                                bmp.SetPixel(x, y, Color.FromArgb(0, 255, 0)); // Запись зелёного пикселя с х,у координатами в новый рисунок
                                break;
                            case "Blue":
                                bmp.SetPixel(x, y, Color.FromArgb(0, 0, 255)); // Запись синего пикселя с х,у координатами в новый рисунок
                                break;
                            case "Yellow":
                                bmp.SetPixel(x, y, Color.FromArgb(255, 255, 0)); // Запись жёлтого пикселя с х,у координатами в новый рисунок
                                break;
                            case "Black":
                                bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0)); // Запись чёрного пикселя с х,у координатами в новый рисунок
                                break;
                            case "White":
                                bmp.SetPixel(x, y, Color.FromArgb(255, 255, 255)); // Запись белого пикселя с х,у координатами в новый рисунок
                                break;
                        }
                    }

                    progressBar.Value = y; // Инкремент прогресса выполнения
                    progressBar.Refresh(); // Обновление прогресса выполнения
                }
                srcImgBox.Image = bmp; // Помещение преобразованного изображения на место исходного 

                progressBar.Value = 0; // Обнуление прогресса выполнения
                progressBar.Visible = false; // Скрытие прогресса выполнения
                label1.Visible = false;
                state = false; // Исходное изображение заменено обработанным

            }
            else
            {
                srcImgBox.Image = Image.FromFile(label2.Text); // Загрузка изображения с файла
                state = true; // Обработанное изображение заменено исходным
            }
        }


        public string Porog_pr(double hue, double saturation, double value) // Подпрограмма порогового преобразования
        {
            bool h_red = ((hue < 30) || (hue > 330)) ? true : false; // Проверка на попадание пикселя в диапазон красных тонов
            bool h_green = ((hue > 80) && (hue < 140)) ? true : false; // Проверка на попадание пикселя в диапазон зелёных тонов
            bool h_blue = ((hue > 200) && (hue < 260)) ? true : false; // Проверка на попадание пикселя в диапазон синих тонов
            bool h_yel = ((hue > 30) && (hue < 80)) ? true : false; // Проверка на попадание пикселя в диапазон жёлтых тонов
            bool sat = (saturation > 0.6) ? true : false; // Цвет насыщенный или сероватый?
            bool val = (value > 0.2) ? true : false; // Цвет яркий или нет?
            if (!val)
                return ("Black");
            else if (h_red && sat && val)
                return ("Red");
            else if (h_green && sat && val)
                return ("Green");
            else if (h_blue && sat && val)
                return ("Blue");
            else if (h_yel && sat && val)
                return ("Yellow");
            else
                return ("White");
        }

        private void srcImgBox_MouseDown(object sender, MouseEventArgs e) // Обработка события опускания курсора вниз
        {
            if (e.Button == MouseButtons.Left) // По нажатии на левую кнопку мыши
            {
                begin_x = e.X;
                begin_y = e.Y;
                pic.Left = e.X;
                pic.Top = e.Y;
                pic.Width = 0;
                pic.Height = 0;
                pic.Visible = true; // Отображение выделяемой области
                resize = true;
            }
        }

        private void srcImgBox_MouseUp(object sender, MouseEventArgs e) // Обработка события прекращения нажатия на левую кнопку мыши
        {
            int step = 30; // Минимально возможный размер выделяемого изображения по ширине и высоте
            pic.Width = 0;
            pic.Height = 0;
            pic.Visible = false; // Скрытие выделяемой области
            if (resize == true)
            {
                if ((e.X >= begin_x + step) && (e.Y >= begin_y + step))  // Выделяемая область должна быть больше или равна минимально возможному размеру
                {
                    Rectangle rec = new Rectangle(begin_x, begin_y, e.X - begin_x, e.Y - begin_y); // Инициализация прямоугольной области

                    //Загрузка выделенного изображения и его масштабирование
                    trimg = new Image<Bgr, byte>(Copy(srcImgBox.Image, rec)).Resize(step, step, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, true);

                    //Перевод выделенного изображения в монохромное
                    Image<Gray, Byte> gray = trimg.Convert<Gray, Byte>().PyrDown().PyrUp();

                    
                    #region Circle detection
                    double cannyThreshold = 100.0;
                    double circleAccumulatorThreshold = 300.0;
                    CircleF[] circles = gray.HoughCircles(
                    new Gray(cannyThreshold),
                    new Gray(circleAccumulatorThreshold),
                             2.0, // Разрешение аккумулятора для поиска центров окружностей
                             300.0, // Минимальное расстояние 
                             30, // Минимальный радиус
                             200 // Максимальный радиус
                             )[0]; // Выбор окружностей с первого канала
                    #endregion

                    #region Canny and edge detection
                    double cannyThresholdLinking = 200.0;
                    Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking); 
                    LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                                20, // Дистанция между пиксельно-связными областями
                                Math.PI / 45.0, //Угол, выраженный в радианах
                                100, // Порог
                                50, // Минимальная ширина линии
                                40 // Пропуск между линиями
                                )[0]; // Выбор линий с первого канала
                    #endregion

                    #region Find triangles and rectangles
                    List<Triangle2DF> triangleList = new List<Triangle2DF>();
                    List<MCvBox2D> boxList = new List<MCvBox2D>(); 
                    using (MemStorage storage = new MemStorage()) // Использование хранилища для хранения контуров
                        for (Contour<Point> contours = cannyEdges.FindContours(
                                   Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                                   Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage);
                                   contours != null;
                                   contours = contours.HNext)
                        {
                            Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                            if (currentContour.Area > 250) // Рассматриваются контуры с площадью более 250
                            {
                                if (currentContour.Total == 3) // У контура 3 вершины, это треугольник.
                                {
                                    Point[] pts = currentContour.ToArray();
                                    triangleList.Add(new Triangle2DF(pts[0], pts[1], pts[2]));
                                }
                                else if (currentContour.Total == 4) // У контура 4 вершины, это прямоугольник
                                {
                                    #region determine if all the angles in the contour are within [80, 100] degree
                                    bool isRectangle = true;
                                    Point[] pts = currentContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                    for (int i = 0; i < edges.Length; i++)
                                    {
                                        double angle = Math.Abs(edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                        if (angle < 80 || angle > 100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }
                                    #endregion

                                    if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
                                }
                            }
                        }
                    #endregion
                    
                    #region Draw objects
                        foreach (Triangle2DF triangle in triangleList) 
                            trimg.Draw(triangle, new Bgr(Color.Aqua), 1); // Выделение треугольников
                        foreach (MCvBox2D box in boxList)
                            trimg.Draw(box, new Bgr(Color.DarkOrange), 1); // Выделение прямоугольников
                        foreach (CircleF circle in circles)
                            trimg.Draw(circle, new Bgr(Color.Green), 1); // Выделение окружностей
                    /*  foreach (LineSegment2D line in lines)
                            trimg.Draw(line, new Bgr(Color.Green), 1); */
                    detimgBox.Image = trimg;
                    #endregion

                    // detimgBox.Image = Copy(srcImgBox.Image, rec);
                    Comp_button.Enabled = true;
                }
            }
            resize = false;
        }


        private void srcImgBox_MouseMove(object sender, MouseEventArgs e) // Обработка события передвижение мыши
        {
            if (e.Button == MouseButtons.Left) // Левая кнопка мыши нажата
            {
                pic.Width = e.X - begin_x;
                pic.Height = e.Y - begin_y;

                //Скроллинг...
                scroller_hor = -1;
                scroller_vert = -1;

                if (e.X > panel.Width - 5)
                { scroller_hor = 0; }

                if (e.Y > panel.Height - 5)
                { scroller_vert = 0; }


            }
        }

        private void Comp_button_Click(object sender, EventArgs e) // Обработка события по нажатии на кнопку "Распознать"
        {
            String file, query;
            Web Sample = new Web(size_x, size_y); // Создание файлов весов изображений-образцов
            Web target = new Web(trimg, Stat_textBox); // Создание файлов весов выделенной области
            file = target.Comparer(Sample, Stat_textBox, signBox); // Запись имени файла распознанного изображения-образца

            query = "select distinct Sign_Name, Sign_Description, Type_Name, Type_Description " +
                    "from dbo.Main, dbo.Types, dbo.Description " +
                    "where Main.type_id=Types.type_id AND Main.id=Description.id AND File_Name = \'" + file + "\'"; // Запрос к БД
            ReadOrderData(query, Inf_textBox); // Считывание информации из БД
        }

        

        private void ReadOrderData(string queryString, TextBox txtbox) // Подпрограмма считывания данных из БД в окно информации по знаку
        {
            string connectstr = "Data Source=.\\SQLEXPRESS;Initial Catalog=Road_sign;Integrated Security=True;"; // Строка соединения
            //PROCOMP\\SQLEXPRESS
            txtbox.Clear();
            SqlDataReader reader = null; // Объявление SqlDataReader

            using (SqlConnection connection = new SqlConnection(connectstr)) // Создание соединения к БД
            {
                SqlCommand command = new SqlCommand(queryString, connection); // Создание запроса к БД
                try
                {
                    connection.Open(); // Открыть соединение

                    reader = command.ExecuteReader(); // Чтение из БД

                    // Пока есть данные, идёт считывание
                    while (reader.Read())
                    {
                        TextBox box1 = new TextBox(); // Заголовки
                        TextBox box2 = new TextBox(); // Обычный текст
                        box1.TextAlign = HorizontalAlignment.Center;
                        box1.Font = new Font("Sitka Heading", 11, FontStyle.Bold);
                        box2.TextAlign = txtbox.TextAlign;
                        box2.Font = txtbox.Font;

                        Box_changed(txtbox, box1); // Изменение стиля отображения данных
                        txtbox.Text += "Название знака: " + Environment.NewLine;

                        Box_changed(txtbox, box2);
                        txtbox.Text += (string)reader["Sign_Name"] + Environment.NewLine + Environment.NewLine; // Вывод информации из БД

                        Box_changed(txtbox, box1);
                        txtbox.Text += "Описание знака: " + Environment.NewLine;

                        Box_changed(txtbox, box2);
                        txtbox.Text += (string)reader["Sign_Description"] + Environment.NewLine + Environment.NewLine;

                        Box_changed(txtbox, box1);
                        txtbox.Text += "Классификация знака: " + Environment.NewLine;

                        Box_changed(txtbox, box2);
                        txtbox.Text += (string)reader["Type_Name"] + Environment.NewLine + Environment.NewLine;

                        Box_changed(txtbox, box1);
                        txtbox.Text += "Описание классификации знака: " + Environment.NewLine;

                        Box_changed(txtbox, box2);
                        txtbox.Text += (string)reader["Type_Description"];
                    } 
                }
                finally
                {
                    // Закрытие потока
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    // Завершение связи
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        } 

        private void Box_changed(TextBox txtbox, TextBox box) // Подпрограмма изменения отображения данных
        {
            txtbox.TextAlign = box.TextAlign;
            txtbox.Font = box.Font;
        }
    }
}

             
