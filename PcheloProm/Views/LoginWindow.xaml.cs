using System.Linq;
using System.Windows;
using System.Windows.Input;
using PcheloProm.Models;

namespace PcheloProm.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }
    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            this.DragMove();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            lblError.Text = "Заполните все поля!";
            return;
        }

        using (PcheloPromContext context = new PcheloPromContext())
        {
            var user = context.Users
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            if (user != null)
            {
                if (!user.IsActive)
                {
                    lblError.Text = "Ваш аккаунт заблокирован администратором!";
                    return;
                }

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                lblError.Text = "Неверный логин или пароль!";
            }
        }
    }
}