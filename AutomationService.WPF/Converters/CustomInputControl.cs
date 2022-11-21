using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomationService.WPF.Converters
{
    public static class CustomInputControl
    {
        public static string GetNewFileName()
        {
            Form inputBox = new Form();
            inputBox.Width = 400;
            inputBox.Height = 200;
            inputBox.Text = "DOSYA ADI DEĞİŞTİRME";
            inputBox.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label
            {
                Left = 40,
                Top = 40,
                Text = "Yeni Dosya Adı"
            };

            TextBox txtInput = new TextBox
            {
                Left = 40,
                Top = 70,
                Width = 200,                
            };

            Button btnConfirm = new Button
            {
                Text = "OK",
                Left = 40,
                Top = 100,
                Width = 100
            };

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Left = 100,
                Top = 100,
                Width = 100
            };

            btnConfirm.Click += (sender, e) => { inputBox.Close(); };

            inputBox.Controls.Add(lbl);
            inputBox.Controls.Add(txtInput);
            inputBox.Controls.Add(btnConfirm);

            inputBox.ShowDialog();

            string replacedFileName = NameOperation.CharacterRegulatory(txtInput.Text);

            return replacedFileName;
        }

    }
}