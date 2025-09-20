using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation
{
    public class NavigationManager
    {
        private Panel panel;
        private Stack<Form> stack = new Stack<Form>();

        public NavigationManager(Panel panel)
        {
            this.panel = panel;
        }

        // Push صفحة جديدة على الـ panel (يحفظ السابقة على الستاك)
        public void Push(Form form)
        {
            // افصل (remove) الشاشة الحالية إذا وُجدت وحفِظها على الستاك
            if (panel.Controls.Count > 0)
            {
                var current = panel.Controls[panel.Controls.Count - 1] as Form;
                if (current != null)
                {
                    panel.Controls.Remove(current);
                    current.Hide();
                    stack.Push(current);
                }
            }

            // إعداد وإضافة الشاشة الجديدة
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            form.Show();
        }

        // Pop: أزل الحالية وأعد السابقة من الستاك (إن وُجدت)
        public void Pop()
        {
            // أزل الحالية
            if (panel.Controls.Count > 0)
            {
                var current = panel.Controls[panel.Controls.Count - 1] as Form;
                if (current != null)
                {
                    panel.Controls.Remove(current);
                    current.Hide();
                    // لا ن Dispose() لأننا نريد الحفاظ على الحالة للـ previous
                }
            }

            // أعد السابقة إن وُجدت
            if (stack.Count > 0)
            {
                var prev = stack.Pop();
                prev.TopLevel = false;
                prev.FormBorderStyle = FormBorderStyle.None;
                prev.Dock = DockStyle.Fill;
                panel.Controls.Add(prev);
                prev.Show();
            }
        }

        // لو احتجت تفرّغ الستاك (مثلاً عند الخروج النهائي)
        public void ClearStack()
        {
            while (stack.Count > 0)
            {
                var f = stack.Pop();
                f.Dispose();
            }
        }
    }
}
