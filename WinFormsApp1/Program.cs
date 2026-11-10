using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LabsVariant22
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    // =========================================================================
    // ГЛАВНОЕ ОКНО (ВЫБОР ЛАБОРАТОРНОЙ РАБОТЫ)
    // =========================================================================
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Лабораторные работы № 3–7 | Вариант 22";
            this.Size = new Size(520, 430);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 250);

            Label lblTitle = new Label
            {
                Text = "Выберите лабораторную работу (Вариант 22)",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60,
                ForeColor = Color.FromArgb(30, 41, 59)
            };
            this.Controls.Add(lblTitle);

            var labs = new (string Title, Func<Form> Creator)[]
            {
                ("Лабораторная работа № 3: Разветвленные алгоритмы", () => new FormLab3()),
                ("Лабораторная работа № 4: Циклические алгоритмы", () => new FormLab4()),
                ("Лабораторная работа № 5: Одномерные массивы", () => new FormLab5()),
                ("Лабораторная работа № 6: Двумерные массивы", () => new FormLab6()),
                ("Лабораторная работа № 7: Программирование с функциями", () => new FormLab7())
            };

            int y = 70;
            foreach (var lab in labs)
            {
                Button btn = new Button
                {
                    Text = lab.Title,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Size = new Size(440, 50),
                    Location = new Point(32, y),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(12, 0, 0, 0)
                };
                btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                var creator = lab.Creator;
                btn.Click += (s, e) =>
                {
                    using (Form f = creator())
                    {
                        f.ShowDialog(this);
                    }
                };
                this.Controls.Add(btn);
                y += 62;
            }
        }
    }

    // =========================================================================
    // ЛАБОРАТОРНАЯ РАБОТА № 3: РАЗВЕТВЛЕННЫЕ АЛГОРИТМЫ (ВАРИАНТ 22)
    // =========================================================================
    public class FormLab3 : Form
    {
        private TextBox txtLetter;
        private Label lblAnimalResult;
        private NumericUpDown numOct1, numOct2;
        private Label lblOctSumResult;

        public FormLab3()
        {
            this.Text = "Лабораторная работа № 3 — Вариант 22";
            this.Size = new Size(680, 440);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };

            // --- Уровень 1 ---
            TabPage tab1 = new TabPage("Уровень 1 (Задача 22)");
            Label lblDesc1 = new Label
            {
                Text = "Задание 22 (Уровень 1):\nНапишите программу с использованием оператора выбора (switch), которая по введенной первой букве названия животного напечатает полностью название животного (собака, кошка, жираф, лошадь, обезьяна).",
                Location = new Point(20, 20),
                Size = new Size(610, 65),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblPrompt1 = new Label { Text = "Введите первую букву (с, к, ж, л, о):", Location = new Point(20, 105), AutoSize = true };
            txtLetter = new TextBox { Location = new Point(280, 102), Width = 60, MaxLength = 1, Text = "с" };
            Button btnCalc1 = new Button { Text = "Определить животное", Location = new Point(360, 100), Size = new Size(180, 30) };
            lblAnimalResult = new Label
            {
                Text = "Результат: —",
                Location = new Point(20, 155),
                Size = new Size(600, 40),
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            btnCalc1.Click += BtnCalc1_Click;
            tab1.Controls.AddRange(new Control[] { lblDesc1, lblPrompt1, txtLetter, btnCalc1, lblAnimalResult });

            // --- Уровень 2 ---
            TabPage tab2 = new TabPage("Уровень 2 (Задача 22)");
            Label lblDesc2 = new Label
            {
                Text = "Задание 22 (Уровень 2):\nДаны две цифры в восьмеричной системе счисления (от 0 до 7). Напишите программу, которая выводит названия на русском языке цифр суммы этих двух цифр (в восьмеричной и десятичной записи).",
                Location = new Point(20, 20),
                Size = new Size(610, 65),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblOct1 = new Label { Text = "Первая восьмеричная цифра (0–7):", Location = new Point(20, 105), AutoSize = true };
            numOct1 = new NumericUpDown { Location = new Point(270, 102), Width = 70, Minimum = 0, Maximum = 7, Value = 5 };
            Label lblOct2 = new Label { Text = "Вторая восьмеричная цифра (0–7):", Location = new Point(20, 145), AutoSize = true };
            numOct2 = new NumericUpDown { Location = new Point(270, 142), Width = 70, Minimum = 0, Maximum = 7, Value = 6 };
            Button btnCalc2 = new Button { Text = "Вычислить сумму", Location = new Point(360, 120), Size = new Size(180, 32) };
            lblOctSumResult = new Label
            {
                Text = "Результат: —",
                Location = new Point(20, 195),
                Size = new Size(610, 110),
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            btnCalc2.Click += BtnCalc2_Click;
            tab2.Controls.AddRange(new Control[] { lblDesc2, lblOct1, numOct1, lblOct2, numOct2, btnCalc2, lblOctSumResult });

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            this.Controls.Add(tabs);
        }

        private void BtnCalc1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLetter.Text))
            {
                MessageBox.Show("Пожалуйста, введите букву.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            char ch = char.ToLower(txtLetter.Text.Trim()[0]);
            string animal;
            switch (ch)
            {
                case 'с': animal = "собака"; break;
                case 'к': animal = "кошка"; break;
                case 'ж': animal = "жираф"; break;
                case 'л': animal = "лошадь"; break;
                case 'о': animal = "обезьяна"; break;
                default: animal = "Животное на такую букву не найдено в списке (доступны: с, к, ж, л, о)"; break;
            }
            lblAnimalResult.Text = $"Результат: {animal}";
        }

        private string DigitToRussianWord(int digit)
        {
            switch (digit)
            {
                case 0: return "ноль";
                case 1: return "один";
                case 2: return "два";
                case 3: return "три";
                case 4: return "четыре";
                case 5: return "пять";
                case 6: return "шесть";
                case 7: return "семь";
                case 8: return "восемь";
                case 9: return "девять";
                default: return "";
            }
        }

        private void BtnCalc2_Click(object sender, EventArgs e)
        {
            int d1 = (int)numOct1.Value;
            int d2 = (int)numOct2.Value;
            int sumDec = d1 + d2;

            // Представление суммы в восьмеричной системе счисления
            string octWords = sumDec >= 8
                ? $"{DigitToRussianWord(sumDec / 8)} {DigitToRussianWord(sumDec % 8)}"
                : DigitToRussianWord(sumDec);
            string octDigits = Convert.ToString(sumDec, 8);

            // Представление суммы в десятичной системе счисления
            string decWords = sumDec >= 10
                ? $"{DigitToRussianWord(sumDec / 10)} {DigitToRussianWord(sumDec % 10)}"
                : DigitToRussianWord(sumDec);

            lblOctSumResult.Text =
                $"Сумма в восьмеричной СС ({d1}₈ + {d2}₈ = {octDigits}₈): {octWords}\n\n" +
                $"Сумма в десятичной СС ({d1} + {d2} = {sumDec}₁₀): {decWords}";
        }
    }

    // =========================================================================
    // ЛАБОРАТОРНАЯ РАБОТА № 4: ЦИКЛИЧЕСКИЕ АЛГОРИТМЫ (ВАРИАНТ 22)
    // =========================================================================
    public class FormLab4 : Form
    {
        private TextBox txtX, txtDx;
        private ListBox lstSteps1;
        private Label lblResult1;

        private NumericUpDown numY2, numX2;
        private ListBox lstSteps2;
        private Label lblResult2;

        public FormLab4()
        {
            this.Text = "Лабораторная работа № 4 — Вариант 22";
            this.Size = new Size(720, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };

            // --- Уровень 1 ---
            TabPage tab1 = new TabPage("Уровень 1 (Задача 22)");
            Label lblDesc1 = new Label
            {
                Text = "Задание 22 (Уровень 1):\nДаны действительные числа x, dx. Вычислите s = Σ (i=1..15) (5 + sin(x_i²)), где x_i = x_{i-1} + dx.",
                Location = new Point(20, 15),
                Size = new Size(650, 45),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblX = new Label { Text = "Начальное x (x₀):", Location = new Point(20, 75), AutoSize = true };
            txtX = new TextBox { Location = new Point(160, 72), Width = 90, Text = "1,0" };
            Label lblDx = new Label { Text = "Шаг dx:", Location = new Point(270, 75), AutoSize = true };
            txtDx = new TextBox { Location = new Point(340, 72), Width = 90, Text = "0,2" };
            Button btnCalc1 = new Button { Text = "Вычислить сумму S", Location = new Point(450, 70), Size = new Size(180, 30) };

            lstSteps1 = new ListBox { Location = new Point(20, 115), Size = new Size(650, 260), Font = new Font("Consolas", 9.5f) };
            lblResult1 = new Label
            {
                Text = "Итоговая сумма S = —",
                Location = new Point(20, 390),
                Size = new Size(650, 35),
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            btnCalc1.Click += BtnCalc1_Click;
            tab1.Controls.AddRange(new Control[] { lblDesc1, lblX, txtX, lblDx, txtDx, btnCalc1, lstSteps1, lblResult1 });

            // --- Уровень 2 ---
            TabPage tab2 = new TabPage("Уровень 2 (Задача 22)");
            Label lblDesc2 = new Label
            {
                Text = "Задание 22 (Уровень 2):\nДаны целые числа y, x. Вычислите P = Π (k=1..10) ( ∛|y| + Σ (i=k+1..9) (i² + x) ).",
                Location = new Point(20, 15),
                Size = new Size(650, 45),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblY2 = new Label { Text = "Целое число y:", Location = new Point(20, 75), AutoSize = true };
            numY2 = new NumericUpDown { Location = new Point(140, 72), Width = 90, Minimum = -10000, Maximum = 10000, Value = 8 };
            Label lblX2 = new Label { Text = "Целое число x:", Location = new Point(250, 75), AutoSize = true };
            numX2 = new NumericUpDown { Location = new Point(370, 72), Width = 90, Minimum = -10000, Maximum = 10000, Value = 2 };
            Button btnCalc2 = new Button { Text = "Вычислить произведение", Location = new Point(480, 70), Size = new Size(190, 30) };

            lstSteps2 = new ListBox { Location = new Point(20, 115), Size = new Size(650, 260), Font = new Font("Consolas", 9.5f) };
            lblResult2 = new Label
            {
                Text = "Итоговое произведение P = —",
                Location = new Point(20, 390),
                Size = new Size(650, 35),
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            btnCalc2.Click += BtnCalc2_Click;
            tab2.Controls.AddRange(new Control[] { lblDesc2, lblY2, numY2, lblX2, numX2, btnCalc2, lstSteps2, lblResult2 });

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            this.Controls.Add(tabs);
        }

        private static bool TryParseDouble(string input, out double val)
        {
            string normalized = input.Trim().Replace(',', '.');
            return double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out val);
        }

        private void BtnCalc1_Click(object sender, EventArgs e)
        {
            if (!TryParseDouble(txtX.Text, out double x) || !TryParseDouble(txtDx.Text, out double dx))
            {
                MessageBox.Show("Введите корректные вещественные числа x и dx.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstSteps1.Items.Clear();
            double s = 0;
            double xi = x;
            for (int i = 1; i <= 15; i++)
            {
                xi = xi + dx;
                double term = 5.0 + Math.Sin(xi * xi);
                s += term;
                lstSteps1.Items.Add($"i = {i,2}:  x_{i} = {xi,8:F4}   5 + sin(x_{i}²) = {term,9:F6}   Текущая S = {s,10:F6}");
            }
            lblResult1.Text = $"Итоговая сумма S = {s:F6}";
        }

        private void BtnCalc2_Click(object sender, EventArgs e)
        {
            int y = (int)numY2.Value;
            int x = (int)numX2.Value;

            lstSteps2.Items.Clear();
            double cbrtAbsY = Math.Pow(Math.Abs((double)y), 1.0 / 3.0);
            double prod = 1.0;

            for (int k = 1; k <= 10; k++)
            {
                long innerSum = 0;
                for (int i = k + 1; i <= 9; i++)
                {
                    innerSum += (long)i * i + x;
                }
                double factor = cbrtAbsY + innerSum;
                prod *= factor;
                lstSteps2.Items.Add($"k = {k,2}:  ∛|{y}| = {cbrtAbsY:F4},  Σ(i={k + 1}..9) = {innerSum,4},  множитель = {factor,9:F4}");
            }
            lblResult2.Text = $"Итоговое произведение P = {prod:G10}";
        }
    }

    // =========================================================================
    // ЛАБОРАТОРНАЯ РАБОТА № 5: ОДНОМЕРНЫЕ МАССИВЫ (ВАРИАНТ 22)
    // =========================================================================
    public class FormLab5 : Form
    {
        private TextBox txtArr1;
        private Label lblRes1;

        private NumericUpDown numN2;
        private TextBox txtArrA2, txtArrB2;
        private Label lblRes2;

        private Random rnd = new Random();

        public FormLab5()
        {
            this.Text = "Лабораторная работа № 5 — Вариант 22";
            this.Size = new Size(740, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };

            // --- Уровень 1 ---
            TabPage tab1 = new TabPage("Уровень 1 (Задача 22)");
            Label lblDesc1 = new Label
            {
                Text = "Задание 22 (Уровень 1):\nДан целочисленный массив a[10]. Найдите наибольшее из чисел, значения которых кратны 5 и не кратны 7, в последовательности чисел a[10]. Предусмотрите ситуацию, когда таких чисел нет.",
                Location = new Point(20, 20),
                Size = new Size(670, 60),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblPrompt1 = new Label { Text = "Элементы массива a[10] (через пробел):", Location = new Point(20, 95), AutoSize = true };
            txtArr1 = new TextBox { Location = new Point(20, 120), Width = 670, Text = "15 35 25 -10 70 45 12 8 50 105" };
            Button btnGen1 = new Button { Text = "Заполнить случайно", Location = new Point(20, 160), Size = new Size(180, 32) };
            Button btnCalc1 = new Button { Text = "Найти максимум", Location = new Point(215, 160), Size = new Size(180, 32) };
            lblRes1 = new Label
            {
                Text = "Результат: —",
                Location = new Point(20, 215),
                Size = new Size(670, 120),
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            btnGen1.Click += (s, e) =>
            {
                int[] arr = new int[10];
                for (int i = 0; i < 10; i++) arr[i] = rnd.Next(-50, 100);
                txtArr1.Text = string.Join(" ", arr);
            };
            btnCalc1.Click += BtnCalc1_Click;
            tab1.Controls.AddRange(new Control[] { lblDesc1, lblPrompt1, txtArr1, btnGen1, btnCalc1, lblRes1 });

            // --- Уровень 2 ---
            TabPage tab2 = new TabPage("Уровень 2 (Задача 22)");
            Label lblDesc2 = new Label
            {
                Text = "Задание 22 (Уровень 2):\nДаны натуральное число n и целочисленные массивы a[n] и b[n]. Из массива a выберите элементы, которые меньше максимального элемента среди чисел массива b, значения которых кратны 3. Возможно, что таких чисел нет.",
                Location = new Point(20, 15),
                Size = new Size(670, 60),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblN2 = new Label { Text = "Размер массивов n:", Location = new Point(20, 85), AutoSize = true };
            numN2 = new NumericUpDown { Location = new Point(170, 82), Width = 70, Minimum = 1, Maximum = 50, Value = 8 };
            Button btnGen2 = new Button { Text = "Сгенерировать a[n] и b[n]", Location = new Point(260, 80), Size = new Size(200, 30) };
            Button btnCalc2 = new Button { Text = "Выполнить отбор", Location = new Point(475, 80), Size = new Size(180, 30) };

            Label lblA2 = new Label { Text = "Массив a[n]:", Location = new Point(20, 125), AutoSize = true };
            txtArrA2 = new TextBox { Location = new Point(20, 148), Width = 670, Text = "4 18 12 25 9 30 7 15" };
            Label lblB2 = new Label { Text = "Массив b[n]:", Location = new Point(20, 185), AutoSize = true };
            txtArrB2 = new TextBox { Location = new Point(20, 208), Width = 670, Text = "5 12 21 8 14 6 19 10" };

            lblRes2 = new Label
            {
                Text = "Результат: —",
                Location = new Point(20, 250),
                Size = new Size(670, 140),
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };

            btnGen2.Click += (s, e) =>
            {
                int n = (int)numN2.Value;
                int[] a = new int[n];
                int[] b = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = rnd.Next(-20, 40);
                    b[i] = rnd.Next(-20, 40);
                }
                txtArrA2.Text = string.Join(" ", a);
                txtArrB2.Text = string.Join(" ", b);
            };
            btnCalc2.Click += BtnCalc2_Click;
            tab2.Controls.AddRange(new Control[] { lblDesc2, lblN2, numN2, btnGen2, btnCalc2, lblA2, txtArrA2, lblB2, txtArrB2, lblRes2 });

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            this.Controls.Add(tabs);
        }

        private void BtnCalc1_Click(object sender, EventArgs e)
        {
            string[] parts = txtArr1.Text.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 10)
            {
                MessageBox.Show($"Требуется ввести ровно 10 целых чисел (сейчас введено: {parts.Length}).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int[] a = new int[10];
            for (int i = 0; i < 10; i++)
            {
                if (!int.TryParse(parts[i], out a[i]))
                {
                    MessageBox.Show($"Некорректное целое число: {parts[i]}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bool found = false;
            int maxVal = int.MinValue;
            List<int> matching = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                if (a[i] % 5 == 0 && a[i] % 7 != 0)
                {
                    matching.Add(a[i]);
                    if (!found || a[i] > maxVal)
                    {
                        maxVal = a[i];
                        found = true;
                    }
                }
            }

            if (found)
            {
                lblRes1.Text = $"Числа, кратные 5 и не кратные 7: {string.Join(", ", matching)}\n\n" +
                               $"Наибольшее из них: {maxVal}";
            }
            else
            {
                lblRes1.Text = "В массиве a[10] нет чисел, которые одновременно кратны 5 и не кратны 7.";
            }
        }

        private void BtnCalc2_Click(object sender, EventArgs e)
        {
            string[] partsA = txtArrA2.Text.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] partsB = txtArrB2.Text.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int n = (int)numN2.Value;

            if (partsA.Length != n || partsB.Length != n)
            {
                MessageBox.Show($"Количество элементов в обоих массивах должно быть равно n = {n} (сейчас в A: {partsA.Length}, в B: {partsB.Length}).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] a = new int[n];
            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(partsA[i], out a[i]) || !int.TryParse(partsB[i], out b[i]))
                {
                    MessageBox.Show("Все элементы массивов должны быть целыми числами.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bool foundMult3 = false;
            int maxMult3InB = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                if (b[i] % 3 == 0)
                {
                    if (!foundMult3 || b[i] > maxMult3InB)
                    {
                        maxMult3InB = b[i];
                        foundMult3 = true;
                    }
                }
            }

            if (!foundMult3)
            {
                lblRes2.Text = "В массиве b[n] нет ни одного элемента, кратного 3.";
                return;
            }

            List<int> selectedFromA = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (a[i] < maxMult3InB)
                {
                    selectedFromA.Add(a[i]);
                }
            }

            if (selectedFromA.Count > 0)
            {
                lblRes2.Text = $"Максимальный элемент массива b, кратный 3: {maxMult3InB}\n\n" +
                               $"Элементы массива a, меньшие {maxMult3InB} ({selectedFromA.Count} шт.):\n" +
                               string.Join(", ", selectedFromA);
            }
            else
            {
                lblRes2.Text = $"Максимальный элемент массива b, кратный 3: {maxMult3InB}\n\n" +
                               $"В массиве a нет элементов, меньших {maxMult3InB}.";
            }
        }
    }

    // =========================================================================
    // ЛАБОРАТОРНАЯ РАБОТА № 6: ДВУМЕРНЫЕ МАССИВЫ (ВАРИАНТ 22)
    // =========================================================================
    public class FormLab6 : Form
    {
        private DataGridView dgv1;
        private Label lblRes1;

        private NumericUpDown numN2, numM2;
        private DataGridView dgv2;
        private Label lblRes2;

        private Random rnd = new Random();

        public FormLab6()
        {
            this.Text = "Лабораторная работа № 6 — Вариант 22";
            this.Size = new Size(780, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };

            // --- Уровень 1 ---
            TabPage tab1 = new TabPage("Уровень 1 (Задача 22)");
            Label lblDesc1 = new Label
            {
                Text = "Задание 22 (Уровень 1):\nДана вещественная матрица размером 4 строки, 5 столбцов. Определите числа b1..b5, равные среднему арифметическому значению максимального и минимального элементов каждого столбца.",
                Location = new Point(20, 15),
                Size = new Size(710, 50),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Button btnGen1 = new Button { Text = "Заполнить матрицу 4×5", Location = new Point(20, 70), Size = new Size(200, 30) };
            Button btnCalc1 = new Button { Text = "Рассчитать b1..b5", Location = new Point(235, 70), Size = new Size(180, 30) };

            dgv1 = CreateMatrixGrid(4, 5, new Point(20, 115), new Size(710, 165));
            lblRes1 = new Label
            {
                Text = "Результат b1..b5: —",
                Location = new Point(20, 295),
                Size = new Size(710, 160),
                Font = new Font("Consolas", 10f, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            btnGen1.Click += (s, e) => FillGridRandomDouble(dgv1, 4, 5);
            btnCalc1.Click += BtnCalc1_Click;
            FillGridRandomDouble(dgv1, 4, 5);
            tab1.Controls.AddRange(new Control[] { lblDesc1, btnGen1, btnCalc1, dgv1, lblRes1 });

            // --- Уровень 2 ---
            TabPage tab2 = new TabPage("Уровень 2 (Задача 22)");
            Label lblDesc2 = new Label
            {
                Text = "Задание 22 (Уровень 2):\nДана целочисленная матрица размером n строк, m столбцов. Найдите столбец, сумма элементов которого минимальна, и упорядочьте этот столбец матрицы по убыванию значений элементов.",
                Location = new Point(20, 15),
                Size = new Size(710, 50),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblN2 = new Label { Text = "Строк n:", Location = new Point(20, 75), AutoSize = true };
            numN2 = new NumericUpDown { Location = new Point(95, 72), Width = 60, Minimum = 2, Maximum = 12, Value = 4 };
            Label lblM2 = new Label { Text = "Столбцов m:", Location = new Point(170, 75), AutoSize = true };
            numM2 = new NumericUpDown { Location = new Point(265, 72), Width = 60, Minimum = 2, Maximum = 12, Value = 5 };
            Button btnGen2 = new Button { Text = "Создать и заполнить", Location = new Point(345, 70), Size = new Size(180, 30) };
            Button btnCalc2 = new Button { Text = "Найти и упорядочить", Location = new Point(540, 70), Size = new Size(190, 30) };

            dgv2 = CreateMatrixGrid(4, 5, new Point(20, 115), new Size(710, 220));
            lblRes2 = new Label
            {
                Text = "Результат: —",
                Location = new Point(20, 350),
                Size = new Size(710, 110),
                Font = new Font("Consolas", 10f, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            btnGen2.Click += (s, e) => FillGridRandomInt(dgv2, (int)numN2.Value, (int)numM2.Value);
            btnCalc2.Click += BtnCalc2_Click;
            FillGridRandomInt(dgv2, 4, 5);
            tab2.Controls.AddRange(new Control[] { lblDesc2, lblN2, numN2, lblM2, numM2, btnGen2, btnCalc2, dgv2, lblRes2 });

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            this.Controls.Add(tabs);
        }

        private DataGridView CreateMatrixGrid(int rows, int cols, Point location, Size size)
        {
            DataGridView dgv = new DataGridView
            {
                Location = location,
                Size = size,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersWidth = 65,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            SetupGridDimensions(dgv, rows, cols);
            return dgv;
        }

        private void SetupGridDimensions(DataGridView dgv, int rows, int cols)
        {
            dgv.Columns.Clear();
            for (int j = 0; j < cols; j++)
            {
                dgv.Columns.Add($"col{j}", $"Столбец {j + 1}");
            }
            dgv.Rows.Clear();
            dgv.Rows.Add(rows);
            for (int i = 0; i < rows; i++)
            {
                dgv.Rows[i].HeaderCell.Value = $"Строка {i + 1}";
            }
        }

        private void FillGridRandomDouble(DataGridView dgv, int rows, int cols)
        {
            SetupGridDimensions(dgv, rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    dgv[j, i].Value = Math.Round(rnd.NextDouble() * 40.0 - 10.0, 1).ToString("F1");
        }

        private void FillGridRandomInt(DataGridView dgv, int rows, int cols)
        {
            SetupGridDimensions(dgv, rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    dgv[j, i].Value = rnd.Next(-20, 50).ToString();
                    dgv[j, i].Style.BackColor = Color.White;
                }
        }

        private void BtnCalc1_Click(object sender, EventArgs e)
        {
            const int rows = 4, cols = 5;
            double[,] a = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string cellText = Convert.ToString(dgv1[j, i].Value) ?? "0";
                    if (!double.TryParse(cellText.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out a[i, j]))
                    {
                        MessageBox.Show($"Ошибка в ячейке [{i + 1}, {j + 1}]. Введите вещественное число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            double[] b = new double[cols];
            List<string> lines = new List<string>();
            for (int j = 0; j < cols; j++)
            {
                double min = a[0, j], max = a[0, j];
                for (int i = 1; i < rows; i++)
                {
                    if (a[i, j] < min) min = a[i, j];
                    if (a[i, j] > max) max = a[i, j];
                }
                b[j] = (min + max) / 2.0;
                lines.Add($"Столбец {j + 1}: min = {min,6:F2}, max = {max,6:F2}  =>  b{j + 1} = (min + max)/2 = {b[j],6:F2}");
            }

            lblRes1.Text = string.Join("\n", lines);
        }

        private void BtnCalc2_Click(object sender, EventArgs e)
        {
            int n = dgv2.RowCount;
            int m = dgv2.ColumnCount;
            int[,] a = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dgv2[j, i].Style.BackColor = Color.White;
                    string cellText = Convert.ToString(dgv2[j, i].Value) ?? "0";
                    if (!int.TryParse(cellText.Trim(), out a[i, j]))
                    {
                        MessageBox.Show($"Ошибка в ячейке [{i + 1}, {j + 1}]. Введите целое число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            int minCol = 0;
            int minSum = int.MaxValue;
            List<string> colSums = new List<string>();

            for (int j = 0; j < m; j++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++) sum += a[i, j];
                colSums.Add($"Ст.{j + 1}: {sum}");
                if (sum < minSum)
                {
                    minSum = sum;
                    minCol = j;
                }
            }

            // Сортировка столбца minCol по убыванию
            for (int i = 0; i < n - 1; i++)
            {
                for (int k = i + 1; k < n; k++)
                {
                    if (a[i, minCol] < a[k, minCol])
                    {
                        int tmp = a[i, minCol];
                        a[i, minCol] = a[k, minCol];
                        a[k, minCol] = tmp;
                    }
                }
            }

            // Обновление таблицы и подсветка отсортированного столбца
            for (int i = 0; i < n; i++)
            {
                dgv2[minCol, i].Value = a[i, minCol].ToString();
                dgv2[minCol, i].Style.BackColor = Color.FromArgb(220, 252, 231);
            }

            lblRes2.Text = $"Суммы по столбцам: {string.Join(" | ", colSums)}\n" +
                           $"Минимальная сумма = {minSum} (Столбец № {minCol + 1}).\n" +
                           $"Столбец № {minCol + 1} упорядочен по убыванию и выделен зеленым цветом в таблице.";
        }
    }

    // =========================================================================
    // ЛАБОРАТОРНАЯ РАБОТА № 7: ПРОГРАММИРОВАНИЕ С ФУНКЦИЯМИ (ВАРИАНТ 22)
    // =========================================================================
    public class FormLab7 : Form
    {
        private TextBox txtArrB;
        private Label lblRes1;

        private TextBox txtXStart, txtXEnd;
        private NumericUpDown numNSeries;
        private DataGridView dgvSeries;

        private Random rnd = new Random();

        public FormLab7()
        {
            this.Text = "Лабораторная работа № 7 — Вариант 22";
            this.Size = new Size(780, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };

            // --- Уровень 1 ---
            TabPage tab1 = new TabPage("Уровень 1 (Задача 22)");
            Label lblDesc1 = new Label
            {
                Text = "Задание 22 (Уровень 1):\nОпишите функцию sort_elem(a, n), которая выполняет сортировку по убыванию значений элементов в одномерном массиве вещественных чисел a размером n. С помощью этой функции выполните сортировку массива b размером nb.",
                Location = new Point(20, 20),
                Size = new Size(710, 60),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblPrompt1 = new Label { Text = "Массив вещественных чисел b (через пробел):", Location = new Point(20, 95), AutoSize = true };
            txtArrB = new TextBox { Location = new Point(20, 120), Width = 710, Text = "3.5 -1.2 8.4 0.5 12.1 -4.7 6.3 2.0" };
            Button btnGen1 = new Button { Text = "Случайный массив b", Location = new Point(20, 160), Size = new Size(190, 32) };
            Button btnCalc1 = new Button { Text = "Вызвать sort_elem(b, nb)", Location = new Point(225, 160), Size = new Size(220, 32) };
            lblRes1 = new Label
            {
                Text = "Отсортированный по убыванию массив b: —",
                Location = new Point(20, 215),
                Size = new Size(710, 120),
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            btnGen1.Click += (s, e) =>
            {
                double[] arr = new double[8];
                for (int i = 0; i < arr.Length; i++) arr[i] = Math.Round(rnd.NextDouble() * 30.0 - 10.0, 2);
                txtArrB.Text = string.Join(" ", arr.Select(v => v.ToString(CultureInfo.InvariantCulture)));
            };
            btnCalc1.Click += BtnCalc1_Click;
            tab1.Controls.AddRange(new Control[] { lblDesc1, lblPrompt1, txtArrB, btnGen1, btnCalc1, lblRes1 });

            // --- Уровень 2 ---
            TabPage tab2 = new TabPage("Уровень 2 (Задача 22)");
            Label lblDesc2 = new Label
            {
                Text = "Задание 22 (Уровень 2):\nФункция Y = 5^x. Разложение в ряд: S = 1 + (ln 5 / 1!)·x + (ln² 5 / 2!)·x² + ... + (ln^n 5 / n!)·x^n.\nДиапазон: 0.1 ≤ x ≤ 1.0, шаг H = (x_к - x_н)/10, n = 15. Вычисление с использованием рекурсивных функций.",
                Location = new Point(20, 15),
                Size = new Size(710, 60),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Italic)
            };
            Label lblXS = new Label { Text = "x_н:", Location = new Point(20, 85), AutoSize = true };
            txtXStart = new TextBox { Location = new Point(65, 82), Width = 65, Text = "0.1" };
            Label lblXE = new Label { Text = "x_к:", Location = new Point(145, 85), AutoSize = true };
            txtXEnd = new TextBox { Location = new Point(190, 82), Width = 65, Text = "1.0" };
            Label lblN = new Label { Text = "n:", Location = new Point(275, 85), AutoSize = true };
            numNSeries = new NumericUpDown { Location = new Point(305, 82), Width = 65, Minimum = 1, Maximum = 25, Value = 15 };
            Button btnCalc2 = new Button { Text = "Табулировать Y(x) и S(x)", Location = new Point(390, 80), Size = new Size(220, 30) };

            dgvSeries = new DataGridView
            {
                Location = new Point(20, 125),
                Size = new Size(710, 340),
                AllowUserToAddRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvSeries.Columns.Add("Step", "Точка №");
            dgvSeries.Columns.Add("X", "x");
            dgvSeries.Columns.Add("S", "Сумма ряда S(x) (рекурсия)");
            dgvSeries.Columns.Add("Y", "Точное значение Y = 5^x");
            dgvSeries.Columns.Add("Diff", "Погрешность |Y - S|");

            btnCalc2.Click += BtnCalc2_Click;
            tab2.Controls.AddRange(new Control[] { lblDesc2, lblXS, txtXStart, lblXE, txtXEnd, lblN, numNSeries, btnCalc2, dgvSeries });

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            this.Controls.Add(tabs);

            // Сразу заполним таблицу при открытии
            BtnCalc2_Click(this, EventArgs.Empty);
        }

        // Функция sort_elem(a, n) сортировки одномерного вещественного массива по убыванию
        public static void sort_elem(double[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i] < a[j])
                    {
                        double temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        private void BtnCalc1_Click(object sender, EventArgs e)
        {
            string[] parts = txtArrB.Text.Split(new[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                MessageBox.Show("Введите хотя бы одно число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nb = parts.Length;
            double[] b = new double[nb];
            for (int i = 0; i < nb; i++)
            {
                if (!double.TryParse(parts[i].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out b[i]))
                {
                    MessageBox.Show($"Некорректное число: {parts[i]}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            sort_elem(b, nb);

            lblRes1.Text = $"Размер массива nb = {nb}\n\n" +
                           $"Массив b после вызова sort_elem(b, nb) (по убыванию):\n" +
                           string.Join("   ", b.Select(v => v.ToString("F2")));
        }

        // Рекурсивная функция вычисления факториала k!
        public static double FactorialRec(int k)
        {
            if (k <= 1) return 1.0;
            return k * FactorialRec(k - 1);
        }

        // Рекурсивная функция вычисления суммы ряда S(x, n) = Σ (k=0..n) (ln^k(5) / k!) * x^k
        public static double SeriesSumRec(double x, int k)
        {
            if (k == 0) return 1.0;
            double term = Math.Pow(Math.Log(5.0) * x, k) / FactorialRec(k);
            return SeriesSumRec(x, k - 1) + term;
        }

        private void BtnCalc2_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtXStart.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double xStart) ||
                !double.TryParse(txtXEnd.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double xEnd))
            {
                MessageBox.Show("Введите корректные границы диапазона x_н и x_к.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int n = (int)numNSeries.Value;
            double h = (xEnd - xStart) / 10.0;

            dgvSeries.Rows.Clear();
            for (int idx = 0; idx <= 10; idx++)
            {
                double x = xStart + idx * h;
                double s = SeriesSumRec(x, n);
                double y = Math.Pow(5.0, x);
                double diff = Math.Abs(y - s);

                dgvSeries.Rows.Add(
                    idx + 1,
                    x.ToString("F4"),
                    s.ToString("F8"),
                    y.ToString("F8"),
                    diff.ToString("E3")
                );
            }
        }
    }
}