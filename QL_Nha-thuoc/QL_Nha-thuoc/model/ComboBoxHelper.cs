using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

public static class ComboBoxHelper
{
    private static Dictionary<ComboBox, bool> isFiltering = new();
    private static Dictionary<ComboBox, DataTable> originalData = new();
    private static Dictionary<ComboBox, bool> isUserTyping = new();

    public static void EnableComboBoxFiltering(ComboBox comboBox, DataTable data, string displayMember, string valueMember)
    {
        comboBox.DisplayMember = displayMember;
        comboBox.ValueMember = valueMember;
        comboBox.DataSource = data;
        comboBox.SelectedIndex = -1;

        // Gán dữ liệu gốc để lọc sau này
        originalData[comboBox] = data;
        isFiltering[comboBox] = false;
        isUserTyping[comboBox] = false;

        // Gắn sự kiện
        comboBox.KeyDown -= ComboBox_KeyDown;
        comboBox.KeyDown += ComboBox_KeyDown;

        comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
        comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

        comboBox.TextChanged -= ComboBox_TextChanged;
        comboBox.TextChanged += ComboBox_TextChanged;
    }

    private static void ComboBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (sender is ComboBox comboBox)
        {
            // Bắt đầu gõ
            isUserTyping[comboBox] = true;
        }
    }

    private static void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (sender is ComboBox comboBox)
        {
            // Khi người dùng chọn từ danh sách thì KHÔNG cần lọc
            isUserTyping[comboBox] = false;
        }
    }

    private static void ComboBox_TextChanged(object sender, EventArgs e)
    {
        if (sender is not ComboBox comboBox || !isUserTyping[comboBox]) return;
        if (isFiltering[comboBox]) return;

        isFiltering[comboBox] = true;

        string input = comboBox.Text.Trim();
        int caretPos = comboBox.SelectionStart;

        if (originalData.TryGetValue(comboBox, out DataTable data))
        {
            if (string.IsNullOrEmpty(input))
            {
                comboBox.DataSource = data;
                comboBox.SelectedIndex = -1;
                comboBox.DroppedDown = false;
            }
            else
            {
                var filteredRows = data.AsEnumerable()
                    .Where(r => r.Field<string>(comboBox.DisplayMember).ToLower().Contains(input.ToLower()))
                    .ToList();

                if (filteredRows.Count > 0)
                {
                    DataTable filteredTable = filteredRows.CopyToDataTable();
                    comboBox.DataSource = filteredTable;
                    comboBox.SelectedIndex = -1;
                    comboBox.DroppedDown = true;

                    comboBox.Text = input;
                    comboBox.SelectionStart = caretPos;
                    comboBox.SelectionLength = 0;
                }
                else
                {
                    comboBox.DroppedDown = false;
                }
            }
        }

        isFiltering[comboBox] = false;
    }
}






