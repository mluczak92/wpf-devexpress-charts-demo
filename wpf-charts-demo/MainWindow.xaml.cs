using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace wpf_charts_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            int howManySeries = 10;
            int howManyData = 50000;
            float spread = 1000f;

            Random r = new Random();

            Data = new ObservableCollection<DataSeries>(Enumerable.Range(0, howManySeries)
                .Select(i => new DataSeries()
                {
                    Name = (i + 1).ToString(),
                    Values = new ObservableCollection<DataPoint>(Enumerable.Range(0, howManyData)
                            .Select(j => new DataPoint(new DateTime(2020, 01, 01).AddSeconds(j), r.NextDouble() * spread))
                            .ToList())
                }).ToList());
        }


        public ObservableCollection<DataSeries> Data { get; private set; }

        public class DataSeries
        {
            public string Name { get; set; }
            public ObservableCollection<DataPoint> Values { get; set; }
        }
        public class DataPoint
        {
            public DateTime Argument { get; set; }
            public double Value { get; set; }
            public DataPoint(DateTime argument, double value)
            {
                Argument = argument;
                Value = value;
            }
        }
    }
}
