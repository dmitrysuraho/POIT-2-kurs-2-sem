using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static BindingList<PRODUCTS> Products = new BindingList<PRODUCTS>();

        private PRODUCTS selectedProduct;
        public PRODUCTS SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            CodeFirst cf = new CodeFirst();
            foreach(var x in cf.PRODUCTS)
            {
                Products.Add(x);
            }
            grid.ItemsSource = Products;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTS product = new PRODUCTS { NAME = this.name.Text, PRICE = int.Parse(this.price.Text), CURRENCY = this.currency.Text };

            CodeFirst cf = new CodeFirst();
            cf.PRODUCTS.Add(product);

            cf.SaveChanges();

            Products.Clear();
            foreach (var x in cf.PRODUCTS)
            {
                Products.Add(x);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                CodeFirst cf = new CodeFirst();
                using (var transaction = cf.Database.BeginTransaction())
                {
                    try
                    {
                        var op = cf.OrdersProducts.Where(p => p.IDPRODUCT == selectedProduct.IDPRODUCT);
                        PRODUCTS prod = cf.PRODUCTS.FirstOrDefault(p => p.IDPRODUCT == selectedProduct.IDPRODUCT);

                        if (op != null && prod != null)
                        {
                            foreach (var x in op)
                            {
                                cf.OrdersProducts.Remove(x);
                            }
                            cf.PRODUCTS.Remove(prod);
                            cf.SaveChanges();
                            transaction.Commit();
                        }
                        else
                        { 
                            MessageBox.Show("Ошибка при удалении");
                            transaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }

                    Products.Clear();
                    foreach (var x in cf.PRODUCTS)
                    {
                        Products.Add(x);
                    }
                }
            }
            else MessageBox.Show("Выберите продукт для удаления");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            CodeFirst cf = new CodeFirst();
            if (selectedProduct != null)
            {
                PRODUCTS prod = cf.PRODUCTS.FirstOrDefault(p => p.IDPRODUCT == selectedProduct.IDPRODUCT);
                prod.NAME = this.name1.Text;
                prod.PRICE = int.Parse(this.price1.Text);
                prod.CURRENCY = this.currency1.Text;

                cf.SaveChanges();

                Products.Clear();
                foreach (var x in cf.PRODUCTS)
                {
                    Products.Add(x);
                }
            }
            else MessageBox.Show("Выберите товар для редактирования");
        }

        private void SortName(object sender, RoutedEventArgs e)
        {
            CodeFirst cf = new CodeFirst();

            var list = cf.PRODUCTS.OrderBy(p => p.NAME);

            Products.Clear();
            foreach (var x in list)
            {
                Products.Add(x);
            }
        }

        private void SortPrice(object sender, RoutedEventArgs e)
        {
            CodeFirst cf = new CodeFirst();

            var list = cf.PRODUCTS.OrderBy(p => p.PRICE);

            Products.Clear();
            foreach (var x in list)
            {
                Products.Add(x);
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            CodeFirst cf = new CodeFirst();

            Products.Clear();
            foreach (var x in cf.PRODUCTS)
            {
                if(x.NAME.ToUpper().Contains(this.searching.Text.ToUpper()) ||
                    x.PRICE.ToString().Contains(this.searching.Text) ||
                    x.CURRENCY.ToUpper().ToUpper().Contains(this.searching.Text) ||
                    x.IDPRODUCT.ToString().Contains(this.searching.Text))
                {
                    Products.Add(x);
                }
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            CodeFirst cf = new CodeFirst();

            var comps = cf.Database.SqlQuery<PRODUCTS>("SELECT * FROM PRODUCTS");

            Products.Clear();
            foreach (var x in comps)
            {
                Products.Add(x);
            }
        }
    }
}
