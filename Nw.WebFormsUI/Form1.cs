using Nw.Busines.Abstract;
using Nw.Busines.Concrete;
using Nw.Busines.DependncyResolver.Ninjec;
using Nw.DataAcces.Concrete.EntityFramework;
using Nw.Entitiess.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nw.WebFormsUI
{
    public partial class frmLayer : Form
    {
        public frmLayer()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>());
        }
        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategorySearch.DataSource = _categoryService.GetAll();
            cbxCategorySearch.DisplayMember = "CategoryName";
            cbxCategorySearch.ValueMember = "CategoryId";
            /////////////////////////////////////////////
            cbxKategoriEkle.DataSource = _categoryService.GetAll();
            cbxKategoriEkle.DisplayMember = "CategoryName";
            cbxKategoriEkle.ValueMember = "CategoryId";
            /////////////////////////////////////////////          
            cbxKategoriGuncel.DataSource = _categoryService.GetAll();
            cbxKategoriGuncel.DisplayMember = "CategoryName";
            cbxKategoriGuncel.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productService.GetAll();
        }

        private void cbxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProducts.DataSource = _productService.GetProductByCategory(Convert.ToInt32(cbxCategorySearch.SelectedValue));
            }
            catch
            {
            }
        }
        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProductSearch.Text))
                dgwProducts.DataSource = _productService.GetByProductsName(txtProductSearch.Text);
            else
                LoadProducts();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                CategoryId = Convert.ToInt32(cbxKategoriEkle.SelectedValue),
                ProductName = txtAdı.Text,
                QuantityPerUnit = txtAdedi.Text,
                UnitPrice = Convert.ToDecimal(txtFiyat.Text),
                UnitsInStock = Convert.ToInt16(txtStok.Text)
            });
            LoadProducts();
            MessageBox.Show("Ürün Eklendi.");

        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                ProductName = txtAdGuncel.Text,
                CategoryId = Convert.ToInt32(cbxKategoriGuncel.SelectedValue),
                UnitsInStock = Convert.ToInt16(txtStokGuncel.Text),
                QuantityPerUnit = txtAdetGuncel.Text,
                UnitPrice = Convert.ToDecimal(txtFiyatGuncel.Text)
            });
            LoadProducts();
            MessageBox.Show("Ürün Güncellendi.");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProducts.CurrentRow;
            txtAdGuncel.Text = row.Cells[2].Value.ToString();
            cbxKategoriGuncel.SelectedValue = row.Cells[1].Value;
            txtFiyatGuncel.Text = row.Cells[3].Value.ToString();
            txtStokGuncel.Text = row.Cells[4].Value.ToString();
            txtAdetGuncel.Text = row.Cells[5].Value.ToString();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            if (dgwProducts.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            LoadProducts();
            MessageBox.Show("Ürün Silindi.");
        }
    }
}
