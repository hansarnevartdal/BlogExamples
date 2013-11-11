using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Windows;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.Constants;

namespace Airline.IdentityServer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserName.SelectedIndex = 0;
        }

        private void CreateTokenButton_Click(object sender, RoutedEventArgs e)
        {
            var principal = Principal.Create(AuthenticationTypes.Password, new Claim(ClaimTypes.Name, UserName.Text));
            
            var sts = new Thinktecture.IdentityServer.Protocols.STS();
            SecurityToken token;

            var success = sts.TryIssueToken(
                new EndpointReference("https://booking.oceanicairlines.com/"),
                principal,
                TokenTypes.JsonWebToken,
                out token);

            if (success)
            {
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                Output.Text = "Encoded JWT token:" + Environment.NewLine + tokenString + Environment.NewLine + Environment.NewLine;
                var tokenParts = tokenString.Split('.');
                Output.Text += "JWT header:" + Environment.NewLine + DecodeBase64(tokenParts[0]) + Environment.NewLine + Environment.NewLine;
                Output.Text += "JWT body:" + Environment.NewLine + DecodeBase64(tokenParts[1]) + Environment.NewLine + Environment.NewLine;
                Output.Text += "JWT signature:" + Environment.NewLine + tokenParts[2];
            }
            else
            {
                Output.Text = "Could not issue token.";
            }
        }

        private static string DecodeBase64(string encodedText)
        {
            var s = encodedText.Length % 4;
            if (s > 2)
            {
                s = 1;
            }
            encodedText = encodedText.PadRight(encodedText.Length + s, '=');
            var decodedBytes = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(decodedBytes);
        }
    }
}
