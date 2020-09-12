namespace IPAGEBiblioteca.Controllers.Helps
{
    using DevExpress.XtraBars.Docking2010.Customization;
    using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
    using System.Windows.Forms;

    public class OpenFormsDialog: FlyoutDialog
    {
        public OpenFormsDialog(Form owner, FlyoutAction actions, Control UserControleToShow)
          : base(owner, actions)
        {
            this.Properties.HeaderOffset = 0;
            Properties.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            Properties.Style = FlyoutStyle.Popup;
            FlyoutControl = UserControleToShow;
        }
        public static DialogResult ShowForm(Form owner, FlyoutAction actions, Control UserControleToShow)
        {
            OpenFormsDialog customFlyout = new OpenFormsDialog(owner, actions, UserControleToShow);
            customFlyout.FormClosing += delegate { UserControleToShow.Dispose(); };
            return customFlyout.ShowDialog();
        }
        public static DialogResult ShowForm(FlyoutAction actions, Control UserControleToShow)
        {
            OpenFormsDialog customFlyout = new OpenFormsDialog(new Form { Width = 100, Height = 200 }, actions, UserControleToShow) ;
            customFlyout.FormClosing += delegate { UserControleToShow.Dispose(); };
            return customFlyout.ShowDialog();
        }

    }
}
