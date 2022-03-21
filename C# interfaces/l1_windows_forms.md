# Windows Forms (.NET)

## Пример
Исходная задача: система уравнений
```
     |a-2b, если ab < 5
y= <
     |sqrt(ab), если ab >= 5
```

## Задание свойств элементов управления
<br>

**Form1**
- Form Border Style - Fixed Sigle // Запрет изменения размера окна
- Maximize Box - False // Запрет кнопки фулл скрина
- Text - Задача // Название окна

**groupBox1**
- Text - Исходные данные

**groupBox2**
- Text - Результаты решения

**label1**
- Text - A

**label2**
- Text - B

**label3**
- Text - Y

**label4**
- Name - lbY // Имя для обращения в коде. (Первые 2-3 символа - тип блока)
- BorderStyle - Fixed3D
- AutoSize - False // Подгонка окна под содержимое

**label5**
- Text - Протокол работы

**label6**
- Name - lbP
- BorderStyle - Fixed3D
- AutoSize - False

**textBox1**
- Name - tbA
- BorderStyle - Fixed3D

**textBox2**
- Name - tbB
- BorderStyle - Fixed3D

**button1**
- Text - Решение

<br>

## Задание обработчиов событий

button1 - Click

1) Выбрать button1, окно событий
2) Действие `Click`
3) 2 ЛКМ в пустое окно | Клик + enter

<br>

## Код кнопки

```
private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(tbA.Text);
                double b = Convert.ToDouble(tbB.Text);
                double y;

                if (a * b < 5)
                    y = a - 2 * b;
                else
                    y = Math.Sqrt(a * b);

                lbY.Text = y.ToString("n"); // Формат n - numeric - компиллятор сам определят тип (int, double) | ToString("0.000n")
                lbP.Text = lbP.Text + "A = " + tbA.Text + "  B = " + tbB.Text + "  Y = " + lbY.Text + "\r\n";
            }
            catch
            {
                MessageBox.Show("Проверьте исходные данные", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); // Другие Виды окон Warning, Information, Error
            }
            tbA.Focus(); // Переводит курсор на элемент. (Делает элемент активным)
            tbA.Clear();
            tbB.Clear();
        }
```
<br>

Для `tbA` задаем обработчик события `KeyPress`

```
private void tbA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            if (e.KeyChar == '.')
                e.KeyChar = ',';

            if (e.KeyChar == ',')
            {
                if ((sender as TextBox).Text.IndexOf(',') != -1 || (sender as TextBox).Text.Length == 0)
                    e.Handled = true; // Данное событие обработано (не пропускаем событие дальше)
                return;
            }

            if ((e.KeyChar == '+') || (e.KeyChar == '-'))
            {
                if (((sender as TextBox).Text.IndexOf('+') != -1) || ((sender as TextBox).Text.IndexOf('-') != -1) || ((sender as TextBox).Text.Length > 0))
                    e.Handled = true;
                return;
            }

            if (Char.IsControl(e.KeyChar))
                return;

            e.Handled = true;
            return;
        }
```

Для `tbB` подключить обработчик событий `tbA_KeyPress` (выбрать из выпадающего меню)

Нажатие "Enter", свойство KeyDown:
```
private void tbA_KeyDown(object sender, KeyEventArgs e)
{
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ActiveControl, true, true, true, true);
}
```

Обработчик событий TextChanged для tbA и tbB
```
private void tbA_TextChanged(object sender, EventArgs e)
        {
            if (tbA.Text != "" && tbB.Text != "")
                button1.Enabled = true;
            else button1.Enabled = false;
        }
```
