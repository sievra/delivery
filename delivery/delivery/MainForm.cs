using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace delivery
{
    public partial class MainForm : Form
    {
        //DataTable dtRouter;

        int n;
        int[,] a; // матрица расстояний
        int[] low; // нижняя граница в минутах с начала дня
        int[] up; // верхняя граница в минутах с начала дня
        List<int>[] ansord; /// итоговый порядок точек для каждой машины
        List<int>[] anstime; /// время прибытия в каждую точку каждой машиной
        List<int>[] bestord; /// итоговый порядок точек для каждой машины
        List<int>[] besttime; /// время прибытия в каждую точку каждой машиной
        int ans, ansfulltime; /// ответ
        int[] ltime; /// время последней разгрузки для каждой машины
        List<Individual> population; /// популяция

        //список маркеров, с указанием компонента, в котором они будут использоваться
        GMap.NET.WindowsForms.GMapOverlay markersOverlay;

        void gmapInit()
        {
            //Настройки для компонента GMap.
            gMaps.Bearing = 0;

            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту 
            ///с помощью правой кнопки мыши. 
            gMaps.CanDragMap = true;

            //Указываем, что перетаскивание карты осуществляется 
            //с использованием левой клавишей мыши.
            //По умолчанию - правая.
            gMaps.DragButton = MouseButtons.Left;

            gMaps.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMaps.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMaps.MaxZoom = 17;

            //Указываем значение минимального приближения.
            gMaps.MinZoom = 2;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMaps.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMaps.NegativeMode = false;

            //Разрешаем полигоны.
            gMaps.PolygonsEnabled = true;

            //Разрешаем маршруты
            gMaps.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMaps.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться 
            //18ти кратное приближение.
            gMaps.Zoom = 10;

            //Указываем что все края элемента управления
            //закрепляются у краев содержащего его элемента
            //управления(главной формы), а их размеры изменяются 
            //соответствующим образом.
            //gMaps.Dock = DockStyle.Fill;

            //Указываем что будем использовать карты Google.
            gMaps.MapProvider = GMap.NET.MapProviders.GMapProviders.YandexMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            gMaps.Position = new GMap.NET.PointLatLng(58.0, 56.05);

            ///////////////////////

            /*//инициализируем новую таблицу,
            //для хранения данных о маршруте.
            dtRouter = new DataTable();

            //Добавляем в инициализированную таблицу,
            //новые колонки.
            dtRouter.Columns.Add("Шаг");
            dtRouter.Columns.Add("Нач. точка (latitude)");
            dtRouter.Columns.Add("Нач. точка (longitude)");
            dtRouter.Columns.Add("Кон. точка (latitude)");
            dtRouter.Columns.Add("Кон. точка (longitude)");
            dtRouter.Columns.Add("Время пути");
            dtRouter.Columns.Add("Расстояние");
            dtRouter.Columns.Add("Описание маршрута");

            //Задаем источник данных, для объекта
            //System.Windows.Forms.DataGridView.            
            dataGridView1.DataSource = dtRouter;

            //Задаем ширину седьмого столбца.
            dataGridView1.Columns[7].Width = 250;

            //Задаем значение, указывающее, что необходимо скрыть 
            //для пользователя параметр добавления строк.
            dataGridView1.AllowUserToAddRows = false;

            //Задаем значение, указывающее, что пользователю
            //запрещено удалять строки.
            dataGridView1.AllowUserToDeleteRows = false;

            //Задаем значение, указывающее, что пользователь
            //не может изменять ячейки элемента управления.
            dataGridView1.ReadOnly = false;

            //Добавляем способы перемещения.
            comboBox1.Items.Add("Автомобильные маршруты");
            comboBox1.Items.Add("Пешеходные маршруты");
            comboBox1.Items.Add("Велосипедные маршруты");
            comboBox1.Items.Add("Маршруты общественного транспорта");

            //Выставляем по умолчанию способ перемещения:
            //Автомобильные маршруты по улично-дорожной сети.
            //comboBox1.SelectedIndex = 0;*/

            markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("marker");
        }

        public MainForm()
        {
            InitializeComponent();

            cBAlgo.SelectedIndex = 0;
            cBSource.SelectedIndex = 0;
            cBSelection.SelectedIndex = 0;

            dataGVMatrix.RowHeadersWidth = 50;
            dataGVTime.RowHeadersWidth = 50;

            gmapInit();
        }

        int TimeStrToInt(string s)
        {
            return int.Parse(s.Substring(0, 2)) * 60 + int.Parse(s.Substring(3, 2));
        }

        void initAlgo(int n) // инициализация массивов
        {
            this.n = n;
            a = new int[n, n];
            low = new int[n];
            up = new int[n];

            ansord = new List<int>[n];
            for (int i = 0; i < n; i++)
                ansord[i] = new List<int>();

            anstime = new List<int>[n];
            for (int i = 0; i < n; i++)
                anstime[i] = new List<int>();

            bestord = new List<int>[n];
            for (int i = 0; i < n; i++)
                bestord[i] = new List<int>();

            besttime = new List<int>[n];
            for (int i = 0; i < n; i++)
                besttime[i] = new List<int>();

            ans = n + 1;
            ltime = new int[n];
        }

        void loadDataFromGV() // загрузка данных из формы
        {
            int n = (int)numUDCount.Value;
            initAlgo(n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = int.Parse(dataGVMatrix.Rows[i].Cells[j].Value.ToString());

            for (int i = 1; i < n; i++)
            {
                low[i] = TimeStrToInt(dataGVTime.Rows[i - 1].Cells[0].Value.ToString());
                up[i] = TimeStrToInt(dataGVTime.Rows[i - 1].Cells[1].Value.ToString());
            }
        }

        void loadDataFromGenerator()
        {
            StreamReader reader;
            try
            {
                reader = new StreamReader("gen.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при открытии файла", "Ошибка");
                return;
            }

            int n = int.Parse(reader.ReadLine());
            initAlgo(n);

            for (int i = 0; i < n; i++)
            {
                progressBar.Value = i * 100 / n;
                string line = reader.ReadLine();
                for (int j = 0; j < n; j++)
                    a[i, j] = int.Parse(line.Split('\t', ' ')[j]);
            }

            for (int i = 1; i < n; i++)
            {
                string line = reader.ReadLine();
                low[i] = TimeStrToInt(line.Split('\t', ' ')[0]);
                up[i] = TimeStrToInt(line.Split('\t', ' ')[1]);
            }
            progressBar.Value = 100;
            reader.Close();
        }

        string getTimeBetweenMarkers(int i, int j)
        {
            if (i == j)
                return "0";

            string originLat = markersOverlay.Markers[i].Position.Lat.ToString();
            originLat = originLat.Replace(',', '.');
            string originLng = markersOverlay.Markers[i].Position.Lng.ToString();
            originLng = originLng.Replace(',', '.');

            string destLat = markersOverlay.Markers[j].Position.Lat.ToString();
            destLat = destLat.Replace(',', '.');
            string destLng = markersOverlay.Markers[j].Position.Lng.ToString();
            destLng = destLng.Replace(',', '.');

            //Фомируем запрос к API маршрутов Google.
            string url = string.Format(
                "http://maps.googleapis.com/maps/api/directions/xml?origin={0}&destination={1}&sensor=false&language=ru&mode={2}",
                originLat + ',' + originLng,
                destLat + ',' + destLng, "driving");

            //Выполняем запрос к универсальному коду ресурса (URI).
            System.Net.HttpWebRequest request;
            System.Net.WebResponse response;
            try
            {
                request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                //Получаем ответ от интернет-ресурса.
                response = request.GetResponse();
            }
            catch (Exception)
            {
                stopThread();
                return "0";
            }

            //Экземпляр класса System.IO.Stream 
            //для чтения данных из интернет-ресурса.
            System.IO.Stream dataStream = response.GetResponseStream();

            //Инициализируем новый экземпляр класса 
            //System.IO.StreamReader для указанного потока.
            System.IO.StreamReader sreader = new System.IO.StreamReader(dataStream);

            //Считываем поток от текущего положения до конца.            
            string responsereader = sreader.ReadToEnd();

            //Закрываем поток ответа.
            response.Close();

            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();

            xmldoc.LoadXml(responsereader);

            string durationMin;

            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                System.Xml.XmlNodeList nodes = xmldoc.SelectNodes("//leg//step");

                //MessageBox.Show(xmldoc.GetElementsByTagName("duration")[nodes.Count].ChildNodes[1].InnerText);
                string durationSec = xmldoc.GetElementsByTagName("duration")[nodes.Count].ChildNodes[0].InnerText;
                durationMin = (Math.Ceiling(double.Parse(durationSec) / 60.0)).ToString();
                System.Threading.Thread.Sleep(500);
            }
            else
            {
                stopThread();
                return "0";
            }

            return durationMin;
        }

        void loadDataFromMap()
        {
            int n = (int)numUDCount.Value;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    progressBar.Value = (i * n + j) * 100 / (n * n);
                    dataGVMatrix.Rows[i].Cells[j].Value = getTimeBetweenMarkers(i, j);
                }
            progressBar.Value = 100;

            loadDataFromGV();
        }

        void loadData() // загрузка данных
        {
            lblStatus.Text = "Загрузка данных...";
            switch (cBSource.SelectedItem)
            {
                case "Форма": loadDataFromGV(); break;
                case "Генератор": loadDataFromGenerator(); break;
                case "Карта": loadDataFromMap(); break;
            }
        }

        void runFullSearch() // запуск полного перебора
        {
            isChecked = new bool[n, n];
            used = new bool[n];

            order = new List<int>();
            Tools.resize(ref order, n - 1);

            // заполнение массива isChecked
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                    if (i != j)
                        isChecked[i, j] = check(i, j);

            generator(0, n);
        }

        void runApproximateAlgo() // запуск приближенного алгоритма
        {
            used = new bool[n];
            points = new Delivery_point[n];
            for (int i = 0; i < n; i++)
                points[i] = new Delivery_point();

            ans = 0;

            for (int i = 1; i < n; i++)
            {
                points[i].low = low[i];
                points[i].up = up[i];
                points[i].num = i;
            }
            points[0].num = 0;

            /// поиск первой точки обхода
            int mn = 1;
            for (int i = 2; i < n; i++)
                if (points[i].low < points[mn].low || points[i].low == points[i].low && points[i].up < points[mn].up)
                    mn = i;

            Delivery_point temp = points[mn];
            points[mn] = points[1];
            points[1] = temp;

            Array.Sort(points, 2, n - 2);

            solveApproximate(n);
        }

        void runGeneticAlgo() // запуск генетического алгоритма
        {
            population = new List<Individual>();
            Tools.resize(ref population, (int)numUDIndivids.Value);

            firstPopulation(n - 1);
            for (int i = 0; i < (int)numUDGenerations.Value; i++)
            {
                progressBar.Value = i * 100 / (int)numUDGenerations.Value;
                makeNewPopulation(n - 1);
            }
            progressBar.Value = 100;
        }

        void runAlgo() // запуск алгоритма
        {
            lblStatus.Text = "Выполнение алгоритма...";
            switch (cBAlgo.SelectedItem)
            {
                case "Полный перебор": runFullSearch(); break;
                case "Жадный алгоритм": runApproximateAlgo(); break;
                case "Генетический алгоритм": runGeneticAlgo(); break;
            }
        }

        void run()
        {
            btnRun.Enabled = false;
            progressBar.Value = 0;
            loadData();
            if (n == 0)
            {
                btnRun.Enabled = true;
                return;
            }
            runAlgo();
            print();
            progressBar.Value = 100;
            lblStatus.Text = "Выполнение алгоритма завершено";
            btnRun.Enabled = true;
        }

        Thread myThread;

        private void btnRun_Click(object sender, EventArgs e)
        {
            myThread = new Thread(run);
            myThread.Start();
        }

        void stopThread()
        {
            if (myThread != null)
            {
                lblStatus.Text = "Выполение алгоритма прервано";
                btnRun.Enabled = true;
                myThread.Abort();
                myThread.Join();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopThread();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopThread();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            //Очищаем таблицу перед загрузкой данных.
            dtRouter.Rows.Clear();

            //Создаем список способов перемещения.
            List<string> mode = new List<string>();
            //Автомобильные маршруты по улично-дорожной сети.
            mode.Add("driving");
            //Пешеходные маршруты по прогулочным дорожкам и тротуарам.
            mode.Add("walking");
            //Велосипедные маршруты по велосипедным дорожкам и предпочитаемым улицам.
            mode.Add("bicycling");
            //Маршруты общественного транспорта.
            mode.Add("transit");

            //Фомируем запрос к API маршрутов Google.
            string url = string.Format(
                "http://maps.googleapis.com/maps/api/directions/xml?origin={0},&destination={1}&sensor=false&language=ru&mode={2}",
                Uri.EscapeDataString(textBox1.Text), Uri.EscapeDataString(textBox2.Text), Uri.EscapeDataString(mode[0]));

            //Выполняем запрос к универсальному коду ресурса (URI).
            System.Net.HttpWebRequest request =
                (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            //Получаем ответ от интернет-ресурса.
            System.Net.WebResponse response =
                request.GetResponse();

            //Экземпляр класса System.IO.Stream 
            //для чтения данных из интернет-ресурса.
            System.IO.Stream dataStream =
                response.GetResponseStream();

            //Инициализируем новый экземпляр класса 
            //System.IO.StreamReader для указанного потока.
            System.IO.StreamReader sreader =
                new System.IO.StreamReader(dataStream);

            //Считываем поток от текущего положения до конца.            
            string responsereader = sreader.ReadToEnd();

            //Закрываем поток ответа.
            response.Close();

            System.Xml.XmlDocument xmldoc =
                new System.Xml.XmlDocument();

            xmldoc.LoadXml(responsereader);

            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                System.Xml.XmlNodeList nodes =
                    xmldoc.SelectNodes("//leg//step");

                //Формируем строку для добавления в таблицу.
                object[] dr;
                for (int i = 0; i < nodes.Count; i++)
                {
                    //Указываем что массив будет состоять из 
                    //восьми значений.
                    dr = new object[8];
                    //Номер шага.
                    dr[0] = i;
                    //Получение координат начала отрезка.
                    dr[1] = xmldoc.SelectNodes("//start_location").Item(i).SelectNodes("lat").Item(0).InnerText.ToString();
                    dr[2] = xmldoc.SelectNodes("//start_location").Item(i).SelectNodes("lng").Item(0).InnerText.ToString();
                    //Получение координат конца отрезка.
                    dr[3] = xmldoc.SelectNodes("//end_location").Item(i).SelectNodes("lat").Item(0).InnerText.ToString();
                    dr[4] = xmldoc.SelectNodes("//end_location").Item(i).SelectNodes("lng").Item(0).InnerText.ToString();
                    //Получение времени необходимого для прохождения этого отрезка.
                    dr[5] = xmldoc.SelectNodes("//duration").Item(i).SelectNodes("text").Item(0).InnerText.ToString();
                    //Получение расстояния, охватываемое этим отрезком.
                    dr[6] = xmldoc.SelectNodes("//distance").Item(i).SelectNodes("text").Item(0).InnerText.ToString();
                    //Получение инструкций для этого шага, представленные в виде текстовой строки HTML.
                    dr[7] = HtmlToPlainText(xmldoc.SelectNodes("//html_instructions").Item(i).InnerText.ToString());
                    //Добавление шага в таблицу.
                    dtRouter.Rows.Add(dr);
                }

                //Выводим в текстовое поле адрес начала пути.
                //textBox1.Text = xmldoc.SelectNodes("//leg//start_address").Item(0).InnerText.ToString();
                //Выводим в текстовое поле адрес конца пути.
                //textBox2.Text = xmldoc.SelectNodes("//leg//end_address").Item(0).InnerText.ToString();
                //Выводим в текстовое поле время в пути.
                //textBox3.Text = xmldoc.GetElementsByTagName("duration")[nodes.Count].ChildNodes[1].InnerText;
                MessageBox.Show(xmldoc.GetElementsByTagName("duration")[nodes.Count].ChildNodes[1].InnerText);
                //Выводим в текстовое поле расстояние от начальной до конечной точки.
                //textBox4.Text = xmldoc.GetElementsByTagName("distance")[nodes.Count].ChildNodes[1].InnerText;

                //Переменные для хранения координат начала и конца пути.
                double latStart = 0.0;
                double lngStart = 0.0;
                double latEnd = 0.0;
                double lngEnd = 0.0;

                //Получение координат начала пути.
                latStart = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("start_location")[nodes.Count].ChildNodes[0].InnerText);
                lngStart = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("start_location")[nodes.Count].ChildNodes[1].InnerText);
                //Получение координат конечной точки.
                latEnd = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("end_location")[nodes.Count].ChildNodes[0].InnerText);
                lngEnd = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("end_location")[nodes.Count].ChildNodes[1].InnerText);

                //Выводим в текстовое поле координаты начала пути.
                textBox5.Text = latStart + ";" + lngStart;
                //Выводим в текстовое поле координаты конечной точки.
                textBox6.Text = latEnd + ";" + lngEnd;

                //Устанавливаем заполненную таблицу в качестве источника.
                dataGridView1.DataSource = dtRouter;

                //Устанавливаем позицию карты на начало пути.
                gMaps.Position = new GMap.NET.PointLatLng(latStart, lngStart);

                //Создаем новый список маркеров, с указанием компонента 
                //в котором они будут использоваться и названием списка.
                GMap.NET.WindowsForms.GMapOverlay markersOverlay =
                    new GMap.NET.WindowsForms.GMapOverlay("marker");

                //Инициализация нового ЗЕЛЕНОГО маркера, с указанием координат начала пути.
                var markerG =
                    new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(latStart, lngStart), GMarkerGoogleType.green);
                markerG.ToolTip =
                    new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

                //Указываем, что подсказку маркера, необходимо отображать всегда.
                markerG.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.OnMouseOver;// Always;

                //Формируем подсказку для маркера.
                string[] wordsG = textBox1.Text.Split(',');
                string dataMarkerG = string.Empty;
                foreach (string word in wordsG)
                {
                    dataMarkerG += word + ";\n";
                }

                //Устанавливаем текст подсказки маркера.               
                markerG.ToolTipText = dataMarkerG;

                //Инициализация нового Красного маркера, с указанием координат конца пути.
                GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed markerR =
                    new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed(
                    new GMap.NET.PointLatLng(latEnd, lngEnd));
                markerG.ToolTip =
                    new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

                //Указываем, что подсказку маркера, необходимо отображать всегда.
                //markerR.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;

                //Формируем подсказку для маркера.
                string[] wordsR = textBox2.Text.Split(',');
                string dataMarkerR = string.Empty;
                foreach (string word in wordsR)
                {
                    dataMarkerR += word + ";\n";
                }

                //Текст подсказки маркера.               
                //markerR.ToolTipText = dataMarkerR;

                //Добавляем маркеры в список маркеров.
                markersOverlay.Markers.Add(markerG);
                //markersOverlay.Markers.Add(markerR);

                //Очищаем список маркеров компонента.
                gMaps.Overlays.Clear();

                //Создаем список контрольных точек для прокладки маршрута.
                List<GMap.NET.PointLatLng> list = new List<GMap.NET.PointLatLng>();

                //Проходимся по определенным столбцам для получения
                //координат контрольных точек маршрута и занесением их
                //в список координат.
                for (int i = 0; i < dtRouter.Rows.Count; i++)
                {
                    double dbStartLat = double.Parse(dtRouter.Rows[i].ItemArray[1].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    double dbStartLng = double.Parse(dtRouter.Rows[i].ItemArray[2].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                    list.Add(new GMap.NET.PointLatLng(dbStartLat, dbStartLng));

                    double dbEndLat = double.Parse(dtRouter.Rows[i].ItemArray[3].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    double dbEndLng = double.Parse(dtRouter.Rows[i].ItemArray[4].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                    list.Add(new GMap.NET.PointLatLng(dbEndLat, dbEndLng));
                }

                //Очищаем все маршруты.
                markersOverlay.Routes.Clear();

                //Создаем маршрут на основе списка контрольных точек.
                GMap.NET.WindowsForms.GMapRoute r = new GMap.NET.WindowsForms.GMapRoute(list, "Route");

                //Указываем, что данный маршрут должен отображаться.
                r.IsVisible = true;

                //Устанавливаем цвет маршрута.
                r.Stroke.Color = Color.DarkGreen;

                //Добавляем маршрут.
                markersOverlay.Routes.Add(r);

                //Добавляем в компонент, список маркеров и маршрутов.
                gMaps.Overlays.Add(markersOverlay);

                //Указываем, что при загрузке карты будет использоваться 
                //9ти кратное приближение.
                gMaps.Zoom = 9;

                //Обновляем карту.
                gMaps.Refresh();
            }
        }*/

        /*//Удаляем HTML теги.
        public string HtmlToPlainText(string html)
        {
            html = html.Replace("/b", "");
            return html.Replace("b", "");
        }*/

        private void numUDCount_ValueChanged(object sender, EventArgs e)
        {
            for (int i = dataGVMatrix.Columns.Count; i < numUDCount.Value; i++)
            {
                dataGVMatrix.Columns.Add(i.ToString(), i.ToString());
            }

            for (int i = dataGVMatrix.Rows.Count; i < numUDCount.Value; i++)
            {
                dataGVMatrix.Rows.Add();
                dataGVMatrix.Rows[i].HeaderCell.Value = string.Format(i.ToString(), "0");

                if (i > 0)
                {
                    dataGVTime.Rows.Add();
                    dataGVTime.Rows[i - 1].HeaderCell.Value = string.Format(i.ToString(), "0");
                }
            }

            for (int i = dataGVMatrix.Rows.Count; i > numUDCount.Value; i--)
            {
                dataGVMatrix.Rows.RemoveAt(i - 1);
                if (i > 1)
                    dataGVTime.Rows.RemoveAt(i - 2);
            }

            for (int i = dataGVMatrix.Columns.Count; i > numUDCount.Value; i--)
                dataGVMatrix.Columns.RemoveAt(i - 1);
        }

        void tbMatrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            string vlCell = ((TextBox)sender).Text;
            if (!(Char.IsDigit(e.KeyChar)) || vlCell.Length >= 5)
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void dataGVMatrix_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tbMatrix_KeyPress);
        }

        void tbTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            string vlCell = ((TextBox)sender).Text;
            if (vlCell.Length == 5)
            {
                if (e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }

            int pos = ((TextBox)sender).SelectionStart;
            bool temp = (vlCell.IndexOf(":") == -1);
            if (Char.IsDigit(e.KeyChar))
                if (pos == 0 && e.KeyChar > '2' ||
                    pos == 1 && vlCell[0] == '2' && e.KeyChar > '3' ||
                    (pos == 2 || pos == 3) && e.KeyChar > '5')
                {
                    if (e.KeyChar != (char)Keys.Back)
                        e.Handled = true;
                }

            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == ':' && vlCell.IndexOf(":") == -1 && vlCell.Length == 2))
            {
                if (e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }

            if (Char.IsDigit(e.KeyChar) && vlCell.Length == 2)
            {
                pos = ((TextBox)sender).SelectionStart;
                ((TextBox)sender).Text += ':';
                ((TextBox)sender).SelectionStart = pos + 1;
            }
        }

        private void dataGVTime_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tbTime_KeyPress);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовый файл (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            StreamReader reader = new StreamReader(myStream);
                            int n;
                            n = int.Parse(reader.ReadLine());
                            numUDCount.Value = Math.Min(n, numUDCount.Maximum);

                            for (int i = 0; i < n; i++)
                            {
                                string line = reader.ReadLine();
                                if (i >= numUDCount.Maximum)
                                    continue;
                                for (int j = 0; j < n; j++)
                                    if (j < numUDCount.Maximum)
                                        dataGVMatrix.Rows[i].Cells[j].Value = line.Split('\t', ' ')[j];
                            }

                            for (int i = 0; i < n - 1; i++)
                            {
                                string line = reader.ReadLine();
                                if (i >= numUDCount.Maximum - 1)
                                    continue;
                                for (int j = 0; j < 2; j++)
                                    dataGVTime.Rows[i].Cells[j].Value = line.Split('\t', ' ')[j];
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовый файл (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer;
                    if ((writer = new StreamWriter(openFileDialog1.FileName)) != null)
                    {                         
                        int n = (int)numUDCount.Value;

                        writer.WriteLine(n.ToString());
                        for (int i = 0; i < n; i++)
                        {
                            string line = "";
                            for (int j = 0; j < n; j++)
                            {
                                if (j > 0)
                                    line += ' ';
                                line += dataGVMatrix.Rows[i].Cells[j].Value.ToString();
                            }
                            writer.WriteLine(line);
                        }

                        for (int i = 0; i < n - 1; i++)
                        {
                            string line = "";
                            for (int j = 0; j < 2; j++)
                            {
                                if (j > 0)
                                    line += ' ';
                                line += dataGVTime.Rows[i].Cells[j].Value.ToString();
                            }
                            writer.WriteLine(line);
                        }
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GeneratorForm gf = new GeneratorForm();
            gf.ShowDialog();
        }

        #region Генетический алгоритм

        Tuple<int, int> solve(ref List<int> order) /// моделирование процесса для очередной перестановки
        {
            int n = order.Count;
            int j, cnt = 0, fulltime = 0;

            for (int i = 0; i < n; i++)
            {
                int besttm = (int)1e5, car = -1;
                for (j = 0; j < cnt; j++)
                {
                    int t = ltime[j] + a[ansord[j][ansord[j].Count - 1], order[i]];
                    if (t <= up[order[i]] && t < besttm)
                    {
                        besttm = t;
                        car = j;
                    }
                }
                if (car != -1)
                    ltime[car] = Math.Max(ltime[car] + a[ansord[car][ansord[car].Count - 1], order[i]], low[order[i]]);
                else
                {
                    ltime[cnt] = low[order[i]];
                    car = cnt++;
                }
                ansord[car].Add(order[i]);
                anstime[car].Add(ltime[car]);
            }

            for (int i = 0; i < cnt; i++)
                fulltime += anstime[i][anstime[i].Count - 1] - anstime[i][0] + a[0, ansord[i][0]] + a[ansord[i][ansord[i].Count - 1], 0];

            if (cnt < ans || cnt == ans && fulltime < ansfulltime)
            {
                ans = cnt;
                ansfulltime = fulltime;
                for (int i = 0; i < cnt; i++)
                {
                    bestord[i] = new List<int>(ansord[i]);
                    besttime[i] = new List<int>(anstime[i]);
                }
            }
            for (int i = 0; i < cnt; i++)
            {
                ansord[i].Clear();
                anstime[i].Clear();
            }
            return new Tuple<int, int>(cnt, fulltime);
        }

        void firstPopulation(int n) /// первая популяция
        {
            for (int i = 0; i < population.Count; i++)
                population[i].gen(n, (double)numUDMutation.Value);
        }

        int getParent(double maxValue) /// возвращает индекс родителя по принципу рулетки
        {
            double value = Tools.doubleRand(0, maxValue);
            double val = value;
            for (int i = 0; i < population.Count; i++)
                if (value <= population[i].fitness)
                    return i;
                else
                    value -= population[i].fitness;
            return population.Count - 1;
        }

        void rouletteSelection(ref List<Individual> newPopulation, double sumfit) // принцип рулетки
        {
            for (int i = 0; i < newPopulation.Count / 2; i++) 
            {
                int par1 = getParent(sumfit); // выбор родителей
                int par2 = getParent(sumfit);

                newPopulation[i * 2] = population[par1];
                newPopulation[i * 2 + 1] = population[par2];
            }
        }

        void tournamentSelection(ref List<Individual> newPopulation) // турнирная селекция
        {
            for (int j = 0; j < 2; j++)
            {
                population.OrderBy(x => Tools.rnd.Next());
                for (int i = 0; i < newPopulation.Count; i += 2)
                {
                    if (population[i].fitness > population[i + 1].fitness)
                        newPopulation[i / 2 + j * newPopulation.Count / 2] = population[i];
                    else
                        newPopulation[i / 2 + j * newPopulation.Count / 2] = population[i + 1];
                }
            }
        }

        void makeNewPopulation(int n) /// новое поколение
        {
            int mxtime = -1;
            double sumfit = 0;
            for (int i = 0; i < population.Count; i++) /// моделирование доставки для особи
            {
                Tuple<int, int> ans = solve(ref population[i].perm);
                population[i].cars = ans.Item1;
                population[i].fulltime = ans.Item2;
                mxtime = Math.Max(mxtime, population[i].fulltime);
            }

            for (int i = 0; i < population.Count; i++) /// подсчет функции фитнеса
            {
                population[i].fitness = 1.0 / (population[i].cars * population[i].cars + (int)(population[i].fulltime * 0.5 / mxtime));
                sumfit += population[i].fitness;
            }

            List<Individual> newPopulation = new List<Individual>();
            Tools.resize(ref newPopulation, (int)numUDIndivids.Value);
            
            switch (cBSelection.SelectedItem)
            {
                case "Рулетка": rouletteSelection(ref newPopulation, sumfit); break;
                case "Турнир": tournamentSelection(ref newPopulation); break;
            }

            for (int i = 0; i < newPopulation.Count / 2; i++)
            {
                Individual tmp = newPopulation[i * 2 + 1]; /// кроссовер
                newPopulation[i * 2].cross(ref tmp);
                newPopulation[i * 2 + 1] = tmp;

                newPopulation[i * 2].mutation(); /// мутации
                newPopulation[i * 2 + 1].mutation();
            }

            population = newPopulation;
            //cerr << sumfit << '\n';
        }

        double len(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
        #endregion

        #region Полный перебор

        bool[,] isChecked; /// может ли одна база быть посещена после другой
        List<int> order; /// порядок обхода
        bool[] used; /// занятость точки для генерации перестановок

        bool check(int a, int b) /// проверка, может ли база b быть посещена после базы a
        {
            return low[a] < up[b];
        }

        void generator(int pos, int n) /// генерация перестановок
        {
            if (pos + 1 == n)
            {
                solve(ref order);
                return;
            }

            for (int i = 1; i < n; i++)
                if (!used[i] && (pos == 0 || pos > 0 && isChecked[order[pos - 1], i]))
                {
                    order[pos] = i;
                    used[i] = true;
                    generator(pos + 1, n);
                    used[i] = false;
                }
        }

        #endregion

        #region Приближенный алгоритм

        Delivery_point[] points; /// массив пунктов доставки

        void solveApproximate(int n)
        {
            /// первая машина едет в первый пункт к началу временного окна
            bestord[0].Add(1);
            besttime[0].Add(points[1].low);
            used[1] = true;
            ans = 1;

            /// подбор маршрута
            for (int i = 2; i < n; i++)
            {
                if (used[i]) /// если вершина уже добавлена в путь, ничего не делаем
                    continue;
                used[i] = true;

                /// выбор подходящей машины
                int besttm = (int)1e5, car = -1;
                for (int j = 0; j < ans; j++)
                {
                    int t = besttime[j][besttime[j].Count - 1] + a[points[bestord[j][besttime[j].Count - 1]].num, points[i].num];
                    if (t <= points[i].up && t < besttm)
                    {
                        besttm = t;
                        car = j;
                    }
                }
                if (car != -1) /// одна из имеющихся машин успеет доставить заказ в пункт i
                {
                    besttm = (int)1e5;
                    int point = -1;
                    for (int j = i + 1; j < n; j++) /// попробуем заехать по пути еще куда-нибудь
                        if (!used[j])
                        {
                            int t1 = a[points[bestord[car][bestord[car].Count - 1]].num, points[j].num]; /// ребро из последней в j
                            int t2 = a[points[j].num, points[i].num]; /// ребро из j в i
                            int t3 = a[points[bestord[car][bestord[car].Count - 1]].num, points[i].num]; /// ребро из последней в i
                            int t4 = a[points[i].num, points[j].num]; /// ребро из i в j
                            if (besttime[car][besttime[car].Count - 1] + t1 > points[j].up) /// не успеваем доехать до j
                                continue;
                            if (Math.Max(besttime[car][besttime[car].Count - 1] + t1, points[j].low) + t2 > points[i].up) /// не успеваем доехать до i через j
                                continue;
                            if (Math.Max(besttime[car][besttime[car].Count - 1] + t1, points[j].low) + t2 >
                                Math.Max(besttime[car][besttime[car].Count - 1] + t3, points[i].low) + t4) /// j не по пути
                                continue;
                            if (Math.Max(besttime[car][besttime[car].Count - 1] + t1, points[j].low) + t2 < besttm) /// выберем ту, которая больше всех по пути
                            {
                                besttm = Math.Max(besttime[car][besttime[car].Count - 1] + t1, points[j].low) + t2;
                                point = j;
                            }
                        }
                    if (point != -1) /// куда-то заезжаем
                    {
                        int t1 = Math.Max(points[point].low, besttime[car][besttime[car].Count - 1] + a[points[bestord[car][bestord[car].Count - 1]].num, points[point].num]);
                        int t2 = Math.Max(points[i].low, t1 + a[points[point].num, points[i].num]);
                        bestord[car].Add(point);
                        besttime[car].Add(t1);
                        bestord[car].Add(i);
                        besttime[car].Add(t2);
                        used[point] = true;
                    }
                    else
                    {
                        besttime[car].Add(Math.Max(points[i].low, besttime[car][besttime[car].Count - 1] + a[points[bestord[car][bestord[car].Count - 1]].num, points[i].num]));
                        bestord[car].Add(i);
                    }
                }
                else /// нужна новая машина
                {
                    besttm = (int)1e5;
                    int point = -1;
                    for (int j = i + 1; j < n; j++) /// а вдруг она успеет еще куда-нибудь заехать перед пунктом i
                        if (!used[j])
                        {
                            int t = Math.Max(points[j].low, points[i].low - a[points[j].num, points[i].num]) + a[points[j].num, points[i].num];
                            if (t <= points[i].up && t < besttm)
                            {
                                besttm = t;
                                point = j;
                            }
                        }
                    if (point != -1) /// есть, куда заехать
                    {
                        bestord[ans].Add(point);
                        besttime[ans].Add(Math.Max(points[point].low, points[i].low - a[points[point].num, points[i].num]));
                        bestord[ans].Add(i);
                        besttime[ans].Add(besttime[ans][besttime[ans].Count - 1] + a[points[point].num, points[i].num]);
                        used[point] = true;
                    }
                    else
                    {
                        bestord[ans].Add(i);
                        besttime[ans].Add(points[i].low);
                    }

                    ans++;
                }
            }
        }

        #endregion

        private void cBSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBSource.SelectedItem)
            {
                case "Форма":
                    gBMap.Visible = false;
                    gBCount.Visible = true;
                    gBMatrix.Visible = true;
                    break;
                case "Карта":
                    gBMatrix.Visible = false;
                    gBCount.Visible = false;
                    numUDCount.Value = markersOverlay.Markers.Count;
                    gBMap.Visible = true;
                    break;
            }
        }

        GMap.NET.WindowsForms.Markers.GMarkerGoogle makeMarker(double lat, double lng, string text, GMarkerGoogleType type)
        {
            GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

            marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                        new GMap.NET.PointLatLng(lat, lng), type);

            marker.ToolTipText = text;
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);

            //Указываем, что подсказку маркера, необходимо отображать всегда.
            marker.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.OnMouseOver;// Always;

            return marker;
        }

        void addMarker(double lat, double lng, string text, GMarkerGoogleType type)
        {
            GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

            //Инициализация нового маркера, с указанием координат начала пути.
            marker = makeMarker(lat, lng, text, type);

            markersOverlay.Markers.Add(marker);

            //Очищаем список маркеров компонента.
            gMaps.Overlays.Clear();

            //Добавляем в компонент, список маркеров и маршрутов.
            gMaps.Overlays.Add(markersOverlay);

            if (gMaps.Zoom == gMaps.MaxZoom)
            {
                gMaps.Zoom--;
                gMaps.Zoom++;
            }
            else
            {
                gMaps.Zoom++;
                gMaps.Zoom--;
            }

            //Обновляем карту.
            gMaps.Refresh();
        }

        private void gMaps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (markersOverlay.Markers.Count == numUDCount.Maximum)
                    return;

                double lat = gMaps.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMaps.FromLocalToLatLng(e.X, e.Y).Lng;

                if (markersOverlay.Markers.Count == 0)
                    addMarker(lat, lng, "Склад", GMarkerGoogleType.red);
                else
                    addMarker(lat, lng, "Пункт доставки " +
                        markersOverlay.Markers.Count.ToString(), GMarkerGoogleType.green);
                numUDCount.Value++;
            }
        }

        private void gMaps_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            markersOverlay.Markers.Remove(item);
            for (int i = 0; i < markersOverlay.Markers.Count; i++)
            {
                if (i == 0)
                {
                    double lat = markersOverlay.Markers[i].Position.Lat;
                    double lng = markersOverlay.Markers[i].Position.Lng;
                    markersOverlay.Markers[i] = makeMarker(lat, lng, "Склад", GMarkerGoogleType.red);
                }
                else
                    markersOverlay.Markers[i].ToolTipText = "Пункт доставки " + i.ToString();
            }
            numUDCount.Value--;
        }

        private void btnClearMarkers_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            numUDCount.Value = 0;
        }

        void print() /// вывод ответа
        {
            if (ans == 0)
                return;
            int i, j;
            string text = "";
            text += "Необходимо машин: " + ans.ToString() + Environment.NewLine + Environment.NewLine;
            for (i = 0; i < ans; i++)
            {
                text += "Машина № " + (i + 1).ToString() + Environment.NewLine;
                text += "Время выезда со склада: " + Tools.printTime((besttime[i][0] - a[0, bestord[i][0]] + 1440) / 60 % 24, (besttime[i][0] - a[0, bestord[i][0]] + 1440) % 60) + Environment.NewLine;
                for (j = 0; j < bestord[i].Count; j++)
                    text += "Время разгрузки в пункте " + bestord[i][j].ToString() + ": " + Tools.printTime(besttime[i][j] / 60 % 24, besttime[i][j] % 60) + Environment.NewLine;
                int t = besttime[i][besttime[i].Count - 1] + a[bestord[i][bestord[i].Count - 1], 0];
                text += "Время возвращения на склад: " + Tools.printTime(t / 60 % 24, t % 60);
                if (i < ans - 1)
                    text += Environment.NewLine + Environment.NewLine;
            }

            tBResult.Text = text;
        }
    }
}
