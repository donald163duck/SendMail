using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SendMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtmail_Enter(object sender, EventArgs e)
        {
            if (txtmail.Text == " Email")
            {
                txtmail.Clear();
                txtmail.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtmail_Leave(object sender, EventArgs e)
        {
            if (txtmail.Text == "")
            {
                txtmail.ForeColor = Color.FromArgb(200, 200, 200);
                txtmail.Text = " Email";
            }
        }

        private void txtsub_Enter(object sender, EventArgs e)
        {
            if (txtsub.Text == " Subject")
            {
                txtsub.Clear();
                txtsub.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtsub_Leave(object sender, EventArgs e)
        {
            if (txtsub.Text == "")
            {
                txtsub.ForeColor = Color.FromArgb(200, 200, 200);
                txtsub.Text = " Subject";
            }
        }

        private void txtmess_Enter(object sender, EventArgs e)
        {
            if (txtmess.Text == " Message")
            {
                txtmess.Clear();
                txtmess.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtmess_Leave(object sender, EventArgs e)
        {
            if (txtmess.Text == "")
            {
                txtmess.ForeColor = Color.FromArgb(200, 200, 200);
                txtmess.Text = " Subject";
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            string to, from, pass, messageBody;
            MailMessage message = new MailMessage();
            to = txtmail.Text;
            from = "alexpodrolla@gmail.com";
            pass = "********";
            messageBody = txtmess.Text;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = "From : " + "<br>Message: " + messageBody;
            message.Subject = txtsub.Text;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                DialogResult code = MessageBox.Show("Email успешно отправлен!", "Email отправлен!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (code == DialogResult.OK)
                {
                    txtmail.Clear();
                    txtsub.Clear();
                    txtmess.Clear();

                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
