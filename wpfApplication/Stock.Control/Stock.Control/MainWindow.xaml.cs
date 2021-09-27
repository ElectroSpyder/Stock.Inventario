using Stock.Control.Data;
using System.Linq;
using System.Windows;

namespace Stock.Control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// control para filtrado
    /// http://www.puntonetalpunto.net/2017/02/wpf-searchall-control-basico.html
    /// </summary>
    public partial class MainWindow : Window
    {
        StockDbContext context;
        Product NewProduct = new Product();
        Product selectedProduct = new Product();

        public MainWindow(StockDbContext stockDbContext)
        {
            context = stockDbContext;
            InitializeComponent();
            GetProducts();

            NewProductGrid.DataContext = NewProduct;
        }

        private void GetProducts()
        {
            ProductDG.ItemsSource = context.Products.ToList();
        }

        private void AddItem(object s, RoutedEventArgs e)
        {           
            context.Products.Add(NewProduct);
            context.SaveChanges();
            GetProducts();
            NewProduct = new Product();
            NewProductGrid.DataContext = NewProduct;
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.Update(selectedProduct);
            context.SaveChanges();
            GetProducts();
        }

        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }

        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Product;
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            GetProducts();
        }

    }
}
