using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace WindowsFormsApp1
{
    internal static class Theme
    {
        private static readonly Color Primary = Color.FromArgb(64, 115, 255);
        private static readonly Color PrimaryAlt = Color.FromArgb(0, 200, 255);
        private static readonly Color Surface = Color.White;
        private static readonly Color SurfaceAlt = Color.FromArgb(245, 247, 250);
        private static readonly Color TextPrimary = Color.FromArgb(22, 28, 45);
        private static readonly Color TextSecondary = Color.FromArgb(84, 95, 125);

        public static void Apply(Form form)
        {
            if (form == null) return;

            form.BackColor = Surface;
            form.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            form.ForeColor = TextPrimary;

            ApplyToChildren(form);

            // If form is borderless-capable (uses a header), add soft shadow
            try
            {
                var _ = new Guna2ShadowForm(form);
            }
            catch { /* ignore if design/runtime environment lacks Guna2 */ }
        }

        // Overload to apply theme to any Control (e.g., UserControl)
        public static void Apply(Control root)
        {
            if (root == null) return;
            root.BackColor = Surface;
            root.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            root.ForeColor = TextPrimary;
            ApplyToChildren(root);
        }

        private static void ApplyToChildren(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                switch (control)
                {
                    case Label label:
                        label.ForeColor = label.Font.Bold ? Surface : TextPrimary;
                        if (!label.Font.Bold)
                            label.ForeColor = TextPrimary;
                        break;

                    case Button button:
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        button.BackColor = Primary;
                        button.ForeColor = Color.White;
                        button.Cursor = Cursors.Hand;
                        break;

                    case TextBox textBox:
                        textBox.BorderStyle = BorderStyle.FixedSingle;
                        textBox.BackColor = Surface;
                        textBox.ForeColor = TextPrimary;
                        break;

                    case Panel panel:
                        // keep special panels light
                        if (panel.BackgroundImage == null)
                            panel.BackColor = SurfaceAlt;
                        break;

                    case DataGridView grid:
                        grid.BackgroundColor = Surface;
                        grid.EnableHeadersVisualStyles = false;
                        grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
                        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        grid.DefaultCellStyle.BackColor = Surface;
                        grid.DefaultCellStyle.ForeColor = TextPrimary;
                        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
                        break;
                }

                // Optional styling for Guna2 controls when present
                if (control is Guna2Panel gPanel)
                {
                    gPanel.FillColor = gPanel.Parent is Form ? Surface : SurfaceAlt;
                    gPanel.ShadowDecoration.Enabled = true;
                }

                if (control is Guna2GradientPanel gGrad)
                {
                    gGrad.FillColor = Primary;
                    gGrad.FillColor2 = PrimaryAlt;
                }

                if (control is Guna2Button gButton)
                {
                    gButton.BorderRadius = 10;
                    gButton.FillColor = Surface;
                    gButton.ForeColor = TextPrimary;
                    gButton.HoverState.FillColor = Primary;
                    gButton.HoverState.ForeColor = Color.White;
                }

                if (control is Guna2ControlBox gBox)
                {
                    gBox.FillColor = Color.Transparent;
                    gBox.IconColor = Color.White;
                    gBox.HoverState.FillColor = Color.FromArgb(0, 0, 0, 24);
                }

                // Recurse
                if (control.HasChildren)
                {
                    ApplyToChildren(control);
                }
            }
        }
    }
}


