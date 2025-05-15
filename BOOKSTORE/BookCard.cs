using System;
using System.Drawing;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class BookCard : UserControl
    {
      

        public BookCard()
        {
            InitializeComponent();         
        }

        public void SetBookData(
            Image cover,
            string title,
            string author,
            string category,
            string isbn,
            decimal price,
            int stock,
            string description)
        {
            pictureBoxCover.Image = cover;
            lblTitle.Text = title;
            lblAuthor.Text = $"by {author} (Author)";
            lblCategory.Text = category;
            lblISBN.Text = $"ISBN-10: {isbn}";
            lblPrice.Text = $"Php. {price}";
            lblStock.Text = $"({stock}) on stock";
            lblDescription.Text = description;
        }
    }
}