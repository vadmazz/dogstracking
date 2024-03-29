﻿using DogsTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogsTracker.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DogsTracker.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataGridTemplateColumn templateColumn;
        public MainWindow()
        {                                           
            InitializeComponent();
            templateColumn = new DataGridTemplateColumn();
            templateColumn.CellTemplate = (DataTemplate)FindResource("ColButton");
            OddsList.Columns.Add(templateColumn);
        }
    }
}
