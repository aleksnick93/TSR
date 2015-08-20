using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;


namespace DiplomProj
{
    class Web
    {
        private DirectoryInfo dir { get; set; } // Директория
        private FileInfo[] bmpfiles { get; set; } // Файлы
        private Image<Bgr, byte> input { get; set; } //Входное изображение 

        private int Maxcomp { get; set; } // Максимальное число совпадений
        
        public Web(int size_x, int size_y) // Конструктор для подготовки системы
        {
            dir = new DirectoryInfo(Application.StartupPath + "\\Используемые знаки"); // Создание директории расположения файлов
            bmpfiles = dir.GetFiles("*.bmp");// Поиск изображений-образцов

            foreach (FileInfo f in bmpfiles) // Перебор файлов изображений-образцов
            {
                String txt = Path.GetFileNameWithoutExtension(f.Name); // Строка названия графического файла без расширения
                txt += ".txt";
                if (!(File.Exists(txt))) // Файл весов не существует
                {
                    FileInfo W = new FileInfo(txt); // Создание файла весов
                    StreamWriter Wr = W.CreateText(); // Режим записи в файл весов
                    Bitmap bmp = new Bitmap(f.FullName);
                    TextBox st = null;
                    KodWeight(Wr, bmp, st); // Запись данных в файл весов
                    Wr.Close();
                }
            }
        }
        
        public Web(Image<Bgr,byte> pict, TextBox stat) // Конструктор для выделенной области
        {
            input = pict;
            FileInfo fin = new FileInfo("Target.txt"); // Создание файла весов
            StreamWriter Wr = fin.CreateText(); // Режим записи в файл весов
            Bitmap bmp = new Bitmap(input.ToBitmap());
            stat.Text += "Выбранная область: " + Environment.NewLine;
            KodWeight(Wr, bmp, stat); // Запись данных в файл весов и его отображение в окне статистики
            Wr.Close();
        }

        private void KodWeight(StreamWriter streamwriter, Bitmap bmp, TextBox txt) // Метод для создания файлов весов
        {
            Color color = new Color();
            for (int y = 0; y < bmp.Height; y++) // Проход по высоте изображения
            {
                for (int x = 0; x < bmp.Width; x++) // Проход по ширине изображения
                {
                    String tempstr=" ";
                    if (x==(bmp.Width-1))
                        tempstr="";
                    color = bmp.GetPixel(x, y);
                    int max = Math.Max(color.R, Math.Max(color.G, color.B));
                    if (max < 80) // Чёрный цвет
                    { streamwriter.Write("K" + tempstr); if (txt != null) txt.Text += 'K' + tempstr; }

                    else if ((max == color.R) && (max == color.G) && (max == color.B)) // Белый цвет
                    { streamwriter.Write("W" + tempstr); if (txt != null) txt.Text += 'W' + tempstr; }

                    else if ((max == color.R) && (max == color.G)) // Жёлтый цвет
                    { streamwriter.Write("Y" + tempstr); if (txt != null) txt.Text += 'Y' + tempstr; }

                    else if (max == color.R)// Красный цвет
                    { streamwriter.Write("R" + tempstr); if (txt != null) txt.Text += 'R' + tempstr; }

                    else if (max == color.G)// Зелёный цвет
                    { streamwriter.Write("G" + tempstr); if (txt != null) txt.Text += 'G' + tempstr; }

                    else if (max == color.B) // Синий цвет
                    { streamwriter.Write("B" + tempstr); if (txt != null) txt.Text += 'B' + tempstr; }

                    else // Цвет фона(белый)
                    { streamwriter.Write("W" + tempstr); if (txt != null) txt.Text += 'W' + tempstr; }
                }
                streamwriter.Write(streamwriter.NewLine); // Новая строка в файле весов
                if (txt != null)  txt.Text += Environment.NewLine;
            }
        }

        public String Comparer(Web obj, TextBox stats, PictureBox pic) // Метод для сравнения файлов весов
        {
            this.Maxcomp = -1;

            FileInfo[] bmps = obj.dir.GetFiles("*.txt");
            int[] tempcomp = new int[obj.bmpfiles.Length];
            int[] comp = new int[obj.bmpfiles.Length];
            
            int p = 0; // Счётчик файлов
            foreach (FileInfo f in bmps) // Перебор файлов весов изображений-образцов
            {
                string[] readf = File.ReadAllLines(f.FullName);
                string[] readi = File.ReadAllLines("Target.txt");

                int iterationQuantity = readf.Length < readi.Length // Минимальное число строк
                                       ? readf.Length
                                       : readi.Length;
                for (int i = 0; i < iterationQuantity; i++)
                {
                    int localQuantity = readf[i].Length < readi[i].Length // Минимальное число столбцов
                                           ? readf[i].Length
                                           : readi[i].Length;

                    for (int j = 0; j < localQuantity; j++)
                    {
                        if (((readf[i][j] == readi[i][j]) && (readi[i][j] != ' ')) && (readi[i][j] != '\n'))
                            tempcomp[p] += 1;
                    }
                }
                p++; 
            }
            Array.Sort(tempcomp); // Сортировка массива совпадений по возрастанию
            int t = tempcomp.Length - 1; 
            this.Maxcomp = tempcomp[t]; // Максимальным значением совпаденией будет последнее значение сортированного массива
            p = 0;

            foreach (FileInfo f in bmps)
            {
                string[] readf = File.ReadAllLines(f.FullName);
                string[] readi = File.ReadAllLines("Target.txt");


                int iterationQuantity = readf.Length < readi.Length //Минимальное число строк
                                       ? readf.Length
                                       : readi.Length;
                for (int i = 0; i < iterationQuantity; i++)
                {
                    int localQuantity = readf[i].Length < readi[i].Length//Минимальное число столбцов
                                           ? readf[i].Length
                                           : readi[i].Length;

                    for (int j = 0; j < localQuantity; j++)
                    {
                        if (((readf[i][j] == readi[i][j]) && (readi[i][j] != ' ')) && (readi[i][j] != '\n'))
                        {
                            comp[p] += 1;
                        }
                    }
                }
                if (comp[p] == tempcomp[t]) // Число совпадений для файла весов изображения-образца и выделенной области максимально
                {
                    String filename = Path.GetFileNameWithoutExtension(f.Name);
                    String bmpf = obj.dir.FullName + "\\" + filename + ".bmp";
                    pic.Image = Image.FromFile(bmpf);
                    stats.Text += Environment.NewLine + "Файл образца: " + f.Name;
                    for (int l = 0; l < iterationQuantity; l++)
                    {
                        stats.Text += Environment.NewLine + readf[l];
                    }
                    double percent = this.Maxcomp / (this.input.Height * this.input.Width);
                    stats.Text += Environment.NewLine + Environment.NewLine + "Процент совпадений: " + Convert.ToString(percent) + "%" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    return filename;
                }
                p++;
            }
            return "Error";
        }     
    }
}
