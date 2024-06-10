using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _9
{
    public partial class SendEmail2 : Window
    {
        private string _filePath;
        public SendEmail2(string filePath)
        {
            InitializeComponent();
            _filePath = filePath;

            MinHeight = 200;
            MinWidth = 400;
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage(log.Text, forr.Text, theme.Text, "письмо");

                if (File.Exists(_filePath))
                {
                    mail.Attachments.Add(new Attachment(_filePath));
                }

                else
                {
                    MessageBox.Show("Выбран неверный файл!");
                }

                SmtpClient smtp = new SmtpClient();

                if (log.Text.Contains("@mail.ru"))
                {
                    smtp.Host = "smtp.mail.ru";
                    smtp.Port = 587;
                }
                else if (log.Text.Contains("@yandex.ru"))
                {
                    smtp.Host = "smtp.yandex.ru";
                    smtp.Port = 25;
                }
                else if (log.Text.Contains("@rambler.ru"))
                {
                    smtp.Host = "smtp.rambler.ru";
                    smtp.Port = 25;
                }
                else if (log.Text.Contains("@gmail.com"))
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                }
                else
                {
                    MessageBox.Show("Неверный хост или домен");
                }

                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(log.Text, pass.Text);

                try
                {
                    smtp.Send(mail);
                    MessageBox.Show("Письмо успешно отправлено!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при отправке письма: " + ex);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Вы не ввели данные для отправки!");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }
    }
}