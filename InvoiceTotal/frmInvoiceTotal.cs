using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* ******************************************************
* CIS 123: Introduction to Object-Oriented Programming  *
* Murach C# 7th ed                                      *
* Chapter 7: How to handle exception and validate data  *
* Exercise 7-1 Enhance the Invoice Total application    *
*       Base code and form design provided by Murach    *
*       Exercise Instructions: pg. 220                  *
* Dominique Tepper, 10MAY2022                           *
* ******************************************************/


namespace InvoiceTotal
{
	public partial class frmInvoiceTotal : Form
	{
        public frmInvoiceTotal()
		{
			InitializeComponent();
		}

/* ***********************************************************************************
*   2-A. Add a try-catch statement to the btnCalculate_Click() method so it catches  *
*        any exception that the ToDecimal() method of the Convert class might have   *
* ************************************************************************** Tepper */
		private void btnCalculate_Click(object sender, EventArgs e)
		{
			decimal subtotal = 0m;
			
			try
            {
                decimal v = Convert.ToDecimal(txtSubtotal.Text);
                subtotal = v;
			}

/************************************************************************************
*  2-B. The catch block should display a dialog box like the one in Figure 7.2.     *
* ************************************************************************* Tepper */

			catch
			{
				MessageBox.Show("Please enter a valid number for the subtotal field.", "Entry Error");
			}

			decimal discountPercent = .25m;
			decimal discountAmount = subtotal * discountPercent;
			decimal invoiceTotal = subtotal - discountAmount;



			discountAmount = Math.Round(discountAmount, 2);
			invoiceTotal = Math.Round(invoiceTotal, 2);

			txtDiscountPercent.Text = discountPercent.ToString("p1");
			txtDiscountAmount.Text = discountAmount.ToString();
			txtTotal.Text = invoiceTotal.ToString();

			txtSubtotal.Focus();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}