using System;
using System.Drawing;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class BookCard : UserControl
    {
        // Public events for buttons
        public event EventHandler Button1Click;
        public event EventHandler Button2Click;

        public BookCard()
        {
            InitializeComponent();

            // Wire up button events
            btn_Edit.Click += (s, e) => Button1Click?.Invoke(this, e);
            btn_Delete.Click += (s, e) => Button2Click?.Invoke(this, e);
        }

        public void SetBookData(
            Image cover,
            string title,
            string author,
            string category,
            string isbn,
            decimal price,
            int stock)
        {
            pictureBoxCover.Image = cover;
            lblTitle.Text = title;
            lblAuthor.Text = $"by {author} (Author)";
            lblCategory.Text = category;
            lblISBN.Text = $"ISBN-10: {isbn}";
            lblPrice.Text = $"Php. {price}";
            lblStock.Text = $"({stock}) on stock";
        }
    }
}